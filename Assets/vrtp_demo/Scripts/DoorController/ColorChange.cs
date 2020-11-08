using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;
using vrtp_demo.Scripts.ColorPickerWindow.Events;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;

public class ColorChange : MonoBehaviour
{

    [SerializeField] private List<MeshRenderer> carCaseList = new List<MeshRenderer>();
    
    private void Start()
    {
        EventDispatcher.Receive<ChangeColorEvent>()
            .Subscribe(e =>
            {
                foreach (var part in carCaseList)
                {
                    part.material.color = e.ChangeColor;
                }
            });
    }
}
