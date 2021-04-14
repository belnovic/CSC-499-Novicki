using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleIconPos : MonoBehaviour
{

    public GameObject icon1, icon2, icon3, icon4, icon5, icon6, icon7, icon8;
    private GameObject[] icons;
    private Vector3[] positions;

    private void Awake()
    {
        //populate possible positions and shuffle them randomly
        positions = new Vector3[8] {new Vector3(-8.9f, 3.5f, 1.0f), new Vector3(-6.35f, 3.5f, 1.0f), new Vector3(-3.9f, 3.5f, 1.0f), 
                                    new Vector3(-1.4f, 3.5f, 1.0f), new Vector3(0.9f, 3.5f, 1.0f), new Vector3(3.4f, 3.5f, 1.0f),
                                    new Vector3(5.8f, 3.5f, 1.0f), new Vector3(8.43f, 3.5f, 1.0f)};
        Shuffle(positions);
        icons = new GameObject[8] { icon1, icon2, icon3, icon4, icon5, icon6, icon7, icon8 };
        
        //assign each icon to new position in positions
        for (int i = 0; i < positions.Length; i++)
        {
            icons[i].transform.position = positions[i];
            //Debug.Log(icons[i].transform.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*shuffles array with fisher-yates method*/
    private void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        System.Random random = new System.Random();
        for (int i = 0; i < n; i++)
        {
            int r = i + random.Next(n - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
}
