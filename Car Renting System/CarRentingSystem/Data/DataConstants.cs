namespace CarRentingSystem.Data
{
    public class DataConstants
    {
        // Max Url
        public class UrlConstants
        {
            public const int UrlMaxLength = 2048;
        }


        // Car Model
        public class CarConstants
        {
            public const int BarndMinLength = 2;
            public const int BarndMaxLength = 20;

            public const int ModelMinLength = 3;
            public const int ModelMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 10000;

            public const int MinYear = 2000;
            public const int MaxYear = 2050;
        }


        // Category Model
        public class CategoryConstants
        {
            public const int NameMaxLength = 25;
        }

        // Delaer Model
        public class DealerConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;

            public const int PhoneNumberMinLength = 6;
            public const int PhoneNumberMaxLength = 20;
        }
    }
}
