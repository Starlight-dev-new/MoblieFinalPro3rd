using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("---------Audio Source------------")]

    public AudioSource music;
    public AudioSource SFX;
    [Header ("--------Audio REF-----------")]
    public AudioClip backgroud ;
    public AudioClip filp;
    public AudioClip openCam ;
    public AudioClip changCamera ;
    public AudioClip lockdoor;
    public AudioClip doorClick;
    public AudioClip ChangBattery;

    void Start()
    {
         music.clip = backgroud;
         music.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
    

}
