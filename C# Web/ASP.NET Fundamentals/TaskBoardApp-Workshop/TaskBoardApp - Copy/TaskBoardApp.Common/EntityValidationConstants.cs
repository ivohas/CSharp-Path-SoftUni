namespace TaskBoardApp.Common
{
    public static class EntityValidationConstants
    {
        public static class Task
        {
            public const int TitleMinLenght = 5;
            public const int TitleMaxLenght = 70;

            public const int DescriptionMinLenght = 10;
            public const int DescriptionMaxLenght = 1000;
        }
        public static class Board
        {
            public const int NameMinLength = 3;
            public const int NameMaxLenght = 30;
        }
    }
}