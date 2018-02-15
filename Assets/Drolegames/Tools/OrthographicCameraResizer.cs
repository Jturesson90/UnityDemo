using UnityEngine;
using System.Collections;


namespace Drolegames.Tools
{
    [RequireComponent(typeof(Camera))]
    public class OrthographicCameraResizer : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The default orthographic size in unity units")]
        private float _defaultSize = 1f;

        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            UpdateFromUnits(_defaultSize);
        }

        public void UpdateFromUnits(float unityUnits)
        {
            _camera.orthographicSize = unityUnits * Screen.height / Screen.width * 0.5f;
        }

    }
}