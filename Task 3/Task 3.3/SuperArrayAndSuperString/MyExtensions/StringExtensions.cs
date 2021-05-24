namespace MyExtensions
{
    using System.Linq;

    public enum Language
    { 
        Russian,
        English,
        Number,
        Mixed
    }

    public static class StringExtensions
    {
        public static Language GetLanguage(this string str)
        {
            char[] characters = str.ToCharArray();

            if (characters.All(ch => char.IsDigit(ch)))
            {
                return Language.Number;
            }

            if (characters.All(ch => char.IsLetter(ch)))
            {
                if (characters.All(ch =>
                   (ch >= 'a' && ch <= 'z')
                || (ch >= 'A' && ch <= 'Z')))
                {
                    return Language.English;
                }

                if (characters.All(ch =>
                  (ch >= 'а' && ch <= 'я')
               || (ch >= 'А' && ch <= 'Я')))
                {
                    return Language.English;
                }
            }
            
            return Language.Mixed;
        }
    }
}
