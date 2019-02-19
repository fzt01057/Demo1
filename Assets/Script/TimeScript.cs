using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.UI;

namespace Assets.Script.UI {
    public class TimeScript : MonoBehaviour {

        GameAreaInit area;
        Text text;
        float currTime = 0;

        void Start() {
            area = transform.parent.FindChildByName("GameArea").GetComponent<GameAreaInit>();
            text = transform.GetComponent<Text>();
            Init();
        }

        void Update() {
            if (area.isRunning)
            {
                currTime += Time.deltaTime;
                text.text = string.Format("地雷:{0}    时间:{1:D2}:{2:D2}", area.bomb, (int)currTime / 60, (int)currTime % 60);
            }
        }

        public void Init()
        {
            currTime = 0;
            text.text = "地雷:"+area.bomb+"    时间:00:00";
        }
    }
}