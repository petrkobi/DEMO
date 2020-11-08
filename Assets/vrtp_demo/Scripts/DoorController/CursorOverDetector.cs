using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityFx.Outline;
using vrtp_demo.Scripts.DoorController;

public class CursorOverDetector : MonoBehaviour
{
    
    [Header("Colliders")]
    [SerializeField] private Collider frontLeftDoor;
    [SerializeField] private Collider frontRightDoor;
    [SerializeField] private Collider rearLeftDoor;
    [SerializeField] private Collider rearRightDoor;
    
    
    [Header("MeshObject")]
    [SerializeField] private List<OutlineBehaviour> frontLeftDoorMeshList = new List<OutlineBehaviour>();
    [SerializeField] private List<OutlineBehaviour> frontRightDoorMeshList = new List<OutlineBehaviour>();
    [SerializeField] private List<OutlineBehaviour> rearLeftDoorMeshList = new List<OutlineBehaviour>();
    [SerializeField] private List<OutlineBehaviour> rearRightDoorMeshList = new List<OutlineBehaviour>();

    [Header("Colors")]
    [SerializeField] private Color activeColor;
    [SerializeField] private Color unActiveColor;


    [Header("Data")] [SerializeField] private MazdaData _mazdaData;
    
    void Start()
    {
       //Observable.Interval(TimeSpan.FromSeconds(0.5))
       Observable.IntervalFrame(30)
           .Subscribe(_ =>
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.collider == frontLeftDoor)
                    {
                        _mazdaData.IsCursorOnFrontLeftDoor = true;
                        SetColorToObject(frontLeftDoorMeshList, activeColor);
                    }
                    else
                    {
                        _mazdaData.IsCursorOnFrontLeftDoor = false;
                        SetColorToObject(frontLeftDoorMeshList, unActiveColor);
                    }
                    
                    
                    if (hit.collider == frontRightDoor)
                    {
                        _mazdaData.IsCursorOnFrontRighttDoor = true;
                        SetColorToObject(frontRightDoorMeshList, activeColor);

                    }
                    else
                    {
                        _mazdaData.IsCursorOnFrontLeftDoor = false;
                        SetColorToObject(frontRightDoorMeshList, unActiveColor);

                    }
                    
                    
                    if (hit.collider == rearLeftDoor)
                    {
                        _mazdaData.IsCursorOnRearLeftDoor = true;
                        SetColorToObject(rearLeftDoorMeshList, activeColor);
                    }
                    else
                    {
                        _mazdaData.IsCursorOnRearRightDoor = false;
                        SetColorToObject(rearLeftDoorMeshList, unActiveColor);
                    }
                    
                    
                    if (hit.collider == rearRightDoor)
                    {
                        _mazdaData.IsCursorOnRearRightDoor = true;
                        SetColorToObject(rearRightDoorMeshList, activeColor);
                    }
                    else
                    {
                        _mazdaData.IsCursorOnRearRightDoor = false;
                        SetColorToObject(rearRightDoorMeshList, unActiveColor);
                    }
                }
                else
                {
                    SetColorToObject(frontLeftDoorMeshList, unActiveColor);
                    SetColorToObject(frontRightDoorMeshList, unActiveColor);
                    SetColorToObject(rearLeftDoorMeshList, unActiveColor);
                    SetColorToObject(rearRightDoorMeshList, unActiveColor);
                }
            });

    }

    private void SetColorToObject(List<OutlineBehaviour> objects, Color color)
    {
        foreach (var obj in objects)
        {
            obj.OutlineColor = color;
        }   
    }
}
