using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource notificationSound;
    //[SerializeField] private AudioSource 


    public void PlayButtonSound()
    {
        buttonSound.Play();
    }

    public void PlayNotificationSound()
    {
        notificationSound.Play();
    }
}
