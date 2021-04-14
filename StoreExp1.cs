using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreExp1 : MonoBehaviour
{
    public GameObject nextButton;
    public string text;

    // Update is called once per frame
    void Update()
    {
        //make sure the next button has not been destroyed - i.e. the scene hasn't advanced
        if (nextButton != null)
        {
            //if scene 1 is done, then store the text info
            if (nextButton.GetComponent<NextButton>().done)
            {
                text = nextButton.GetComponent<NextButton>().text;
            }
        }
    }
}
