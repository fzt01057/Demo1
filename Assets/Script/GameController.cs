using Assets.Script.Common;
using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class GameController : MonoSingleTon<GameController>
    {
        private float volume;
        public float Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
                audioSource.volume = volume;
            }
        }
        AudioSource audioSource;
        public MapEnum map = MapEnum.Big;

        public ModeEnum mode = ModeEnum.Normal;

        private GameAreaInit gameArea;

        public override void Init()
        {
            base.Init();
            audioSource = Camera.main.GetComponent<AudioSource>();
            gameArea = transform.FindChildByName("GameArea").GetComponent<GameAreaInit>();
        }

        public void GameStart()
        {
            UIManager.Instance.GetWindow<UIStartPanelWindow>().SetVisiable(true);
        }

        public void Win()
        {
            UIGameOverPanelWindow winPanel = UIManager.Instance.GetWindow<UIGameOverPanelWindow>();
            winPanel.SetVisiable(true);
            winPanel.GetComponentInChildren<Text>().text = "获胜";
            gameArea.isRunning = false;
            gameArea.isLive = false;
        }

        public void Lost()
        {
            UIGameOverPanelWindow winPanel = UIManager.Instance.GetWindow<UIGameOverPanelWindow>();
            winPanel.SetVisiable(true);
            winPanel.GetComponentInChildren<Text>().text = "失败";
            gameArea.isRunning = false;
            gameArea.isLive = false;
        }
    }
}