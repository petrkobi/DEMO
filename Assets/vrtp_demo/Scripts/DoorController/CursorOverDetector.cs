using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityFx.Outline;
using vrtp_demo.Scripts.UI.ScriptableObjects;

namespace vrtp_demo.Scripts.DoorController
{
    /// <summary>
    ///  Detection if cursor is on the same collider, for specific time. At least two hits in one Collider for selected Door.
    /// </summary>
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

        private Camera camera;

        private Transform hit1;
        private Transform hit2;

        private int hitCount;
    
        private void Start()
        {
            camera = Camera.main;
            
            //Run Interval over 1/2 seconds -> "Cast Ray" ->
            Observable.Interval(TimeSpan.FromSeconds(0.5))
                //Observable.IntervalFrame(30)
                .Subscribe(_ =>
                {
                    RaycastHit hit;
                    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit, 100.0f))
                    {
                        //when we are in ColorPicker return
                        if (_windowDataStatus.Window == WindowDataStatus.WindowStatus.ColorPickerWindow) return;
                    
                        //store first and second hit
                        hitCount++;
                        if (hitCount % 2 == 0)
                        {
                            hit1 = hit.collider.transform;
                        }
                        else
                        {
                            hit2 = hit.collider.transform;
                        }

                        //If two hit collider aren't same RETURN - user move with cursor
                        if (hit1 != hit2)
                        {
                            _mazdaData.IsCursorOnFrontLeftDoor = false;
                            _mazdaData.IsCursorOnFrontRightDoor = false;
                            _mazdaData.IsCursorOnRearRightDoor = false;
                            _mazdaData.IsCursorOnRearLeftDoor = false;
                            _mazdaData.IsCursorOnTailDoor = false;
                        
                            return;
                        }
                        
                        //if make HIT
                        if (hit.collider == frontLeftDoor)
                        {
                            _mazdaData.IsCursorOnFrontLeftDoor = true;
                            //Set Color ACTIVE for all parts in List
                            SetColorToObject(frontLeftDoorMeshList, activeColor);
                        }
                        else
                        {
                            _mazdaData.IsCursorOnFrontLeftDoor = false;
                            //If not, set Color UN-ACTIVE for all parts in list
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
                        // null, and reset
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
