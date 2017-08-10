using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjects : MonoBehaviour {

    public static GameObjects getInstance;

    void Awake()
    {
        if (getInstance == null)
            getInstance = this;
    }
    void Start()
    {
        GameObjects.getInstance.BigWinGO.SetActive(false);
        GameObjects.getInstance.BigWinSI.SetActive(false);
        GameObjects.getInstance.BigWinBR.SetActive(false);
    }
    public List<Sprite> Tentative = new List<Sprite>();
    public List<Sprite> Sprites = new List<Sprite>();
    public List<GameObject> Grids = new List<GameObject>();

    public GameObject TentativeSlot;    
    public GameObject BigWinGO;
    public GameObject BigWinSI;
    public GameObject BigWinBR;

}
