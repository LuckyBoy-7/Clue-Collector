using Lucky.Console.Scripts;
using Lucky.IO;
using UnityEngine;

namespace Test.Scripts
{
    public class TestData
    {
        public int a = 1;
        public ulong b = 2;
        public string c = "lsddakjf;";
        public bool d = true;
    }

    public class Test2 : MonoBehaviour
    {
        private void Awake()
        {
            TestData data = new() { c = "awa" };
            SaveLoadManager.Instance.Save("test_data1", data);
            Debug.Log(SaveLoadManager.Instance.Load("test_data1", data).c);
        }
    }
}