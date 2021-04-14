using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class IconDrag : MonoBehaviour
{
    public GameObject choiceBubble;
    public string finalChoice;
    private bool isMoving;
    public bool locked;
    private string charName;
    private float startPosX;
    private float startPosY;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.localPosition;
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
        if (choiceBubble == null)
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

        if (choiceBubble == null)
        {
            this.transform.localPosition = startPosition;
        }
        else
        {

            //check if sprite is close enough and has collided with the choice box, and make sure the choice is actually a sprite
            if (Mathf.Abs(this.transform.localPosition.x - choiceBubble.transform.localPosition.x) <= 2.0f &&
               Mathf.Abs(this.transform.localPosition.y - choiceBubble.transform.localPosition.y) <= 2.0f && (finalChoice != null))
               //&& (charName.Contains("Sprite")))
            {
                this.transform.position = new Vector3(choiceBubble.transform.localPosition.x, choiceBubble.transform.localPosition.y + .3f,
                    this.transform.localPosition.z);

                locked = true;

                //Debug.Log("snap");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("collision detected");

        choiceBubble = collider.gameObject;

        //put the choice in string form and assign it to finalChoice
        charName = choiceBubble.name;
        //chop off the "Sprite" portion of the object so we are just left with the character
        finalChoice = charName.Substring(0, name.Length - 6);
    }
}
