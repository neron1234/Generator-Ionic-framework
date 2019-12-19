using System.Text.RegularExpressions;
using Common.Generator.Framework.Extensions;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public static class Helper
    {
        public static string WordSeperator(string input)
        {
            return Regex.Replace(input.ToPascalCase(), "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }

        public static string GetHtmlType(string type)
        {
            string htmlType = type;

            if (type.Equals("string"))
            {
                htmlType = "text";
            }

            return htmlType;
        }

        public static string GetType(string type)
        {
            string returnType = "";
            switch (type.ToLower())
            {
                case "integer":
                    returnType = "number";
                    break;
                case "date":
                    returnType = "Date";
                    break;
                default:
                    returnType = type;
                    break;
            }
            return returnType;
        }

        public static bool IsModelBool(string type)
        {
            bool result = false;
            switch (type.ToLower())
            {
                case "date": break;
                case "integer": break;
                case "string": break;
                case "number": break;
                case "boolean": break;
                default: result = true; break;
            }
            return result;
        }
    }
}
