using Assets.Script.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Script.UI
{
    public class UIModeChoosePanelWindow : UIWindow
    {
        protected override void Awake()
        {
            base.Awake();
            GetEventListener("EasyModeButton").PointerClick += OnEasyModeButtonClick;
            GetEventListener("NormalModeButton").PointerClick += OnNormalModeButtonClick;
            GetEventListener("HardModeButton").PointerClick += OnHardModeButtonClick;
            GetEventListener("ReturnButton").PointerClick += OnReturnButtonClick;
        }

        private void OnReturnButtonClick(PointerEventData eventData)
        {
            UIManager.Instance.GetWindow<UIStartPanelWindow>().SetVisiable(true);
            UIManager.Instance.GetWindow<UIModeChoosePanelWindow>().SetVisiable(false);
        }

        private void OnHardModeButtonClick(PointerEventData eventData)
        {
            GameController.Instance.mode = ModeEnum.Hard;
            UIManager.Instance.GetWindow<UIGamePanelWindow>().SetVisiable(true);
            UIManager.Instance.GetWindow<UIModeChoosePanelWindow>().SetVisiable(false);
        }

        private void OnNormalModeButtonClick(PointerEventData eventData)
        {
            GameController.Instance.mode = ModeEnum.Normal;
            UIManager.Instance.GetWindow<UIGamePanelWindow>().SetVisiable(true);
            UIManager.Instance.GetWindow<UIModeChoosePanelWindow>().SetVisiable(false);
        }

        private void OnEasyModeButtonClick(PointerEventData eventData)
        {
            GameController.Instance.mode = ModeEnum.Easy;
            UIManager.Instance.GetWindow<UIGamePanelWindow>().SetVisiable(true);
            UIManager.Instance.GetWindow<UIModeChoosePanelWindow>().SetVisiable(false);
        }
    }
}