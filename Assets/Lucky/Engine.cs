using Lucky.Console.Scripts;
using Lucky.Dialogs;
using Lucky.Inputs;
using Lucky.Interactive;
using Lucky.IO;
using UnityEngine;
using Input = UnityEngine.Input;

namespace Lucky
{
    /// <summary>
    /// 在设置界面保证Engine最先调用, 然后Engine去初始化各种Manager, 以保证更新顺序正确
    /// </summary>
    public class Engine : Singleton<Engine>
    {
        public const float OneFrameTime = 1 / 60f;

        [SerializeField] public string startLanguage = "Simplified Chinese";
        [SerializeField] public InputManager inputManager = new();
        [SerializeField] public ConsoleManager consoleManager = new();


        protected override void SingletonAwake()
        {
            base.SingletonAwake();
            Time.fixedDeltaTime = OneFrameTime;
            Dialog.Initialize();
            Dialog.TrySetLanguage(startLanguage);
            GameCursor.Instance = new GameCursor();
            SaveLoadManager.Instance = new SaveLoadManager();
            ConsoleManager.Instance = new ConsoleManager();

            DontDestroyOnLoad(gameObject);
        }

        public void Update()
        {
            inputManager.Update();
            GameCursor.Instance.Update();
            ConsoleManager.Instance.Update();
        }


        public void FixedUpdate()
        {
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKeyDown(KeyCode.Q))
                    Time.timeScale /= 2;
                else if (Input.GetKeyDown(KeyCode.E))
                    Time.timeScale *= 2;
            }
#endif
        }
    }
}