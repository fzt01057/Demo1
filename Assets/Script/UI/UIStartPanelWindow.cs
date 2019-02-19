using System;
using UnityEngine.EventSystems;

namespace Assets.Script.UI
{
    public class UIStartPanelWindow : UIWindow
    {
        protected override void Awake()
        {
            base.Awake();
            GetEventListener("GameStartButton").PointerClick += OnGameStartButtonClick;
            GetEventListener("SettingButton").PointerClick += OnSettingButtonClick;
        }

        private void OnSettingButtonClick(PointerEventData eventData)
        {
            UIManager.Instance.GetWindow<UISettingPanelWindow>().SetVisiable(true);
            UIManager.Instance.GetWindow<UIStartPanelWindow>().SetVisiable(false);
        }

        private void OnGameStartButtonClick(PointerEventData eventData)
        {
            UIManager.Instance.GetWindow<UIModeChoosePanelWindow>().SetVisiable(true);
            UIManager.Instance.GetWindow<UIStartPanelWindow>().SetVisiable(false);
        }
    }
}
