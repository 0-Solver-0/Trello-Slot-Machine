using UnityEngine;
using System.Collections;

public class StartClik : MonoBehaviour {

	// Use this for initialization
    [SerializeField]
    private Sprite SpriteInactive;
    [SerializeField]
    private Sprite SpriteActive;
    [SerializeField]
    private RandomSprite Generator;
    [SerializeField]
    private bool IsStart = false;


	void Start () {
        IsStart = Generator.IsStart();
	}
    void OnMouseDown() {

        if (Generator.GameCheck)
            return;
       
        IsStart = Generator.IsStart();
        if (Input.GetMouseButtonDown(0))
        {
            if (IsStart)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteActive;

                SoundController.getInstance.StopButtonSoundPay();
                Generator.StopGame();
                Generator.GameCheck = true;
                StartCoroutine(Generator.CheckWinGame());
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteInactive;
                SoundController.getInstance.PressButtonSoundPay();
                Generator.StartGame();
            }
        }
    
    }
}
