using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAsRuntimeGameObject : MonoBehaviour
{
    [SerializeField] RuntimeGameObject _gameObjectRef;

    void OnEnable()
    {
        _gameObjectRef.Value = this.gameObject;        
    }

    void OnDisable()
    {
        if (_gameObjectRef.Value == this.gameObject)
        {
            _gameObjectRef.Value = null;
        }
    }
}
