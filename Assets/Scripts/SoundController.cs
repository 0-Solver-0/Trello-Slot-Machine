using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{

    [SerializeField]
    private float volWheel = .5f;
    [SerializeField]
    private float volWin = 1.0f;
    [SerializeField]
    private float volCheckWin = 1.0f;
    [SerializeField]
    private float volLose = 1.0f;
    [SerializeField]
    private float volPressButton = 1.0f;

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

    public void WheelSoundPay()
    {
        ASource.PlayOneShot(WheelSound, volWheel);
    }

    public void WheelSoundStop()
    {
        ASource.Stop();
    }

    public void WinSoundSoundPay()
    {
        ASource.PlayOneShot(WinSound, volWin);
    }
    public void LoselSoundPay()
    {
        ASource.PlayOneShot(LoselSound, volLose);
    }
    public void PressButtonSoundPay()
    {
        ASource.PlayOneShot(PressButtonSound, volPressButton);
    }
    public void StopButtonSoundPay()
    {
        ASource.PlayOneShot(StopButtonSound, volPressButton);
    }
    public void CheckWinSoundPay()
    {
        ASource.PlayOneShot(CheckWinSound, volCheckWin);
    }
}
