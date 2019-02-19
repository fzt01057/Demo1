using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Common
{
    public static class TransformHelper
    {
        public static Transform FindChildByName(this Transform currentTF, string childName)
        {
            if (currentTF == null)
                return null;
            Transform res = currentTF.Find(childName);
            if (res != null)
                return res;
            for (int i = 0; i < currentTF.childCount; i++)
            {
                res = FindChildByName(currentTF.GetChild(i), childName);
                if (res != null)
                    return res;
            }
            return null;
        }

        public static void LookAtDirection(this Transform currentTF,Vector3 direction,float rotateSpeed)
        {
            if (direction == Vector3.zero)
                return;
            Quaternion lookDir = Quaternion.LookRotation(direction);
            Quaternion.Lerp(currentTF.rotation,lookDir, rotateSpeed);
        }

        public static void LookAtPositon(this Transform currentTF,Vector3 position, float rotateSpeed)
        {
            currentTF.LookAtDirection(position - currentTF.position, rotateSpeed);
        }
    }
}
