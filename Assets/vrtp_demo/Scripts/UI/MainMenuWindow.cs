﻿using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using vrtp_demo.Scripts.Common.Events;
using vrtp_demo.Scripts.DoorController.Events;
using vrtp_demo.Scripts.UI.Events;
using vrtp_demo.Scripts.UI.ScriptableObjects;

namespace vrtp_demo.Scripts.UI
{
    public class MainMenuWindow : MonoBehaviour
    {
        [Header("Color Picker Button")]
        [SerializeField] private Button colorPickerWindow;
        
        [Header("Door Buttons")]
        [SerializeField] private Button frontLeftDoorButton;
        [SerializeField] private Button frontRightDoorButton;
        [SerializeField] private Button rearLeftDoorButton;
        [SerializeField] private Button rearRightDoorButton;
        [SerializeField] private Button tailDoorButton;
        
        [Space]
        [SerializeField] private CanvasGroup colorPickerGroupBtn;

        [Header("Light Slider Controller")]
        [SerializeField] private Slider lightSlider;
        
        [Header("Data")]
        [SerializeField] private WindowDataStatus _windowDataStatus;

        
        private void Start()
        {
            colorPickerWindow.onClick.AddListener(OnClickColorPickerButton);
            
            frontLeftDoorButton.onClick.AddListener(OnClickFrontLeftDoorButton);
            frontRightDoorButton.onClick.AddListener(OnClickFrontRightDoorButton);
            rearLeftDoorButton.onClick.AddListener(OnClickRearLeftDoorButton);
            rearRightDoorButton.onClick.AddListener(OnClickRearRightDoorButton);
            tailDoorButton.onClick.AddListener(OnClickTailDoorButton);
            
            lightSlider.onValueChanged.AddListener(OnLightIntensityChangeSlider);
            lightSlider.value = 1.0f;
        }

        private void OnLightIntensityChangeSlider(float arg0)
        {
            //SetValue to WindowStatus 
            _windowDataStatus.SetValue(arg0);
        }
        
        //When Window spawns
        private void OnEnable()
        {
            //Set as first under Canvas
            gameObject.transform.SetAsFirstSibling();
            
            //Set WindowStatus
            _windowDataStatus.Window = WindowDataStatus.WindowStatus.MainView;
            
            //Set aplha 0 for all buttons
            colorPickerGroupBtn.alpha = 0;
            
            //Start smooth Tween for show-up buttons
            colorPickerGroupBtn.DOFade(1, 1f);
        }

        //Button Events
        private void OnClickTailDoorButton()
        {
            EventDispatcher.Publish(new OpenDoorEvent() {DoorName = Constants.TAIL_DOOR}, false);
        }

        private void OnClickRearRightDoorButton()
        {
            EventDispatcher.Publish(new OpenDoorEvent() {DoorName = Constants.REAR_RIGHT_DOOR}, false);
        }

        private void OnClickRearLeftDoorButton()
        {
            EventDispatcher.Publish(new OpenDoorEvent() {DoorName = Constants.REAR_LEFT_DOOR}, false);
        }

        private void OnClickFrontRightDoorButton()
        {
            EventDispatcher.Publish(new OpenDoorEvent() {DoorName = Constants.FRONT_RIGHT_DOOR}, false);
        }

        private void OnClickFrontLeftDoorButton()
        {
           EventDispatcher.Publish(new OpenDoorEvent() {DoorName = Constants.FRONT_LEFT_DOOR}, false);
        }

        private void OnClickColorPickerButton()
        {
            EventDispatcher.Publish(new RequestColorPickerWindowEvent(), false);
            Destroy(gameObject);
        }
        
    }
}
