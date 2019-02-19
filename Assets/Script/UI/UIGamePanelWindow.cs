using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Common;
using UnityEngine.UI;

namespace Assets.Script.UI
{

    /// <summary>
    /// 
    /// </summary>
    public class UIGamePanelWindow :UIWindow
    {
        private GameAreaInit area;
        private TimeScript text;

        protected override void Awake()
        {
            base.Awake();
            area = transform.GetComponentInChildren<GameAreaInit>();
            text = transform.FindChildByName("TimeText").GetComponent<TimeScript>();
            GetEventListener("ReturnButton").PointerClick += OnReturnButtonClick;
            GetEventListener("RestartButton").PointerClick += OnRestartButtonClick;
        }

        private void OnRestartButtonClick(PointerEventData eventData)
        {
            Init();
        }

        private void OnReturnButtonClick(PointerEventData eventData)
        {
            UIManager.Instance.GetWindow<UIStartPanelWindow>().SetVisiable(true);
            UIManager.Instance.GetWindow<UIGamePanelWindow>().SetVisiable(false);
            UIManager.Instance.GetWindow<UIGameOverPanelWindow>().SetVisiable(false);
        }

        protected override void Init()
        {
            base.Init();
            area.Init();
            text.Init();
            UIManager.Instance.GetWindow<UIGameOverPanelWindow>().SetVisiable(false);
        }
    }
}