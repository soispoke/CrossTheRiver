using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private GameObject stone;
    private string PlayerName ;
    private string Date;
    private int spacecount;
    private float counter;
    private SessionTrial trial;

    // Start is called before the first frame update
    void Start()
    {
        trial = GameObject.Find("SceneReloader").GetComponent<SceneReloader>().trial;
        stone = GetComponent<GameObject>();
        PlayerName = PlayerPrefs.GetString("PlayerName");
        Date = PlayerPrefs.GetString("Date");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            PlayerName = PlayerPrefs.GetString("PlayerName");
            Date = PlayerPrefs.GetString("Date");
            counter += Time.deltaTime;
            spacecount = PlayerPrefs.GetInt("spacecount");
            SaveContinuous savecontinuous = GameObject.Find("Player").GetComponent<SaveContinuous>();

            if (trial != null)
            {
                trial.ColRecord(col.transform.position.x, col.transform.position.y, col.transform.position.z, savecontinuous.counter);
            }
        }
    }
}
