using Lucky.Dialogs;
using Lucky.Inputs;
using Lucky.Interactive;
using Lucky.Managers;
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

        [SerializeField]private string currentLanguage;


        protected override void SingletonAwake()
        {
            base.SingletonAwake();
            Time.fixedDeltaTime = OneFrameTime;
            InputConfig.Initialize();
            Dialog.Initialize();
            GameCursor.Instance = new GameCursor();

            DontDestroyOnLoad(gameObject);
        }

        public void Update()
        {
            InputManager.Update();
            GameCursor.Instance.Update();
            if (Dialog.CurrentLanguage != null)
                currentLanguage = Dialog.CurrentLanguage.name;
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