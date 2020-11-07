using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;
using vrtp_demo.Scripts.DoorController;
using vrtp_demo.Scripts.DoorController.Events;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;

public class AnimationDoorController : MonoBehaviour
{
    
    [Header("Animators")]
    [SerializeField] private Animator animator_frontLeftDoor;
    [SerializeField] private Animator animator_frontRightDoor;
    [SerializeField] private Animator animator_rearLeftDoor;
    [SerializeField] private Animator animator_rearRightDoor;
    
    [Header("Data")]
    [SerializeField] private MazdaData _mazdaData;
    
    
    // Start is called before the first frame update
    void Start()
    {
        EventDispatcher.Receive<OpenDoorEvent>().Subscribe(OnDoorEvent);

    }

    private void OnDoorEvent(OpenDoorEvent e)
    {
        switch (e.DoorName)
        {
            case "FRONT_LEFT_DOOR":
                if (_mazdaData.IsFrontLeftDoorOpen)
                {
                    animator_frontLeftDoor.SetBool("is_FrontLeft_door_open", false);
                }
                else
                {
                    animator_frontLeftDoor.SetBool("is_FrontLeft_door_open", true);
                }
                
                _mazdaData.IsFrontLeftDoorOpen = !_mazdaData.IsFrontLeftDoorOpen;
                break;
                
            default:
                Debug.Log("Default: " + e.DoorName);
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
