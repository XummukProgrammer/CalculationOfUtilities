using System.Collections.Generic;

namespace CalculationOfUtilities.Translations
{
    public class Translation
    {
        public string Key { private set; get; }

        private Dictionary<TranslationLangType, string> _texts = new Dictionary<TranslationLangType, string>();

        public Translation(string key)
        {
            Key = key;
        }

        public void AddText(TranslationLangType type, string text)
        {
            _texts[type] = text;
        }

        public string GetText(TranslationLangType type)
        {
            if (_texts.ContainsKey(type))
            {
                return _texts[type];
            }
            return "Undefined: " + Key;
        }
    }
}
