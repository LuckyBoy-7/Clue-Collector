using ClueCollector.Scripts.BoxNodes;
using Lucky.Managers;
using Lucky.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace ClueCollector.Scripts
{
    public class ThumbnailManager : Singleton<ThumbnailManager>
    {
        public Image thumbnailImageInner;
        public Image thumbnailImageOuter;
        public Thumbnail thumbnailPrefab;


        public void ShowImage(Sprite sprite)
        {
            thumbnailImageInner.sprite = sprite;
            thumbnailImageInner.enabled = true;
            thumbnailImageOuter.enabled = true;
        }

        public void HideImage()
        {
            thumbnailImageInner.enabled = false;
            thumbnailImageOuter.enabled = false;
        }

        public void CreateThumbnail(Sprite sprite)
        {
            var thumbnail = gameObject.AddChildPrefab(thumbnailPrefab);
            thumbnail.sprite = sprite;
            thumbnail.transform.SetAsLastSibling();
        }
    }
}