using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource notificationSound;

    [Header("Random Sounds")]
    [SerializeField] AudioClip[] clips;
    //[SerializeField] private AudioSource megaphoneSound;
    //[SerializeField] private AudioSource whistleSound;
    //[SerializeField] private AudioSource Sound;


    public void PlayButtonSound()
    {
        buttonSound.Play();
    }

    public void PlayNotificationSound()
    {
        notificationSound.Play();
    }
}
