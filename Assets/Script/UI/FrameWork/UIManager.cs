using System;
using System.Collections.Generic;
using Common;

namespace Assets.Script.UI
{
    public class UIManager :MonoSingleTon<UIManager>
    {

        private Dictionary<Type, UIWindow> dictionary;

        public void AddWindow(UIWindow uiWindow)
        {
            dictionary.Add(uiWindow.GetType(),uiWindow);
        }

        public T GetWindow<T>() where T:class
        {
            if (dictionary[typeof(T)] == null)
                return null;
            return dictionary[typeof(T)] as T;
        }

        public override void Init()
        {
            base.Init();
            dictionary = new Dictionary<Type, UIWindow>();
            UIWindow[] obj =FindObjectsOfType<UIWindow>();
            foreach (UIWindow ui in obj)
            {
                ui.SetVisiable(false);
                dictionary.Add(ui.GetType(),ui);
            }
            GameController.Instance.GameStart();
        }

    }
}
