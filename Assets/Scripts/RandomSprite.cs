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
    public List<Sprite> Sprites =new List<Sprite>();
    public List<GameObject> Grids = new List<GameObject>();

    public int TentativeAutorised = 8;
    public int TentativeCount = -1;
    public List<Sprite> Tentative = new List<Sprite>();
    public GameObject TentativeSlot;
    public GameObject TentativeAutorisedSlot;
    public GameObject BigWinGO;
  
    // Use this for initialization
	void Start () {
        start = false;
        BingoWinGold = false;
        BingoWinSilver = false;
        BingoWinBronze = false;
        GameCheck = false;
        TentativeAutorisedSlot.GetComponent<SpriteRenderer>().sprite 
                = Tentative[TentativeAutorised];
        BigWinGO.SetActive(false);
	}
    
	// Update is called once per frame
	void Update () {

        if (IsStart())
        {
            SoundController.getInstance.WheelSoundPay();
            
            for (int j = 0; j < Grids.Count; j++)
            {
            
                StartCoroutine(GetSprite(Grids[j]));
            }
        }
	}
    int render = -1;

    private IEnumerator GetSprite(GameObject go)
    {
      
        for (int i = 0; i < Sprites.Count; i++)
        {
            render = Generateur.randScore(0, Sprites.Count);
            go.GetComponent<SpriteRenderer>().sprite = Sprites[render];     
            // 9arabte
           // Debug.Log(i * 3f * Time.deltaTime);
            if (i == Sprites.Count-1)
              yield return new WaitForSeconds(.4f);
            else
                yield return new WaitForSeconds(.025f);
        }        
    }

    public bool IsStart() {

        return start;
    }

    public void StartGame()
    {
        if (GameCheck)
            return;

        if(BigWinGO.activeSelf)
            BigWinGO.SetActive(false);

        if (BingoWinGold)
        {
            StopGame();
            TentativeCount = TentativeAutorised;
        }
        if (BingoWinSilver)
        {
            StopGame();
            TentativeCount = TentativeAutorised;
        }
        if (BingoWinBronze)
        {
            StopGame();
            TentativeCount = TentativeAutorised;
        }
        if (TentativeCount == TentativeAutorised)
            StopGame();
        else
        {
            start = true;
            TentativeCount += 1;
            TentativeSlot.GetComponent<SpriteRenderer>().sprite
                            = Tentative[TentativeCount];
        }
        

    }
    public void StopGame()
    {
        start = false;
    }
    public IEnumerator Print()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < Grids.Count; i++)
        {
            Debug.Log(Grids[i].GetComponent<SpriteRenderer>().sprite.name);
            if ((i + 1) % 3 == 0)
                Debug.Log("-----------");            
        }        
    }
    // win is 1,2,3
    public IEnumerator CheckWinGame()
    {
        yield return new WaitForSeconds(.8f);
        Debug.Log("CheckWinGame"); 
        
        int isWinCountOne = 0;
        int isWinCountTwo = 0;
        int isWinCountThree = 0;
        BingoWinGold = false;
        BingoWinSilver = false;
        BingoWinBronze = false;
        string iconName = "icon_";
        string CurrenticonName = "";

        for (int i = 0; i < Grids.Count; i++)
        {
            SoundController.getInstance.CheckWinSoundPay();
            CurrenticonName=Grids[i].GetComponent<SpriteRenderer>().sprite.name;
            if (CurrenticonName.Equals(iconName + 1)
                || CurrenticonName.Equals(iconName + 2)
                || CurrenticonName.Equals(iconName + 3))
            {
               if (CurrenticonName.Equals(iconName + 1))
                   isWinCountOne += 1;
               if (CurrenticonName.Equals(iconName + 2))
                   isWinCountTwo += 1;
               if (CurrenticonName.Equals(iconName + 3))
                   isWinCountThree += 1;

            }
            // new ligne
            // to do fix error
            if ((i + 1) % 3 == 0) {
                if (isWinCountOne == 3)
                    BingoWinGold = true;
                else
                    isWinCountOne = 0;
                if (isWinCountTwo == 3)
                    BingoWinSilver = true;
                else
                    isWinCountTwo = 0;
                if (isWinCountThree == 3)
                    BingoWinBronze = true;
                else
                    isWinCountThree = 0;
            }
        }
        if (BingoWinBronze || BingoWinGold || BingoWinSilver)
        {
            string nameFile = "";
            if (BingoWinBronze)
                nameFile = "BingoWinBronze";
            if (BingoWinSilver)
                nameFile = "BingoWinSilver";
            if (BingoWinGold)
                nameFile = "BingoWinGold";
            
            Application.CaptureScreenshot(Application.streamingAssetsPath+"/BingoWinScreen/" + nameFile + ".png");
            SoundController.getInstance.WinSoundSoundPay();
            
            BigWinGO.SetActive(true);
        }
        else
            SoundController.getInstance.LoselSoundPay();
        
        Debug.Log("BingoWinGold=" + BingoWinGold + " BingoWinSilver=" + BingoWinSilver + " BingoWinBronze=" + BingoWinBronze); 
        GameCheck = false;
    }
}
