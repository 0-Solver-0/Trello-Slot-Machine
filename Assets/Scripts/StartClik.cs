using UnityEngine;
using System.Collections;

public class StartClik : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private Sprite SpriteInactive;
    [SerializeField]
    private Sprite SpriteActive;
    [SerializeField]
    private RandomSprite Generator;
    [SerializeField]
    private bool IsStart = false;


    void Start()
    {
        IsStart = Generator.IsStart();
    }    
    void OnMouseDown()
    {

        //Debug.Log("IsGameEnd=" + Generator.IsGameEnd + " Generator.GameCheck=" + Generator.GameCheck ); 
        if (Generator.IsGameEnd)
            return;
        if (Generator.GameCheck)
            return;

        IsStart = Generator.IsStart();
        if (Generator.TentativeCount == 0 && !IsStart)
            return;

        if (IsStart)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteActive;

            SoundController.getInstance.StopButtonSoundPay();
            //stop
            SoundController.getInstance.WheelSoundStop();
            Generator.StopGame();
            Generator.GameCheck = true;
            StartCoroutine(Generator.CheckWinGame());
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteInactive;
            SoundController.getInstance.PressButtonSoundPay();
            StartCoroutine(LoopWheelPlay());
            Generator.GameCheck = false;
            Generator.StartGame();
        }
    }

    IEnumerator LoopWheelPlay() {

        //if (Generator.TentativeCount == 0 && !IsStart)
        //{
        //    SoundController.getInstance.WheelSoundStop();
            
        //}
        while (!IsStart && Generator.TentativeCount!=0)
        {
         SoundController.getInstance.WheelSoundPay();
         yield return new WaitForSeconds(6.6f);
        }
    }
}
