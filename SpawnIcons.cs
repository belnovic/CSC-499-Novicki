using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class SpawnIcons : MonoBehaviour
{
    public GameObject lawyerPrefab, writerPrefab, teacherPrefab, doctorPrefab, chemistPrefab, computerPrefab, fishPrefab, moneyPrefab;
    public static int count;
    private int next_count;
    private Vector3 centerPosition;
    private GameObject icon;
    private GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        //nextButton.onClick.AddListener(ButtonPressed);
        Random random = new Random();

        //populate prefabs array with prefab gameObjects (for randomization)
        prefabs = new GameObject[8] {lawyerPrefab, writerPrefab, teacherPrefab, doctorPrefab, chemistPrefab, computerPrefab, fishPrefab, moneyPrefab };
        Shuffle(prefabs);

        //initialize count
        count = 0;
        next_count = 1;

        //spawn the lawyer icon in the center
        centerPosition = new Vector3(0.0f, 0.0f, 1.0f);
        SpawnIcon(prefabs[0], centerPosition);
    }

    // Update is called once per frame
    void Update()
    {
        //when count == length of prefabs array, scene is finished(?)

        if (count == next_count)
        {
            next_count += 1;
            Destroy(icon);
            if (count < 8)
            {
                SpawnIcon(prefabs[count], centerPosition);
            }
            
        }
    }

    private void SpawnIcon(GameObject prefab, Vector3 position)
    {
        icon = Instantiate(prefab) as GameObject;
        icon.transform.position = position;
    }

    /*shuffles array with fisher-yates method*/
    private void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        System.Random random = new System.Random();
        for (int i = 0; i < (n-1); i++)
        {
            int r = i + random.Next(n - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
}
