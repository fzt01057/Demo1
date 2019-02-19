using Assets.Script.Common;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class GameAreaInit : MonoBehaviour
    {
        GridLayoutGroup group;
        PointScript[,] points;
        public GameObject prefab;
        [HideInInspector]
        public int num;
        [HideInInspector]
        public int bomb;
        [HideInInspector]
        public bool isRunning = false;
        [HideInInspector]
        public bool isLive = true;
        [HideInInspector]
        public bool isPress = false;
        [HideInInspector]
        public float delayTime = 0;

        private void Update()
        {
            if (isPress)
                delayTime += Time.deltaTime;
            else
                delayTime = 0;
        }

        private void Awake()
        {
            group = gameObject.GetComponent<GridLayoutGroup>();
        }

        public void Init()
        {
            isLive = true;
            switch (GameController.Instance.map)
            {
                case MapEnum.Big:
                    CreatePoints(14, 7);
                    break;
                case MapEnum.Middle:
                    CreatePoints(12, 6);
                    break;
                case MapEnum.Small:
                    CreatePoints(10, 5);
                    break;
            }
        }

        private void CreatePoints(int width, int height)
        {
            if (points != null)
                for (int i = 0; i < points.GetLength(0); i++)
                    for (int j = 0; j < points.GetLength(1); j++)
                        Destroy(points[i, j].gameObject);
            bomb = 0;
            num = height * width;
            group.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            group.constraintCount = width;
            points = new PointScript[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    points[i, j] = Instantiate(prefab, transform).GetComponent<PointScript>();
                    points[i, j].width = i;
                    points[i, j].height = j;
                }
            }
        }

        public PointScript[] GetNeightbour(int width, int height)
        {
            List<PointScript> list = new List<PointScript>();
            for (int i = width - 1; i <= width + 1; i++)
                for (int j = height - 1; j <= height + 1; j++)
                    if (i >= 0 && i <= points.GetLength(0) - 1 && j >= 0 && j <= points.GetLength(1) - 1 && points[i, j].isVaild)
                        list.Add(points[i, j]);
            return list.ToArray();
        }

    }
}