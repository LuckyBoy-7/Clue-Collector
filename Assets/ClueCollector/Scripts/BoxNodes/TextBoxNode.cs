using System;
using System.Collections.Generic;
using System.Linq;
using Lucky.Audio;
using Lucky.Dialogs;
using Lucky.Interactive;
using Lucky.UI.Text;
using Lucky.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace ClueCollector.Scripts.BoxNodes
{
    [Serializable]
    public struct UnlockData
    {
        public string flagsNeed;
        public BoxNode nextBoxNode;
    }


    public class TextBoxNode : BoxNode
    {
        public enum ClickTypes
        {
            One,
            Three,
            Five,
        }

        public ClickTypes clickType = ClickTypes.One;

        private string dialogKey;
        public List<UnlockData> unlockDatas;
        public string flagToSet;

        public bool gameOverOnClick;

        public float fromPitch = 0.5f;
        public float toPitch = 4;
        public float pitchDecreaseSpeed = 1;
        public float pitchIncreaseSpeedOnEachClick = 0.4f;

        public float currentPitch;

        public TypewriterEffect typewriterEffect;

        private bool FullyExplored => unlockDatas.Count == 0;


        public Image image;

        public Sprite spriteToShowOnInit;
        private FlagSystem Flags => GameManager.Instance.FlagSystem;

        public override void Awake()
        {
            base.Awake();
            dialogKey = gameObject.name.Replace("(Clone)", "");
            typewriterEffect = GetComponent<TypewriterEffect>();
            currentPitch = fromPitch;
            AudioController.Instance.PlaySound2D("popup");
            pulsater.Pulsate();

            if (spriteToShowOnInit != null)
            {
                ThumbnailManager.Instance.CreateThumbnail(spriteToShowOnInit);
            }

            flagToSet = flagToSet.Trim();
            if (flagToSet != "")
                Flags.SetFlag(flagToSet);

            if (clickType == ClickTypes.One)
            {
                fromPitch = 0.5f;
                toPitch = 0.5f;
            }
            else if (clickType == ClickTypes.Three)
            {
                fromPitch = 0.5f;
                toPitch = 2;
            }
            else if (clickType == ClickTypes.Five)
            {
                fromPitch = 0.5f;
                toPitch = 4;
            }
        }

        protected override void Start()
        {
            base.Start();
            typewriterEffect.ShowText(Dialog.Clean(dialogKey)[0]);
        }

        public void Update()
        {
            currentPitch = MathUtils.Approach(currentPitch, fromPitch, pitchDecreaseSpeed * Time.deltaTime);

            UpdateBoxColorByExplorationState();
        }

        private void UpdateBoxColorByExplorationState()
        {
            if (gameOverOnClick)
            {
                image.color = new Color(0.6f, 0.7f, 0);
                return;
            }

            if (FullyExplored)
                image.color = new Color(0, 0.8f, 0);
            else if (unlockDatas.All(data => !CheckUnlockData(data))) // 都无法解锁
                image.color = new Color(0.7f, 0f, 0);
            else
                image.color = new Color(0.6f, 0.7f, 0);
        }


        protected override void OnCursorClick()
        {
            base.OnCursorClick();
            if (GameCursor.Instance.hasStartDrag)
                return;

            if (gameOverOnClick)
            {
                Application.Quit();
                Debug.Log("Quit");
            }

            if (!FullyExplored)
            {
                if (GameManager.Instance.debug)
                    currentPitch = toPitch;
                currentPitch = MathUtils.Approach(currentPitch, toPitch, pitchIncreaseSpeedOnEachClick);
                if (currentPitch == toPitch)
                {
                    currentPitch = fromPitch;
                    TryUnlockNextBox();
                }
            }

            AudioController.Instance.PlaySound2D("charge", pitch: new AudioParams.Pitch(currentPitch));
        }

        public bool CheckUnlockData(UnlockData unlockData) =>
            unlockData.flagsNeed == "" || unlockData.flagsNeed.Split(',').Select(flag => flag.Trim()).All(flag => Flags.GetFlag(flag));

        private void TryUnlockNextBox()
        {
            for (var i = 0; i < unlockDatas.Count; i++)
            {
                if (CheckUnlockData(unlockDatas[i]))
                {
                    CreateNextBoxNode(unlockDatas[i].nextBoxNode);
                    unlockDatas.RemoveAt(i);
                    return;
                }
            }
        }

        private void CreateNextBoxNode(BoxNode nextBoxNode)
        {
            BoxNode node = Instantiate(nextBoxNode, transform.parent);
            node.transform.position = transform.position + RandomUtils.InsideUnitCircle * (RectTransform.sizeDelta.magnitude * 0.6f);
            node.parentNode = this;
        }
    }
}