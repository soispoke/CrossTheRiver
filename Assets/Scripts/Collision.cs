using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject stone;
    public string PlayerName = "Player1";
    public string Date = "03_06_2020";
    private int spacecount;
    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        stone = GetComponent<GameObject>();
        
    }

    void OnTriggerEnter(Collider col)
    {
        counter += Time.deltaTime;
        spacecount = PlayerPrefs.GetInt("spacecount");

        var sheetload = new ES3Spreadsheet();

        sheetload.Load(Application.streamingAssetsPath + "/DataCollect_temp/PlayerAndDate.csv");
        PlayerName = sheetload.GetCell<string>(0, 1);
        Date = sheetload.GetCell<string>(1, 1);
        var sheet = new ES3Spreadsheet();


        var getcounter = GameObject.Find("Player").GetComponent<SaveContinuous>();

        sheet.SetCell(0, 0, col.transform.position.x);
        sheet.SetCell(1, 0, col.transform.position.y);
        sheet.SetCell(2, 0, col.transform.position.z);
        sheet.SetCell(3, 0, getcounter.counter);

        sheet.Save(Application.streamingAssetsPath + $"/DataCollect/{PlayerName}_{Date}/{spacecount}/xyz_StonesPositions.csv", true);
    }

}
