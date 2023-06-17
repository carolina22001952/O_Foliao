using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource notificationSound;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip vinilMusic;
    [SerializeField] private AudioClip celeiroMusic;
    [SerializeField] private AudioClip skadiMusic;
    [SerializeField] private AudioClip cebolaMusic;
    [SerializeField] private AudioClip batataMusic;
    [SerializeField] private AudioClip benchMusic;
    [SerializeField] private AudioClip casaMusic;

    [Header("Random Sounds")]
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioClip[] clipsVoices;

    private int clipIndex;
    [SerializeField] private AudioSource audioSource;

    private AudioClip currentAudio;

    void Start()
    {
        StartCoroutine(PlayRandomSound());
        StartCoroutine(PlayRandomSound());
        StartCoroutine(PlayRandomVoice());
    }

    public AudioClip GetCurrentAudioClip()
    {
        return currentAudio;
    }

    public void ChooseMusic(AudioClip clip)
    {
        Debug.Log(clip.name);
        switch(clip.name)
        {
            case "MUSICA 4 EFEITO FORA DA DISCO 1":
                Debug.Log("Adeus");
                PlayCebolaMusic();
                break;
            case "MUSICA 2 EFEITO FORA DA DISCO 1":
                Debug.Log("batata");
                PlayBatataMusic();
                break;
            case "asdasd":
                PlayVinilMusic();
                break;
            case "wqe":
                PlayCeleiroMusic();
                break;
            case "zxczxczcx":
                PlaySkadiMusic();
                break;
            case "zxczxcas":
                PlayBenchMusic();
                break;
            case "zxx":
                PlayCasaMusic();
                break;
            
        }
    }

    public void PlayButtonSound()
    {
        buttonSound.Play();
    }

    public void PlayNotificationSound()
    {
        notificationSound.Play();
    }

    public void PlayVinilMusic()
    {
        musicSource.clip = vinilMusic;
        musicSource.Play();
        currentAudio = vinilMusic;
    }

    public void PlayCeleiroMusic()
    {
        musicSource.clip = celeiroMusic;
        musicSource.Play();
        currentAudio = celeiroMusic;
    }

    public void PlaySkadiMusic()
    {
        musicSource.clip = skadiMusic;
        musicSource.Play();
        currentAudio = skadiMusic;
    }

    public void PlayCebolaMusic()
    {
        musicSource.clip = cebolaMusic;
        musicSource.Play();
        currentAudio = cebolaMusic;
    }

    public void PlayBatataMusic()
    {
        musicSource.clip = batataMusic;
        musicSource.Play();
        currentAudio = batataMusic;
    }

    public void PlayBenchMusic()
    {
        musicSource.clip = benchMusic;
        musicSource.Play();
        currentAudio = benchMusic;
    }

    public void PlayCasaMusic()
    {
        musicSource.clip = casaMusic;
        musicSource.Play();
        currentAudio = casaMusic;
    }

    IEnumerator PlayRandomSound()
    {
        yield return new WaitForSeconds(Random.Range(3f, 6f));

        clipIndex = Random.Range(0, clips.Length);
        audioSource.PlayOneShot(clips[clipIndex], 1f);

        yield return new WaitForSeconds(clips[clipIndex].length);
        StartCoroutine(PlayRandomSound());
    }

    IEnumerator PlayRandomVoice()
    {
        yield return new WaitForSeconds(Random.Range(3f, 6f));

        clipIndex = Random.Range(0, clipsVoices.Length);
        audioSource.PlayOneShot(clipsVoices[clipIndex], 1f);

        yield return new WaitForSeconds(clipsVoices[clipIndex].length);
        StartCoroutine(PlayRandomVoice());
    }
}
