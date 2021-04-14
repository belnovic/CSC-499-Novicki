using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1Drag : MonoBehaviour
{
    public GameObject choiceBox;
    public string finalChoice;
    public List<String> choices;
    private Vector3 startPosition;
    private bool isMoving;
    //private bool done;
    private float startPosX;
    private float startPosY;
    private Vector3 centerPosition;

    // Start is called before the first frame update
    void Start()
    {
        //done = false;
        startPosition = this.transform.localPosition;
        centerPosition = new Vector3(0.0f, 0.0f, 1.0f);
        choices = new List<String>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY,
                this.gameObject.transform.localPosition.z);
        }
        if (choiceBox == null)
        {
            //done = false;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isMoving = true;
        }
    }

    private void OnMouseUp()
    {
        isMoving = false;

        //snap the sprite to its original location if it doesn't come into contact with anything, or if it contacts a sprite
        if (choiceBox == null || choiceBox.name.Contains("Sprite"))
        {
            this.transform.localPosition = startPosition;
        }
        else
        {

            //check if sprite is close enough and has collided with the choice box
            if (Mathf.Abs(this.transform.localPosition.x - choiceBox.transform.localPosition.x) <= 2.0f &&
               Mathf.Abs(this.transform.localPosition.y - choiceBox.transform.localPosition.y) <= 2.0f && (finalChoice != null))
            {
                this.transform.localPosition = new Vector3(choiceBox.transform.position.x, choiceBox.transform.position.y,
                    this.transform.localPosition.z);

                this.transform.localPosition = startPosition;
                //done = true;

                //append the choice to the list of choices
                choices.Add(finalChoice);

                //clear the choice name
                finalChoice = null;
                
                //increase count
                SpawnIcons.count += 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("collision detected");

        choiceBox = collider.gameObject;

        //check that the collider is a box instead of another character or something
        if (choiceBox.name.Length > 11)
        {
            //put the choice in string form and assign it to finalChoice
            string name = choiceBox.name;
            //chop off the "Icon(Clone)" portion of the object so we are just left with the profession
            finalChoice = name.Substring(0, name.Length - 11);
        }
    }

}
