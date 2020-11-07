using UniRx;
using UnityEngine;
using vrtp_demo.Scripts.DoorController.Events;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;

namespace vrtp_demo.Scripts.DoorController
{
    public class AnimationDoorController : MonoBehaviour
    {
    
        [Header("Animators")]
        [SerializeField] private Animator animator_frontLeftDoor;
        [SerializeField] private Animator animator_frontRightDoor;
        [SerializeField] private Animator animator_rearLeftDoor;
        [SerializeField] private Animator animator_rearRightDoor;
    
        [Header("Data")]
        [SerializeField] private MazdaData _mazdaData;
    
        private void Start()
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
                case "FRONT_RIGHT_DOOR":
                    if (_mazdaData.IsFronRightDoorOpen)
                    {
                        animator_frontRightDoor.SetBool("is_FrontRight_door_open", false);
                    }
                    else
                    {
                        animator_frontRightDoor.SetBool("is_FrontRight_door_open", true);
                    }
                    _mazdaData.IsFronRightDoorOpen = !_mazdaData.IsFronRightDoorOpen;
                    break;
                case "REAR_LEFT_DOOR":
                    if (_mazdaData.IsRearLeftDoorOpen)
                    {
                        animator_rearLeftDoor.SetBool("is_RearLeft_door_open", false);
                    }
                    else
                    {
                        animator_rearLeftDoor.SetBool("is_RearLeft_door_open", true);
                    }
                    _mazdaData.IsRearLeftDoorOpen = !_mazdaData.IsRearLeftDoorOpen;
                    break;
                case "REAR_RIGHT_DOOR":
                    if (_mazdaData.IsRearRightDoorOpen)
                    {
                        animator_rearRightDoor.SetBool("is_RearRight_door_open", false);
                    }
                    else
                    {
                        animator_rearRightDoor.SetBool("is_RearRight_door_open", true);
                    }
                    _mazdaData.IsRearRightDoorOpen = !_mazdaData.IsRearRightDoorOpen;
                    break;
                default:
                    Debug.LogError("Default - Unknown state: " + e.DoorName);
                    break;
            }
        }
    }
}
