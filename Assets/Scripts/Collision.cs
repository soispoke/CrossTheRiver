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

    // Start is called before the first frame update
    void Start()
    {
        stone = GetComponent<GameObject>();
        PlayerName = PlayerPrefs.GetString("PlayerName");
        Date = PlayerPrefs.GetString("Date");
    }

    void OnTriggerEnter(Collider col)
    {
        PlayerName = PlayerPrefs.GetString("PlayerName");
        Date = PlayerPrefs.GetString("Date");
        counter += Time.deltaTime;
        spacecount = PlayerPrefs.GetInt("spacecount");

        var sheet = new ES3Spreadsheet();
        var getcounter = GameObject.Find("Player").GetComponent<SaveContinuous>();

        sheet.SetCell(0, 0, col.transform.position.x);
        sheet.SetCell(1, 0, col.transform.position.y);
        sheet.SetCell(2, 0, col.transform.position.z);
        sheet.SetCell(3, 0, getcounter.counter);

        sheet.Save(Application.streamingAssetsPath + $"/DataCollect/{PlayerName}_{Date}/{spacecount}/xyz_time_StonesPositions.csv", true);
    }
}
