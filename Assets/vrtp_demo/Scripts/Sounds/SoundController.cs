using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using vrtp_demo.Scripts.Common.Events;
using vrtp_demo.Sounds.Events;

public class SoundController : MonoBehaviour
{

    [SerializeField] private AudioSource openDoorAudioSource;
    [SerializeField] private AudioSource closeDoorAudioSource;
    
    private void Start()
    {
        EventDispatcher.Receive<PlayDoorSoundEvent>()
            .Subscribe(PlayDoorSoundEvent);
    }

    private void PlayDoorSoundEvent(PlayDoorSoundEvent e)
    {
        if (e.IsPlayOpenSound)
        {
            openDoorAudioSource.Play();
        }
        else
        {
            closeDoorAudioSource.Play();
        }
    }
}
