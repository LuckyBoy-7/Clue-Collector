using System;
using Lucky.Extensions;
using Lucky.Interactive;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ClueCollector.Scripts
{
    public class Button : InteractableUI
    {
        public Color normalColor = Color.white;
        public Color disabledColor = Color.white;
        public Color hoverColor = Color.white.WithA(0.2f);
        public Color pressColor = Color.white;

        public Image outline;
        public TMP_Text text;

        public Action OnButtonClicked;

        public bool dontUpdateColor;


        private void Update()
        {
            if (dontUpdateColor)
                return;

            if (!CanInteract)
            {
                UpdateColor(disabledColor);
                return;
            }

            if (pressing)
                UpdateColor(pressColor);
            else if (CursorInBounds())
            {
                UpdateColor(hoverColor);
            }
            else
            {
                UpdateColor(normalColor);
            }
        }

        public void UpdateColor(Color color)
        {
            if (outline != null)
                outline.color = color;
            if (text != null)
                text.color = color;
        }

        public void ResetColor()
        {
            UpdateColor(normalColor);
        }


        protected override void OnCursorClick()
        {
            base.OnCursorClick();
            OnButtonClicked?.Invoke();
        }

        public void Enable()
        {
            CanInteract = true;
            dontUpdateColor = false;
            ResetColor();
        }

        public void Disable()
        {
            CanInteract = false;
            dontUpdateColor = true;
            ResetColor();
        }
    }
}