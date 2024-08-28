using System.Collections;
using System.Globalization;
using System.Linq.Dynamic.Core;
using System.Text.Json;
using Humanizer;
using SewingMachineManagement.Application.Common.Misc;
using SewingMachineManagement.Domain.DataTransferObjects.Request;

namespace SewingMachineManagement.Infrastructure.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, int page, int limit)
    {
        if (page <= 0)
        {
            page = 1;
        }

        if (limit <= 0)
        {
            limit = 1;
        }

        return queryable.Skip((page - 1) * limit).Take(limit);
    }

    public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> query,
        IReadOnlyList<TabulatorFilterDto> filters) where TSource : class
    {
        var props = typeof(TSource).GetProperties()
            .Select(p => (PropName: p.Name, DataType: p.PropertyType)).ToList();

        foreach (var filter in filters)
        {
            if (filter.Field.Contains('.'))
            {
                continue;
            }

            var (name, type) = props.Select(x => (x.PropName, x.DataType)).FirstOrDefault(x =>
                x.PropName.Equals(filter.Field, StringComparison.InvariantCultureIgnoreCase)
            );

            if (name is null || type is null)
            {
                continue;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = Nullable.GetUnderlyingType(type);

                if (type is null)
                {
                    continue;
                }
            }

            object? value;

            try
            {
                if (type == typeof(string))
                {
                    value = filter.Value;
                }

                else if (type == typeof(DateTime) &&
                         name.Contains("utc", StringComparison.CurrentCultureIgnoreCase))
                {
                    value = DateTime.SpecifyKind(Convert.ToDateTime(filter.Value).ToUniversalTime(),
                        DateTimeKind.Utc);
                }

                else
                {
                    if (type.IsGenericType || type.IsEnum)
                    {
                        value = JsonSerializer.Deserialize(filter.Value, type);
                    }
                    else
                    {
                        value = type == typeof(Guid)
                            ? Guid.Parse(filter.Value)
                            : Convert.ChangeType(filter.Value, type, CultureInfo.InvariantCulture);
                    }
                }
            }
            catch (Exception)
            {
                value = null;
            }

            if (value is null)
            {
                continue;
            }

            var predicate = string.Empty;


            if (type == typeof(string))
            {
                var strOperator = filter.Type switch
                {
                    TabulatorFilters.Like => "Contains",
                    TabulatorFilters.NotLike => "NotContains",
                    TabulatorFilters.Starts => "StartsWith",
                    TabulatorFilters.NotStarts => "NotStartsWith",
                    TabulatorFilters.Ends => "EndsWith",
                    TabulatorFilters.NotEnds => "NotEndsWith",
                    _ => "Contains"
                };

                predicate = strOperator switch
                {
                    "NotContains" => "x => !x." + name + ".ToLower().Contains(@0.ToLower())",
                    "NotStartsWith" => "x => !x." + name + ".ToLower().StartsWith(@0.ToLower())",
                    "NotEndsWith" => "x => !x." + name + ".ToLower().EndsWith(@0.ToLower())",
                    _ => "x => x." + name + ".ToLower()." + strOperator + "(@0.ToLower())"
                };
            }

            else if (type == typeof(bool) || type.IsEnum)
            {
                var boolOperator = filter.Type switch
                {
                    TabulatorFilters.Equal => TabulatorFilters.Equal,
                    TabulatorFilters.NotEquals => TabulatorFilters.NotEquals,
                    _ => TabulatorFilters.Equal
                };
                predicate = "x => x." + name + " != null && x." + name + " " + boolOperator + " @0";
            }


#pragma warning disable S1125
            else if (type != typeof(string) && typeof(IEnumerable).IsAssignableFrom(type) is false &&
#pragma warning restore S1125
                     filter.Type is TabulatorFilters.GreaterThan
                         or TabulatorFilters.LessThan
                         or TabulatorFilters.GreaterThanEqual
                         or TabulatorFilters.LessThanEqual
                         or TabulatorFilters.Equal
                         or TabulatorFilters.NotEquals)
            {
                var nonStrOperator = filter.Type switch
                {
                    TabulatorFilters.GreaterThan => TabulatorFilters.GreaterThan,
                    TabulatorFilters.LessThan => TabulatorFilters.LessThan,
                    TabulatorFilters.Equal => TabulatorFilters.Equal,
                    TabulatorFilters.NotEquals => TabulatorFilters.NotEquals,
                    TabulatorFilters.GreaterThanEqual => TabulatorFilters.GreaterThanEqual,
                    TabulatorFilters.LessThanEqual => TabulatorFilters.LessThanEqual,
                    _ => TabulatorFilters.Equal
                };

                predicate = "x => x." + name + " != null && x." + name + " " + nonStrOperator + " @0";
            }

            if (predicate != string.Empty)
            {
                query = query.Where(predicate, value);
            }
        }

        return query;
    }


    public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query,
        IReadOnlyList<TabulatorSortingDto> sorts) where TSource : class
    {
#pragma warning disable S1125
        if (sorts.Any() is false)
#pragma warning restore S1125
        {
            return query;
        }

        var firstColumn = sorts[0];
        var source = query.OrderBy($"{firstColumn.Field.Pascalize()} {firstColumn.Dir.ToUpper()}");

        foreach (var (field, dir) in sorts.Skip(1))
        {
            source = source.ThenBy($"{field.Pascalize()} {dir.ToUpper()}");
        }

        return source;
    }
}
