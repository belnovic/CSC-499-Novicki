using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSprite : MonoBehaviour
{

    private Object[] whiteFemSprites = new Object[22];
    private Object[] whiteMaleSprites = new Object[19];
    private Object[] blackFemSprites = new Object[36];
    private Object[] blackMaleSprites = new Object[16];
    private Object[] hispFemSprites = new Object[12];
    private Object[] hispMaleSprites = new Object[10];
    private Object[] etcFemSprites = new Object[15];
    private Object[] etcMaleSprites = new Object[15];
    public GameObject[] spriteArray = new GameObject[8];


    // Start is called before the first frame update
    void Start()
    {

        //Go through each organized sprite array and assign new sprites
        ChangeSprite(spriteArray[0], whiteFemSprites);
        ChangeSprite(spriteArray[1], whiteMaleSprites);
        ChangeSprite(spriteArray[2], blackFemSprites);
        ChangeSprite(spriteArray[3], blackMaleSprites);
        ChangeSprite(spriteArray[4], hispFemSprites);
        ChangeSprite(spriteArray[5], hispMaleSprites);
        ChangeSprite(spriteArray[6], etcFemSprites);
        ChangeSprite(spriteArray[7], etcMaleSprites);

    }

    private void ChangeSprite(GameObject baseSprite, Object[] newSprites)
    {
        int randInt = Random.Range(0, newSprites.Length - 1);
        //Assign the face sprites (newSprites) to each sprite in the spriteArray
        baseSprite.GetComponent<SpriteRenderer>().sprite = Instantiate(newSprites[randInt]) as Sprite;
    }

    private void Awake()
    {
        //Load each folder of face images into their respective sprite arrays
        whiteFemSprites = Resources.LoadAll("Sprites/Resized Face Images/White faces/Women", typeof(Sprite));
        whiteMaleSprites = Resources.LoadAll("Sprites/Resized Face Images/White faces/Men", typeof(Sprite));
        blackFemSprites = Resources.LoadAll("Sprites/Resized Face Images/Black faces/Women", typeof(Sprite));
        blackMaleSprites = Resources.LoadAll("Sprites/Resized Face Images/Black faces/Men", typeof(Sprite));
        hispFemSprites = Resources.LoadAll("Sprites/Resized Face Images/Hispanic faces/Women", typeof(Sprite));
        hispMaleSprites = Resources.LoadAll("Sprites/Resized Face Images/Hispanic faces/Men", typeof(Sprite));
        etcFemSprites = Resources.LoadAll("Sprites/Resized Face Images/Other faces/Women", typeof(Sprite));
        etcMaleSprites = Resources.LoadAll("Sprites/Resized Face Images/Other faces/Men", typeof(Sprite));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
