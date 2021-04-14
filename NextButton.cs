using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public string fileName = "/Results1.txt";
    public GameObject random;
    public string text;
    public bool done;
    private GameObject[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        //hide the next button out of view
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);

        done = false;

    }

    // Update is called once per frame
    void Update()
    {
        //if the mouse is clicked at any point, show the button
        if (Input.GetMouseButtonDown(0))
        {
            this.transform.localScale = new Vector3(0.3183661f, 0.2318133f, 1.0f);
        }
    }

    public void OnMouseDown()
    {
        //Update results string and advance to the next scene if it is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //log the results to the experiment 1 file
            GenerateText();

            //set done to true
            done = true;

            //hide the button
            transform.localScale = new Vector3(0.0f, 0.0f, -1.0f);

            //load into experiment 2
            SceneManager.LoadScene("Exp 2");
        }
    }

    private void GenerateText()
    {
        //make sure the file doesn't exist already
        if (File.Exists(fileName))
        {
            Debug.Log(fileName + " already exists.");
            return;
        }

        //grab the user's ID number that was stored in the intro
        string IDNum = GameObject.Find("Storage Intro").GetComponent<StoreIDNumber>().IDNum;

        //generate the text for the result
        spriteArray = random.GetComponent<RandomizeSprite>().spriteArray;
        text = IDNum + "\n" + "\n" + "EXPERIMENT 1 RESULTS:";

        //loop through spriteArray to get each sprite's assignment choice
        foreach (GameObject sprite in spriteArray)
        {

            text += "\n" + sprite.name + ": ";     //example line = 'White Female: '
            List<string> choices = sprite.GetComponent<Character1Drag>().choices;

            //loop through each individual sprite's choice list
            foreach (string choice in choices)
            {
                text += choice + ". ";     //example line = 'White Female: Doctor. Chemist. '
            }

        }
    }
}
