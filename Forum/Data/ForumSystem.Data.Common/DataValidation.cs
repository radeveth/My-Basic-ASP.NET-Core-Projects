namespace ForumSystem.Data.Common
{
    public class DataValidation
    {
        public static class CategoryValudation
        {
            public const int NameMaxLength = 50;
            public const int DescriptionMaxLength = 15000;
            public const int ImageUrlMaxLength = 2048;
        }

        public static class PostValidation
        {
            public const int TitleMaxLength = 50;
            public const int ContentMaxLength = 30000;
        }

        public static class CommentValidation
        {
            public const int ContentMaxLength = 10000;
        }

        public static class NotificationValidation
        {
            public const int NameMaxLength = 200;
        }
    }
}
