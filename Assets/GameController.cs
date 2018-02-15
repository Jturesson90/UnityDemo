using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour {

    public float WorldWidth = 10f;

    [SerializeField]
    private OnWorldWidthChangedEvent _onWorldWidthChanged;

    private void Start()
    {
        _onWorldWidthChanged?.Invoke(WorldWidth);
    }


}
[System.Serializable]
public class OnWorldWidthChangedEvent: UnityEvent<float>{}