using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClueCollector.Scripts
{
    public class StartGame : MonoBehaviour
    {
        public Button button1;
        public Button button2;
        public FadeController fadeController;

        public bool started;

        private void Awake()
        {
            button1.OnButtonClicked += OnButtonClicked;
            button2.OnButtonClicked += OnButtonClicked;
        }

        private void OnDestroy()
        {
            button1.OnButtonClicked -= OnButtonClicked;
            button2.OnButtonClicked -= OnButtonClicked;
        }

        private void OnButtonClicked()
        {
            if (started)
                return;
            started = true;

            DOTween.To(() => fadeController.alpha, (alpha) => fadeController.alpha = alpha, 0, 1)
                .onComplete += () => SceneManager.LoadScene("ClueCollector");

            button1.Disable();
            button2.Disable();
        }
    }
}