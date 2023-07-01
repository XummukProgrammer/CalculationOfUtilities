using System.Collections.Generic;

namespace CalculationOfUtilities.Translations
{
    public class TranslationsManager
    {
        public TranslationLangType CurrentLangType { set; get; }

        private List<Translation> _translations = new List<Translation>();

        public void AddTranslation(Translation translation)
        {
            _translations.Add(translation);
        }

        public Translation GetTranslation(string key)
        {
            foreach (Translation translation in _translations)
            {
                if (translation.Key == key)
                {
                    return translation;
                }
            }
            return null;
        }

        public void AddTranslationText(string key, TranslationLangType langType, string text)
        {
            var translation = GetTranslation(key);
            if (translation == null)
            {
                translation = new Translation(key);
                AddTranslation(translation);
            }

            translation.AddText(langType, text);
        }

        public string GetTranslationText(string key)
        {
            var translation = GetTranslation(key);
            if (translation != null)
            {
                return translation.GetText(CurrentLangType);
            }
            return "Undefined: " + key;
        }
    }
}
