using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vrtp_demo.Scripts.UI;
using vrtp_demo.Scripts.UI.ScriptableObjects;

public class LightController : MonoBehaviour
{
    [SerializeField] private List<Light> garageLights;

    [Header("Data")]
    [SerializeField] private WindowDataStatus _windowDataStatus;
    
    private void Start()
    {
        _windowDataStatus.OnChange += WindowDataStatusOnChange;
    }

    private void OnDestroy()
    {
        _windowDataStatus.OnChange -= WindowDataStatusOnChange;
    }

    private void WindowDataStatusOnChange(float value)
    {
        foreach (var light in garageLights)
        {
            light.intensity = value;
        }
    }
}
