using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lucky.Dialogs
{
    public static class Dialog
    {
        public const string AssetRootPath = "Dialog/";

        public static Dictionary<string, Language> languages = new();

        private static Language _currentLanguage = null;

        public static Language CurrentLanguage
        {
            get
            {
                _currentLanguage ??= new Language("Chinese", "");

                return _currentLanguage;
            }
            set
            {
                bool languageChanged = _currentLanguage == null || _currentLanguage != value;
                _currentLanguage = value;
                if (languageChanged)
                    AfterLanguageChanged?.Invoke();
            }
        }

        public static Action AfterLanguageChanged;

        public static void Initialize()
        {
            languages.Clear();

            foreach (var textAsset in Resources.LoadAll<TextAsset>(AssetRootPath))
            {
                languages[textAsset.name] = new Language(textAsset.name, textAsset.text);
            }

            if (languages.Count != 0)
                CurrentLanguage = languages.First().Value;
        }

        public static List<string> Clean(string localizationKey)
        {
            if (!CurrentLanguage.ContainsKey(localizationKey))
                return new List<string>(){$"{{{localizationKey}}}"};
            return CurrentLanguage[localizationKey];
        }
    }
}