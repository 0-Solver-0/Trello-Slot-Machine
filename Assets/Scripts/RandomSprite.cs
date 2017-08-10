using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//Resources.Load<Sprite>("Sprites/Items/" + GL_SlugPath + "/" + Items[i].Slug);
public class RandomSprite : MonoBehaviour {

    public bool start;
    public bool BingoWinGold;
    public bool GameCheck;
    public bool BingoWinSilver;
    public bool BingoWinBronze;
    public int TentativeCount = 9;
    public bool IsGameEnd;

  
    // Use this for initialization
	void Start () {
        start = false;
        BingoWinGold = false;
        BingoWinSilver = false;
        BingoWinBronze = false;
        IsGameEnd = false;
        GameCheck = false;
        GameObjects.getInstance.TentativeSlot.GetComponent<SpriteRenderer>().sprite
        = GameObjects.getInstance.Tentative[TentativeCount];
	}

    public bool IsStart() {

        return start;
    }

    public void StartGame()
    {
        if (GameCheck)
            return;

        if (BingoWinGold)
        {
            StopGame();
            IsGameEnd = true;
            TentativeCount = 0;
        }
        if (BingoWinSilver)
        {
            StopGame();
            IsGameEnd = true;
            TentativeCount = 0;
        }
        if (BingoWinBronze)
        {
            StopGame();
            IsGameEnd = true;
            TentativeCount = 0;
        }
        if (TentativeCount == 0)
        {
            IsGameEnd = true;
            StopGame();
            SoundController.getInstance.LoselSoundPay();
        }
        else
        {
            // Game();
            start = true;
            TentativeCount -= 1;
            GameObjects.getInstance.TentativeSlot.GetComponent<SpriteRenderer>().sprite
                            = GameObjects.getInstance.Tentative[TentativeCount];
        }        

    }
    public void StopGame()
    {
        // check game
        start = false;
    }
    public IEnumerator Print()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < GameObjects.getInstance.Grids.Count; i++)
        {
            Debug.Log(GameObjects.getInstance.Grids[i].GetComponent<SpriteRenderer>().sprite.name);
            if ((i + 1) % 3 == 0)
                Debug.Log("-----------");            
        }        
    }
    // win is 1,2,3
    public IEnumerator CheckWinGame()
    {
        yield return new WaitForSeconds(.3f + (GameObjects.getInstance.Sprites.Count * Time.deltaTime));
        
        int isWinCountOne = 0;
        int isWinCountTwo = 0;
        int isWinCountThree = 0;
        BingoWinGold = false;
        BingoWinSilver = false;
        BingoWinBronze = false;
        string iconName = "icon_";
        string CurrenticonName = "";

        for (int i = 0; i < GameObjects.getInstance.Grids.Count; i++)
        {
            SoundController.getInstance.CheckWinSoundPay();
            CurrenticonName = GameObjects.getInstance.Grids[i].GetComponent<SpriteRenderer>().sprite.name;
            
            if (CurrenticonName.Equals(iconName + 1))
                isWinCountOne += 1;
            if (CurrenticonName.Equals(iconName + 2))
                isWinCountTwo += 1;
            if (CurrenticonName.Equals(iconName + 3))
                isWinCountThree += 1;

            // new ligne
            if ((i + 1) % 3 == 0) {
                if (isWinCountOne == 3)
                    BingoWinGold = true;

                if (isWinCountTwo == 3)
                    BingoWinSilver = true;

                if (isWinCountThree == 3)
                    BingoWinBronze = true;
                    
                isWinCountOne = 0;
                isWinCountTwo = 0;
                isWinCountThree = 0;
            }
        }
        if (BingoWinBronze || BingoWinGold || BingoWinSilver)
        {
            IsGameEnd = true;
            SoundController.getInstance.WinSoundSoundPay();
            string nameFile = "";
            if (BingoWinBronze)
            {
                nameFile = "BingoWinBronze";
                GameObjects.getInstance.BigWinBR.SetActive(true);
            }
            if (BingoWinSilver)
            {
                nameFile = "BingoWinSilver";
                GameObjects.getInstance.BigWinBR.SetActive(false);
                GameObjects.getInstance.BigWinSI.SetActive(true);
            }
            if (BingoWinGold)
            {
                nameFile = "BingoWinGold";
                GameObjects.getInstance.BigWinBR.SetActive(false);
                GameObjects.getInstance.BigWinSI.SetActive(false);
                GameObjects.getInstance.BigWinGO.SetActive(true);
            }
            StartCoroutine(WinWindows(true, 4f, nameFile));
        }
        GameCheck = false;
    }
    private IEnumerator WinWindows(bool ac, float d, string nameFile)
    {
        int prize = 0;
        if (BingoWinGold)
            prize = 1;
        if (BingoWinSilver)
            prize = 2;
        if (BingoWinBronze)
            prize = 3;


        Application.ExternalCall("PlayerWin", "id:" + MyObject.IdMembre + ";prize:" + prize);
       // Application.CaptureScreenshot(Application.streamingAssetsPath+nameFile+".png");
        yield return new WaitForSeconds(d);
        GameObjects.getInstance.BigWinBR.SetActive(false);
        GameObjects.getInstance.BigWinSI.SetActive(false);
        GameObjects.getInstance.BigWinGO.SetActive(false);
    }


}


