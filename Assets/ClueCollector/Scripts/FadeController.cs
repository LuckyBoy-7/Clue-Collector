using System.Collections.Generic;
using Lucky.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace ClueCollector.Scripts
{
    public class FadeController : MonoBehaviour
    {
        public List<MaskableGraphic> graphics;

        private float oldAlpha = -1;
        public float alpha = 1;

        private void Update()
        {
            if (alpha != oldAlpha || oldAlpha == -1)
            {
                oldAlpha = alpha;
                UpdateAlpha();
            }
        }

        public void UpdateAlpha()
        {
            foreach (var graphic in graphics)
            {
                graphic.color = graphic.color.WithA(alpha);
            }
        }
    }
}