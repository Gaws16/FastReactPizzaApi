namespace FastReactPizzaApi.Common;

public static class DataValidationConstants
{
    public static class Pizza
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;
        
        public const int MinDescriptionLength = 2;
        public const int MaxDescriptionLength = 200;
        
        public const int MinUnitPrice = 0;
        public const int MaxUnitPrice = 100;
    }
}