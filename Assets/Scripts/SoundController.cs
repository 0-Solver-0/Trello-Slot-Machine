using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    
    private AudioSource ASource;
    public AudioClip WheelSound;
    public AudioClip WinSound;
    public AudioClip LoselSound;
    public AudioClip PressButtonSound;
    public AudioClip StopButtonSound;
    public AudioClip CheckWinSound;
   
    public static SoundController getInstance;

    void Awake()
    {
        ASource = GetComponent<AudioSource>();
        if (getInstance == null)
            getInstance = this;
    }
    void Start()
    {
        // move to mainCamera
       // SoundController.getInstance.BackgroundSoundPay();
    }

    public void WheelSoundPay() {
        float vol = Random.Range(volLowRange, volHighRange);
        ASource.PlayOneShot(WheelSound, vol);
    }
    public void WinSoundSoundPay() {
        float vol = Random.Range(volLowRange, volHighRange);
        ASource.PlayOneShot(WinSound,vol);
    }
    public void LoselSoundPay() {
        float vol = Random.Range(volLowRange, volHighRange);
        ASource.PlayOneShot(LoselSound,vol);
    }
    public void PressButtonSoundPay() {
        float vol = Random.Range(volLowRange, volHighRange);
        ASource.PlayOneShot(PressButtonSound,vol);
    }
    public void StopButtonSoundPay() {
        float vol = Random.Range(volLowRange, volHighRange);
        ASource.PlayOneShot(StopButtonSound,vol);
    }
    public void CheckWinSoundPay()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        ASource.PlayOneShot(CheckWinSound,vol);
    }
}
