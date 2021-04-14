using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BubbleAssign : MonoBehaviour

{
    public GameObject choiceIcon;
    public GameObject doneButton;
    public string jobChoiceName;
    public string spriteName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("collision detected");

        //the collider is the job icon choice
        choiceIcon = collider.gameObject;

        //put the choice in string form and assign it to finalChoice
        string name = choiceIcon.name;
        //chop off the "Icon" portion of the object so we are just left with the profession
        jobChoiceName = name.Substring(0, name.Length - 4);
    }

    
}
