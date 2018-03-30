using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LayoutViewTemplate
    {
        private string _smartAppTitle { get; set; }
        private ConcernInfo _concern { get; set; }
        private LayoutInfo _layout { get; set; }
        private LanguageList _languages { get; set; }
        private Dictionary<string, string> _menu { get; set; }
        public LayoutViewTemplate(string smartAppTitle, ConcernInfo concern, LayoutInfo layout, LanguageList languages)
        {
            _smartAppTitle = smartAppTitle;
            _concern = concern;
            _layout = layout;
            _languages = languages;
            _menu = getMenu(_concern);
        }

        /// <summary>
        /// Retrieve the specific menu for each concern.
        /// </summary>
        /// <param name="concern">A concern.</param>
        public Dictionary<string, string> getMenu(ConcernInfo concern)
        {
            Dictionary<string, string> menu = new Dictionary<string, string>();
            if (concern != null && concern.Id != null && concern.Layouts.AsEnumerable() != null)
                foreach (LayoutInfo layout in concern.Layouts.AsEnumerable())
                    if (layout.IsVisibleInMenu && layout.Id != null && layout.Title != null && !menu.ContainsKey(CamelCase(concern.Id) + "-" + CamelCase(layout.Id)))
                        menu.Add(CamelCase(concern.Id) + "-" + CamelCase(layout.Id), layout.Title);
            return menu;
        }

        /// <summary>
        /// Convert a string to PascalCase.
        /// </summary>
        /// <param name="word">A word to convert.</param>
        public static string PascalCase(string word)
        {
            string result = "";
            word = word.Trim();
            if (word.Length > 0)
            {
                char[] separators = new char[] {
                    ' ',
                    '-',
                    '_',
                    '/'
                };
                string[] splittedString = word.Split(separators);

                splittedString[0] = Regex.Replace(splittedString[0], "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.Compiled).Trim();
                splittedString[0] = splittedString[0].Replace(" ", string.Empty);
                splittedString[0] = splittedString[0].Substring(0, 1).ToUpper() + splittedString[0].Substring(1);
                result += splittedString[0];

                for (int i = 1; i < splittedString.Count(); i++)
                {
                    splittedString[i] = Regex.Replace(splittedString[i], "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.Compiled).Trim();
                    splittedString[i] = splittedString[i].Replace(" ", string.Empty);
                    splittedString[i] = splittedString[i].Substring(0, 1).ToUpper() + splittedString[i].Substring(1);
                    result += splittedString[i];
                }
            }
            return result;
        }

        /// <summary>
        /// Convert a string to CamelCase.
        /// </summary>
        /// <param name="word">A word to convert.</param>
        public static string CamelCase(string word)
        {
            string result = "";
            word = word.Trim();
            if (word.Length > 0)
            {
                char[] separators = new char[] {
                    ' ',
                    '-',
                    '_',
                    '/'
                };
                string[] splittedString = word.Split(separators);

                splittedString[0] = Regex.Replace(splittedString[0], "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.Compiled).Trim();
                splittedString[0] = splittedString[0].Replace(" ", string.Empty);
                splittedString[0] = splittedString[0].Substring(0, 1).ToLower() + splittedString[0].Substring(1);
                result += splittedString[0];

                for (int i = 1; i < splittedString.Count(); i++)
                {
                    splittedString[i] = Regex.Replace(splittedString[i], "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.Compiled).Trim();
                    splittedString[i] = splittedString[i].Replace(" ", string.Empty);
                    splittedString[i] = splittedString[i].Substring(0, 1).ToUpper() + splittedString[i].Substring(1);
                    result += splittedString[i];
                }
            }
            return result;
        }

        public override string OutputPath => "src\\pages";
    }
}
