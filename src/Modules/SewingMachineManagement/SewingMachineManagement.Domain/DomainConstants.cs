namespace SewingMachineManagement.Domain;

public static class DomainConstants
{
    public static class GarmentSewingMachineTypeEntity
    {
        public const string DbTableName = "GMT_SW_MCN_TYP";
        public const int SewingMachineTypeCodeMaxLength = 10;
        public const int SewingMachineTypeNameEnglishMaxLength = 100;
        public const int SewingMachineTypeNameBengaliMaxLength = 150;
        public const int SewingMachineTypeNameSNameMaxLength = 10;
    }

    public static class GarmentSewingMachineSpecificationEntity
    {
        public const string DbTableName = "GMT_SW_MCN_SPEC";
        public const int DescriptionMaxLength = 100;
    }

    public static class GarmentSewingMachineGuideEntity
    {
        public const string DbTableName = "GMT_SW_MCN_GUIDE";
        public const int DescriptionMaxLength = 100;
    }

    public static class GarmentSewingApplicationTypeEntity
    {
        public const string DbTableName = "GMT_SW_APP_TYP";
        public const int CodeMaxLength = 10;
        public const int EnglishNameMaxLength = 100;
        public const int BengaliNameMaxLength = 150;
        public const int ShortNameMaxLength = 10;
    }

    public static class GarmentStitchTypeEntity
    {
        public const string DbTableName = "GMT_STCH_TYP";
        public const int CodeMaxLength = 10;
        public const int EnglishNameMaxLength = 100;
        public const int BengaliNameMaxLength = 150;
        public const int ShortNameMaxLength = 10;
    }

    public static class GarmentSewingMachineThreadConsumptionEntity
    {
        public const string DbTableName = "GMT_SM_THRD_CONS";
    }

    public static class GarmentSewingMachineGuideTypeEntity
    {
        public const string DbTableName = "GMT_SM_GUIDE_TYP";
        public const int CodeMaxLength = 10;
        public const int EnglishNameMaxLength = 100;
        public const int BengaliNameMaxLength = 150;
        public const int ShortNameMaxLength = 10;
    }

    public static class GarmentSewingMachineBedTypeEntity
    {
        public const string DbTableName = "GMT_SM_BED_TYP";
        public const int CodeMaxLength = 10;
        public const int EnglishNameMaxLength = 100;
        public const int BengaliNameMaxLength = 150;
        public const int ShortNameMaxLength = 10;
    }

    public static class ReferenceMeasurementOfUnitEntity
    {
        public const string DbTableName = "RF_MOU";
        public const int CodeMaxLength = 10;
        public const int EnglishNameMaxLength = 20;
        public const int BengaliNameMaxLength = 50;
    }


    public static class LookupTableEntity
    {
        public const string DbTableName = "LOOKUP_TABLE";
        public const int CodeMaxLength = 10;
        public const int EnglishNameMaxLength = 50;
        public const int BengaliNameMaxLength = 50;
        public const int DescriptionMaxLength = 300;
    }

    public static class LookupDataEntity
    {
        public const string DbTableName = "LOOKUP_DATA";
        public const int CodeMaxLength = 10;
        public const int EnglishNameMaxLength = 300;
        public const int BengaliNameMaxLength = 100;
        public const int DescriptionMaxLength = 300;
        public const int ShortNameMaxLength = 50;
        public const int DataPrefixMaxLength = 6;
        public const int ColorCodeMaxLength = 20;
    }
}