using System.Collections.Generic;
using Lucky.Extensions;
using Lucky.Interactive;
using UnityEngine;
using UnityEngine.UI;

namespace ClueCollector.Scripts
{
    public class CanvasMover : InteractableUI
    {
        protected override void OnCursorDrag(bool hasStart, Vector2 delta)
        {
            base.OnCursorDrag(hasStart, delta);
            transform.position += (Vector3)delta;
        }
    }
}