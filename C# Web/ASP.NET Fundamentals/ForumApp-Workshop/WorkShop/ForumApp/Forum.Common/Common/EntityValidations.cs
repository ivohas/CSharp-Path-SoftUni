namespace ForumApp.Common
{
    public static class EntityValidations
    {
        public static class Post
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;
            public const int ContentMinLenght = 30;
            public const int ContentMaxLeght = 1_500;
        }
    }
}
