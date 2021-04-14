using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public bool isClicked;
    public string fileName = "/Results.txt";
    public RandomizeSprite random;
    private string text;
    private GameObject[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        //hide the next button out of view
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);

        //set the is clicked boolean to false to start with
        isClicked = false;

        //initialize text to last experiment's results
        text = GameObject.Find("Storage Exp 1").GetComponent<StoreExp1>().text;
        Debug.Log(text);

    }

    // Update is called once per frame
    void Update()
    {
        //if the mouse is clicked at any point, show the button
        if (Input.GetMouseButtonDown(0))
        {
            this.transform.localScale = new Vector3(0.3491504f, 0.3211612f, 1.0f);
        }
    }

    public void OnMouseDown()
    {
        //exit application if button is clicked and switch isClicked to true
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("exit");
            isClicked = true;
            LogFile();
            Application.Quit();
        }
    }

    // Creates a log file that holds the user's game choices
    private void LogFile()
    {
        //make sure the file doesn't already exist
        if (File.Exists(fileName))
        {
            Debug.Log(fileName + " already exists.");
            return;
        }

        //generate the text for the result
        spriteArray = random.GetComponent<RandomizeSprite>().spriteArray;
        text += "\n" + "\n" + "EXPERIMENT 2 RESULTS:";

        //loop through spriteArray to get each sprite's assignment choice
        foreach (GameObject sprite in spriteArray)
        {
            GameObject thoughtBubble = sprite.GetComponent<Character2Assign>().thoughtBubble;
            string choice = thoughtBubble.GetComponent<BubbleAssign>().jobChoiceName;
            text += "\n" + sprite.name + ": " + choice;
        }

        //specify directory
        string d = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        System.IO.Directory.CreateDirectory(d);
        //create file
        fileName = d + fileName;
        var sr = File.CreateText(fileName);
        
        sr.WriteLine(text);

        //write to the file the results of experiment 2
        sr.Close();
    }
}
