using UnityEngine;

namespace Test.Scripts
{
    public class Test2 : MonoBehaviour
    { 
        private void Awake()
        {
            print("awake");

            Resources.Load<Sprite>("Art/Gradients/circle_gradient");
        }

        private void Start()
        {
            print("start");
        }

        private void OnEnable()
        {
            print("OnEnable");
        }

        private void OnDisable()
        {
            print("OnDisable");
        }
    }
}