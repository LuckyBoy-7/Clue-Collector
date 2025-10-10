using DG.Tweening;
using Lucky.Animation.Color;
using Lucky.Utilities.Groups;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClueCollector.Scripts
{
    [RequireComponent(typeof(ButtonComponentGroup))]
    public class StartGame : MonoBehaviour
    {
        public ColorController colorController;
        private ButtonComponentGroup buttonComponentGroup;

        public bool started;

        private void Awake()
        {
            buttonComponentGroup = GetComponent<ButtonComponentGroup>();
            buttonComponentGroup.DoAction(button => button.OnButtonClicked += OnButtonClicked);
        }

        private void OnDestroy()
        {
            buttonComponentGroup.DoAction(button => button.OnButtonClicked -= OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            if (started)
                return;
            started = true;

            DOTween.To(() => colorController.Alpha, (alpha) => colorController.Alpha = alpha, 0, 1)
                .onComplete += () => SceneManager.LoadScene("ClueCollector");

            buttonComponentGroup.DoAction(button =>
            {
                button.dontUpdateColor = true;
                button.Disable();
            });
        }
    }
}