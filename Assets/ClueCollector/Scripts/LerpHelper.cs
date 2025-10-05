using System;
using System.Collections.Generic;
using Lucky.Extensions;
using Lucky.Interactive;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ClueCollector.Scripts
{
    public class LerpHelper : MonoBehaviour
    {
        [SerializeField] private Vector3 _targetLocalPos;

        public Vector3 TargetLocalPos
        {
            get => _targetLocalPos;
            set
            {
                started = true;
                _targetLocalPos = value;
            }
        }

        public float k = 0.05f;
        [SerializeField] private bool started;
        [SerializeField] private bool inited;

        private Func<Vector3> LocalPositionGetter;
        private Action<Vector3> LocalPositionSetter;

        public void Init(Func<Vector3> getter, Action<Vector3> setter)
        {
            LocalPositionGetter = getter;
            LocalPositionSetter = setter;
            inited = true;
        }


        private void FixedUpdate()
        {
            if (started && inited)
            {
                LocalPositionSetter(Vector3.Lerp(LocalPositionGetter(), TargetLocalPos, k));
            }
        }
    }
}