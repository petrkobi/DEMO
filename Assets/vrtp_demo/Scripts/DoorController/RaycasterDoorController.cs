using System.Collections;
using System.Collections.Generic;
using vrtp_demo.Scripts.Common.Events;
using UnityEngine;
using UnityEngine.UIElements;
using vrtp_demo.Scripts.DoorController;
using UniRx;
using vrtp_demo.Scripts.DoorController.Events;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;

public class RaycasterDoorController : MonoBehaviour
{
    [Header("Colliders")]
    [SerializeField] private Collider frontLeftDoor;
    [SerializeField] private Collider frontRightDoor;
    [SerializeField] private Collider rearLeftDoor;
    [SerializeField] private Collider rearRightDoor;
    
    [Header("Animators")]
    [SerializeField] private Animator animator_frontLeftDoor;
    [SerializeField] private Animator animator_frontRightDoor;
    [SerializeField] private Animator animator_rearLeftDoor;
    [SerializeField] private Animator animator_rearRightDoor;

    private Camera cameraMain;
    

    // Start is called before the first frame update
    private void Start()
    {
        cameraMain = Camera.main;
    }
    
    private void Update()
    {
        if ( Input.GetMouseButtonDown(0)){ 
            RaycastHit hit;
            Debug.Log("Shoot Ray");
            Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
            if ( Physics.Raycast (ray,out hit,100.0f )) {

                if (hit.collider == frontLeftDoor)
                {
                    
                    EventDispatcher.Publish(new OpenDoorEvent()
                    {
                        DoorName = "FRONT_LEFT_DOOR"
                    });
                    
                    Debug.Log("You selected the " + hit.collider.name);
                    //if (_mazdaData.IsFrontLeftDoorOpen)
                    {
                        /*
                        Debug.Log("Close");
                        animator_frontLeftDoor.SetBool("is_FrontLeft_door_open", false);

                        _mazdaData.IsFrontLeftDoorOpen = !_mazdaData.IsFrontLeftDoorOpen;
                        */
                    }
                    //else
                    {

                        
                        /*
                        Debug.Log("Open");
                        animator_frontLeftDoor.SetBool("is_FrontLeft_door_open", true);
                        

                        _mazdaData.IsFrontLeftDoorOpen = !_mazdaData.IsFronRightDoorOpen;
                        */
                    }
                    
                    
                }

            }
        }
    }
}
