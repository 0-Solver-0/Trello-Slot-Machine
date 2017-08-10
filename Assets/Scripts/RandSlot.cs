using UnityEngine;
using System.Collections;

public class RandSlot : MonoBehaviour
{
    [SerializeField]
    private RandomSprite Generator;
    
    void Update()
    {
        if (IsStart())
        {
            StartCoroutine(GetSprite(gameObject));
        }
    }

    int render = -1;
    private IEnumerator GetSprite(GameObject go)
    {
        render = Generateur.randScore(0, GameObjects.getInstance.Sprites.Count);//GameObjects.getInstance.Sprites.Count
        go.GetComponent<SpriteRenderer>().sprite = GameObjects.getInstance.Sprites[render];
       // go.transform.Rotate(180f, 0,0);
        yield return new WaitForSeconds(GameObjects.getInstance.Sprites.Count * Time.deltaTime);   
    }
    bool IsStart()
    {
        return Generator.IsStart();
    }
}
