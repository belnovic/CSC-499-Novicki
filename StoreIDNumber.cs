using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreIDNumber : MonoBehaviour
{
    public InputField iField;
    public Button button;
    public string IDNum;

    // Start is called before the first frame update
    void Start()
    {
        //check if the button is null - this prevents error messages once the new scene loads
        if (button != null)
        {
            //hide the object
            button.GetComponent<Image>().enabled = false;
            button.GetComponentInChildren<Text>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (iField != null)
        {
            //check if user has started to enter
            if (iField.text.Length > 0)
            {
                //show the object
                button.GetComponent<Image>().enabled = true;
                button.GetComponentInChildren<Text>().enabled = true;
            }
        }
    }

    public void OnButtonPress()
    {
        if (button != null)
        {
            //store the ID number
            IDNum = iField.text;
            Debug.Log(IDNum);

            //load into the first scene, experiment 1
            SceneManager.LoadScene("Exp 1");
        }
    }
}
