using System;
using System.Collections.Generic;
using DhafinFawwaz.ActionExtension;
using UnityEngine;
using UnityEngine.UI;

public class Subscriber : MonoBehaviour
{
    [SerializeField] StaticAction _staticAction;
    [SerializeField] StaticAction<int> _staticActionInt;
    [SerializeField] Text _text;

    void OnEnable() {
        _staticAction += () => {
            Debug.Log("Event!");
        };

        _staticActionInt += (val) => {
            Debug.Log("Event!, value: " + val);
            _text.text = val.ToString();
        };
    }

    void OnDisable() {
        _staticAction.RemoveAllListener();
        _staticActionInt.RemoveAllListener();
    }
    
}
