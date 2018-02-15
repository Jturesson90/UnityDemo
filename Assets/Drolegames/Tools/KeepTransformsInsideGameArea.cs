using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Drolegames.Tools
{
    public class KeepTransformsInsideGameArea : MonoBehaviour
    {

        [SerializeField]
        private float _worldWidth = 5f;

        private List<KeepInsideGameArea> items = new List<KeepInsideGameArea>();

        public void OnWorldWidthChanged(float worldWidth)
        {
            _worldWidth = worldWidth;
        }


        private void Start()
        {
            items = FindObjectsOfType<KeepInsideGameArea>().ToList();

        }
        private void Update()
        {
            foreach (var item in items)
            {
                if (-(_worldWidth * 0.5f) > item.transform.position.x)
                {
                    UpdateXPosition(item.transform, _worldWidth * 0.5f);
                }
                else if ((_worldWidth * 0.5f) < item.transform.position.x)
                {
                    UpdateXPosition(item.transform, -_worldWidth * 0.5f);
                }
            }
        }

        private void UpdateXPosition(Transform t, float x)
        {
            t.position = new Vector3(x, t.position.y, t.position.z);
        }
    }
}