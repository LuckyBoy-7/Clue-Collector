using System;
using Lucky.Animation;
using Lucky.Extensions;
using Lucky.Interactive;
using UnityEngine;

namespace ClueCollector.Scripts.BoxNodes
{
    [RequireComponent(typeof(Pulsator))]
    [RequireComponent(typeof(SineFloat))]
    public class BoxNode : InteractableUI
    {
        protected Pulsator pulsater;
        public BoxNode parentNode;
        protected SineFloat sineFloat;
        protected LineConnector lineConnector;

        public virtual void Awake()
        {
            pulsater = GetComponent<Pulsator>();
            sineFloat = GetComponent<SineFloat>();
        }

        protected override void OnCursorClick()
        {
            base.OnCursorClick();
            pulsater.Pulsate();
        }

        protected override void OnCursorDrag(bool hasStart, Vector2 delta)
        {
            base.OnCursorDrag(hasStart, delta);
            if (!hasStart)
                return;
            transform.position += (Vector3)delta;
            sineFloat.localAnchorPosition += (Vector3)delta;
        }


        public virtual void FixedUpdate()
        {
            if (parentNode != null)
            {
                if (lineConnector == null)
                {
                    lineConnector = gameObject.AddComponent<LineConnector>();
                    lineConnector.from = parentNode.transform;
                    lineConnector.to = transform;
                    lineConnector.useDottedLine = true;
                }
            }
        }
    }
}