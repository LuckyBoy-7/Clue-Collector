using Lucky.Dialogs;
using Lucky.Interactive.Impl;
using UnityEngine;

namespace ClueCollector.Scripts
{
    public class LanguageSelect : MonoBehaviour
    {
        public enum LanguageTypes
        {
            Chinese,
            English
        }

        public LanguageTypes languageType;

        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.OnButtonClicked += OnButtonClicked;
        }

        private void OnDestroy()
        {
            button.OnButtonClicked -= OnButtonClicked;
        }

        private void OnButtonClicked()
        {
            if (languageType == LanguageTypes.Chinese)
            {
                Dialog.CurrentLanguage = Dialog.languages["Simplified Chinese"];
            }
            else
            {
                Dialog.CurrentLanguage = Dialog.languages["English"];
            }
        }
    }
}