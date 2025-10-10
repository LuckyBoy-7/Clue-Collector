using Lucky;
using Lucky.Utilities;
using Lucky.Utilities.Groups;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ClueCollector.Scripts
{
    public class ThumbnailManager : Singleton<ThumbnailManager>
    {
        public GameObject centerImage;
        public Image thumbnailImageInner;
        public Thumbnail thumbnailPrefab;


        public void ShowImage(Sprite sprite)
        {
            centerImage.SetActive(true);
            thumbnailImageInner.sprite = sprite;
        }

        public void HideImage()
        {
            centerImage.SetActive(false);
        }

        public void CreateThumbnail(Sprite sprite)
        {
            var thumbnail = gameObject.AddChildPrefab(thumbnailPrefab);
            thumbnail.sprite = sprite;
            thumbnail.transform.SetAsLastSibling();
        }
    }
}