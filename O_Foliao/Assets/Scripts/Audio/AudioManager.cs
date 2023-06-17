using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource notificationSound;

    [Header("Random Sounds")]
    [SerializeField] AudioClip[] clips;

    private int clipIndex;
    [SerializeField] private AudioSource audioSource;
    //private bool audioPlaying = false;

    void Start()
    {
        StartCoroutine(PlayRandomSound());
    }

    public void PlayButtonSound()
    {
        buttonSound.Play();
    }

    public void PlayNotificationSound()
    {
        notificationSound.Play();
    }

    IEnumerator PlayRandomSound()
    {
        yield return new WaitForSeconds(Random.Range(3f, 6f));

        clipIndex = Random.Range(0, clips.Length);
        audioSource.PlayOneShot(clips[clipIndex], 1f);

        yield return new WaitForSeconds(clips[clipIndex].length);
        StartCoroutine(PlayRandomSound());
    }
}
