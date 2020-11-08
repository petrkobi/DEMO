using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityFx.Outline;
using vrtp_demo.Scripts.UI;
using vrtp_demo.Scripts.UI.ScriptableObjects;

namespace vrtp_demo.Scripts.DoorController
{
    public class CursorOverDetector : MonoBehaviour
    {
    
        [Header("Colliders")]
        [SerializeField] private Collider frontLeftDoor;
        [SerializeField] private Collider frontRightDoor;
        [SerializeField] private Collider rearLeftDoor;
        [SerializeField] private Collider rearRightDoor;
        [SerializeField] private Collider tailDoor;
    
    
        [Header("MeshObject")]
        [SerializeField] private List<OutlineBehaviour> frontLeftDoorMeshList = new List<OutlineBehaviour>();
        [SerializeField] private List<OutlineBehaviour> frontRightDoorMeshList = new List<OutlineBehaviour>();
        [SerializeField] private List<OutlineBehaviour> rearLeftDoorMeshList = new List<OutlineBehaviour>();
        [SerializeField] private List<OutlineBehaviour> rearRightDoorMeshList = new List<OutlineBehaviour>();
        [SerializeField] private List<OutlineBehaviour> tailDoorMeshList = new List<OutlineBehaviour>();

        [Header("Colors")]
        [SerializeField] private Color activeColor;
        [SerializeField] private Color unActiveColor;


        [Header("Data")] 
        [SerializeField] private MazdaData _mazdaData;
        [SerializeField] private WindowDataStatus _windowDataStatus;

        private Transform hit1;
        private Transform hit2;

        public int hitCount;
    
        void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(0.5))
                //Observable.IntervalFrame(30)
                .Subscribe(_ =>
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit, 100.0f))
                    {
                        //if (_windowDataStatus.WindowStatus == Constants.WindowStatusColorPicker) return;
                        if (_windowDataStatus.Window == WindowDataStatus.WindowStatus.ColorPickerWindow) return;
                    
                        hitCount++;
                        if (hitCount % 2 == 0)
                        {
                            hit1 = hit.collider.transform;
                        }
                        else
                        {
                            hit2 = hit.collider.transform;
                        }

                        //both Rays on same Collider?
                        if (hit1 != hit2)
                        {
                            _mazdaData.IsCursorOnFrontLeftDoor = false;
                            _mazdaData.IsCursorOnFrontRightDoor = false;
                            _mazdaData.IsCursorOnRearRightDoor = false;
                            _mazdaData.IsCursorOnRearLeftDoor = false;
                            _mazdaData.IsCursorOnTailDoor = false;
                        
                            return;
                        }
                    
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
                            _mazdaData.IsCursorOnFrontRightDoor = true;
                            SetColorToObject(frontRightDoorMeshList, activeColor);

                        }
                        else
                        {
                            _mazdaData.IsCursorOnFrontRightDoor = false;
                            SetColorToObject(frontRightDoorMeshList, unActiveColor);

                        }
                    
                    
                        if (hit.collider == rearLeftDoor)
                        {
                            _mazdaData.IsCursorOnRearLeftDoor = true;
                            SetColorToObject(rearLeftDoorMeshList, activeColor);
                        }
                        else
                        {
                            _mazdaData.IsCursorOnRearLeftDoor = false;
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

                    
                        if (hit.collider == tailDoor)
                        {
                            _mazdaData.IsCursorOnTailDoor = true;
                            SetColorToObject(tailDoorMeshList, activeColor);
                        }
                        else
                        {
                            _mazdaData.IsCursorOnTailDoor = false;
                            SetColorToObject(tailDoorMeshList, unActiveColor);
                        }
                    }
                    else
                    {

                        hit1 = null;
                        hit2 = null;

                        _mazdaData.IsCursorOnFrontLeftDoor = false;
                        _mazdaData.IsCursorOnFrontRightDoor = false;
                        _mazdaData.IsCursorOnRearRightDoor = false;
                        _mazdaData.IsCursorOnRearLeftDoor = false;
                        _mazdaData.IsCursorOnTailDoor = false;
                    
                        SetColorToObject(frontLeftDoorMeshList, unActiveColor);
                        SetColorToObject(frontRightDoorMeshList, unActiveColor);
                        SetColorToObject(rearLeftDoorMeshList, unActiveColor);
                        SetColorToObject(rearRightDoorMeshList, unActiveColor);
                        SetColorToObject(tailDoorMeshList, unActiveColor);
                    
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
}
