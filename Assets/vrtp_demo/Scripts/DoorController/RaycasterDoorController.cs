using System.Collections;
using System.Collections.Generic;
using vrtp_demo.Scripts.Common.Events;
using UnityEngine;
using UnityEngine.UIElements;
using vrtp_demo.Scripts.DoorController;
using UniRx;
using vrtp_demo.Scripts.DoorController.Events;
using vrtp_demo.Scripts.UI;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;

public class RaycasterDoorController : MonoBehaviour
{
    [Header("Colliders")]
    [SerializeField] private Collider frontLeftDoor;
    [SerializeField] private Collider frontRightDoor;
    [SerializeField] private Collider rearLeftDoor;
    [SerializeField] private Collider rearRightDoor;

    [Header("Data")]
    [SerializeField] private WindowDataStatus _windowDataStatus;

    private Camera cameraMain;
    
    private void Start()
    {
        cameraMain = Camera.main;
    }
    
    private void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        { 
            if (_windowDataStatus.Window == WindowDataStatus.WindowStatus.ColorPickerWindow) return;
            
            RaycastHit hit;
            Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
            if ( Physics.Raycast (ray,out hit,100.0f )) {
                
                if (hit.collider == frontLeftDoor)
                {
                    EventDispatcher.Publish(new OpenDoorEvent()
                    {
                        DoorName = "FRONT_LEFT_DOOR"
                    }, false);
                }
                else if (hit.collider == frontRightDoor)
                {
                    EventDispatcher.Publish(new OpenDoorEvent()
                    {
                        DoorName = "FRONT_RIGHT_DOOR"
                    }, false);
                }
                else if (hit.collider == rearLeftDoor)
                {
                    EventDispatcher.Publish(new OpenDoorEvent()
                    {
                        DoorName = "REAR_LEFT_DOOR"
                    }, false);
                }
                else if (hit.collider == rearRightDoor)
                {
                    EventDispatcher.Publish(new OpenDoorEvent()
                    {
                        DoorName = "REAR_RIGHT_DOOR"
                    }, false);
                }
                
            }
        }
    }
}
