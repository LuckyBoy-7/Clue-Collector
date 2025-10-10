using DG.Tweening;
using Lucky.Interactive;
using UnityEngine;
using UnityEngine.UI;
using Ease = DG.Tweening.Ease;

namespace ClueCollector.Scripts
{
    public class Thumbnail : InteractableUI
    {
        public bool canShow = false;

        public Image image;
        public Sprite sprite;

        private const float FinalX = 120;


        protected override void Start()
        {
            base.Start();
            transform.DOMoveX(FinalX, 0.3f).SetEase(Ease.OutBack).onComplete += () => canShow = true;
            image.sprite = sprite;
        }

        protected override void OnCursorEnter()
        {
            base.OnCursorEnter();
            if (canShow)
                ThumbnailManager.Instance.ShowImage(sprite);
        }

        protected override void OnCursorExit()
        {
            base.OnCursorExit();
            ThumbnailManager.Instance.HideImage();
        }
    }
}