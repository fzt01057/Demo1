using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Common;

namespace Assets.Script.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIWindow : MonoBehaviour
    {
        private Dictionary<string, UIEventListener> UIEventListenerDic = new Dictionary<string, UIEventListener>();
        private CanvasGroup canvas;

        protected virtual void Awake()
        {
            canvas = gameObject.GetComponent<CanvasGroup>();
        }

        public void SetVisiable(bool isVisiable, float delay = 0)
        {
            StartCoroutine(Delay(isVisiable, delay));
        }

        private IEnumerator Delay(bool isVisiable, float delay)
        {
            yield return new WaitForSeconds(delay);
            canvas.alpha = isVisiable ? 1 : 0;
            canvas.blocksRaycasts = isVisiable;
            if (isVisiable)
                Init();
        }

        public UIEventListener GetEventListener(string name)
        {
            UIEventListener res;
            if (UIEventListenerDic.ContainsKey(name))
                res = UIEventListenerDic[name];
            else
            {
                res = UIEventListener.GetUIEventListener(transform.FindChildByName(name));
                if (res != null)
                    UIEventListenerDic.Add(name, res);
            }
            return res;
        }

        protected virtual void Init()
        { }
    }
}
