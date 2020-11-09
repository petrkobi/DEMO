using UniRx;
using UnityEngine;
using vrtp_demo.Scripts.DoorController.Events;
using vrtp_demo.Sounds.Events;
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
        [SerializeField] private Animator animator_tailDoor;
    
        [Header("Data")]
        [SerializeField] private MazdaData _mazdaData;
    
        private void Start()
        {
            //Receive Event 
            EventDispatcher.Receive<OpenDoorEvent>().Subscribe(OnDoorEvent);
        }

        //Receive Event check the parameter, which door are selected
        private void OnDoorEvent(OpenDoorEvent e)
        {
            switch (e.DoorName)
            {
                case "FRONT_LEFT_DOOR":
                    if (_mazdaData.IsFrontLeftDoorOpen)
                    {
                        //Close door -> set bool at animator
                        animator_frontLeftDoor.SetBool(Constants.ANIMATOR_FRONT_LEFT_DOOR_OPEN, false);
                        //Send Event for play sound
                        EventDispatcher.Publish(new PlayDoorSoundEvent(){ IsPlayOpenSound = false }, false);
                    }
                    else
                    {
                        //Open door -> set bool at animator
                        animator_frontLeftDoor.SetBool(Constants.ANIMATOR_FRONT_LEFT_DOOR_OPEN, true);
                        //Send Event for play sound
                        EventDispatcher.Publish(new PlayDoorSoundEvent(){ IsPlayOpenSound = true },false);
                    }
                    _mazdaData.IsFrontLeftDoorOpen = !_mazdaData.IsFrontLeftDoorOpen;
                    break;
                case "FRONT_RIGHT_DOOR":
                    if (_mazdaData.IsFronRightDoorOpen)
                    {
                        animator_frontRightDoor.SetBool(Constants.ANIMATOR_FRONT_RIGHT_DOOR_OPEN, false);
                        EventDispatcher.Publish(new PlayDoorSoundEvent(){ IsPlayOpenSound = false },false);
                    }
                    else
                    {
                        animator_frontRightDoor.SetBool(Constants.ANIMATOR_FRONT_RIGHT_DOOR_OPEN, true);
                        EventDispatcher.Publish(new PlayDoorSoundEvent(){ IsPlayOpenSound = true },false);
                    }
                    _mazdaData.IsFronRightDoorOpen = !_mazdaData.IsFronRightDoorOpen;
                    break;
                case "REAR_LEFT_DOOR":
                    if (_mazdaData.IsRearLeftDoorOpen)
                    {
                        animator_rearLeftDoor.SetBool(Constants.ANIMATOR_REAR_LEFT_DOOR_OPEN, false);
                        EventDispatcher.Publish(new PlayDoorSoundEvent(){ IsPlayOpenSound = false },false);
                    }
                    else
                    {
                        animator_rearLeftDoor.SetBool(Constants.ANIMATOR_REAR_LEFT_DOOR_OPEN, true);
                        EventDispatcher.Publish(new PlayDoorSoundEvent(){ IsPlayOpenSound = true },false);
                    }
                    _mazdaData.IsRearLeftDoorOpen = !_mazdaData.IsRearLeftDoorOpen;
                    break;
                case "REAR_RIGHT_DOOR":
                    if (_mazdaData.IsRearRightDoorOpen)
                    {
                        animator_rearRightDoor.SetBool(Constants.ANIMATOR_REAR_RIGHT_DOOR_OPEN, false);
                        EventDispatcher.Publish(new PlayDoorSoundEvent(){ IsPlayOpenSound = false },false);
                    }
                    else
                    {
                        animator_rearRightDoor.SetBool(Constants.ANIMATOR_REAR_RIGHT_DOOR_OPEN, true);
                        EventDispatcher.Publish(new PlayDoorSoundEvent(){ IsPlayOpenSound = true },false);
                    }
                    _mazdaData.IsRearRightDoorOpen = !_mazdaData.IsRearRightDoorOpen;
                    break;
                case "TAIL_DOOR":
                    if (_mazdaData.IsTailDoorOpen)
                    {
                        animator_tailDoor.SetBool(Constants.ANIMTOAR_TAIL_DOOR_OPEN, false);
                        EventDispatcher.Publish(new PlayDoorSoundEvent(){ IsPlayOpenSound = false },false);
                    }
                    else
                    {
                        animator_tailDoor.SetBool(Constants.ANIMTOAR_TAIL_DOOR_OPEN, true);
                        EventDispatcher.Publish(new PlayDoorSoundEvent(){ IsPlayOpenSound = true },false);
                    }
                    _mazdaData.IsTailDoorOpen = !_mazdaData.IsTailDoorOpen;
                    break;
                
                default:
                    #if UNITY_EDITOR
                    Debug.Log("Default - Unknown state: " + e.DoorName);
                    #endif
                    break;
            }
        }
    }
}
