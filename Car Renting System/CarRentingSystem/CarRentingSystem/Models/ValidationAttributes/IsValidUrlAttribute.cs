namespace CarRentingSystem.Models.ValidationAttributes
{

    using System.Text.RegularExpressions;
    using System.ComponentModel.DataAnnotations;

    public class IsValidUrlAttribute : ValidationAttribute
    {
        private const string urlPattern =
            @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
        private string givenUrl;

        public IsValidUrlAttribute(string url)
        {
            givenUrl = url;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Match match = Regex.Match(givenUrl, urlPattern);

            if (match.Success)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage = "Invalid url");
        }
    }
}
