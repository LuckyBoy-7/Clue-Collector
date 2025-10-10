using ClueCollector.Scripts.BoxNodes;
using Lucky;
using Lucky.Utilities;
using UnityEngine;

namespace ClueCollector.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        public Transform canvas;
        public BoxNode startBoxNode;

        public FlagSystem FlagSystem = new();
        public bool debug = false;


        private void Start()
        {
            Instantiate(startBoxNode, canvas).transform.position = Vector3.zero;
        }
    }
}