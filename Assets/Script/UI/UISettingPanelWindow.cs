using Assets.Script.Common;
using Common;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class UISettingPanelWindow : UIWindow
    {
        protected override void Awake()
        {
            base.Awake();
            GetEventListener("ReturnButton").PointerClick += OnReturnButtonClick;
            GetEventListener("SaveButton").PointerClick += OnSaveButtonClick;
        }

        private void OnSaveButtonClick(PointerEventData eventData)
        {
            GameController.Instance.Volume = transform.FindChildByName("Volume").GetComponent<Slider>().value;
            GameController.Instance.map = (MapEnum)transform.FindChildByName("Scale").GetComponent<Dropdown>().value;
            UIManager.Instance.GetWindow<UIStartPanelWindow>().SetVisiable(true);
            UIManager.Instance.GetWindow<UISettingPanelWindow>().SetVisiable(false);
        }

        private void OnReturnButtonClick(PointerEventData eventData)
        {
            UIManager.Instance.GetWindow<UIStartPanelWindow>().SetVisiable(true);
            UIManager.Instance.GetWindow<UISettingPanelWindow>().SetVisiable(false);
        }
    }
}