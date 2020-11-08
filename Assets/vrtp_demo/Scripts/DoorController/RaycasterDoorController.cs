﻿using System.Collections;
using System.Collections.Generic;
using vrtp_demo.Scripts.Common.Events;
using UnityEngine;
using UnityEngine.UIElements;
using vrtp_demo.Scripts.DoorController;
using UniRx;
using UnityEditor.U2D;
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
    [SerializeField] private Collider tailDoor;

    [Header("Data")]
    [SerializeField] private WindowDataStatus _windowDataStatus;
    [SerializeField] private MazdaData _mazdaData;

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
                    if (!_mazdaData.IsCursorOnFrontLeftDoor) return;
                    EventDispatcher.Publish(new OpenDoorEvent()
                    {
                        DoorName = "FRONT_LEFT_DOOR"
                    }, false);
                }
                else if (hit.collider == frontRightDoor)
                {
                    if (!_mazdaData.IsCursorOnFrontRightDoor) return;
                    EventDispatcher.Publish(new OpenDoorEvent()
                    {
                        DoorName = "FRONT_RIGHT_DOOR"
                    }, false);
                }
                else if (hit.collider == rearLeftDoor)
                {
                    if (!_mazdaData.IsCursorOnRearLeftDoor) return;
                    EventDispatcher.Publish(new OpenDoorEvent()
                    {
                        DoorName = "REAR_LEFT_DOOR"
                    }, false);
                }
                else if (hit.collider == rearRightDoor)
                {
                    if (!_mazdaData.IsCursorOnRearRightDoor) return;
                    EventDispatcher.Publish(new OpenDoorEvent()
                    {
                        DoorName = "REAR_RIGHT_DOOR"
                    }, true);
                }
                else if (hit.collider == tailDoor)
                {
                    Debug.Log("tail door");
                    if (!_mazdaData.IsCursorOnTailDoor) return;
                    EventDispatcher.Publish(new OpenDoorEvent()
                    {
                        DoorName = "TAIL_DOOR"
                    }, true);
                }
                else
                {
                    Debug.Log(hit.collider.name, gameObject);
                }
                
            }
        }
    }
}
