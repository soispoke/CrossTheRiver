using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRockData : MonoBehaviour
{
    public string PlayerName = "Player1";
    public string Date = "03_06_2020";
    // Start is called before the first frame update
    void Start()
    {
        var sheet = new ES3Spreadsheet();

        sheet.SetCell(0, 0, "X");
        sheet.SetCell(1, 0, "Y");
        sheet.SetCell(2, 0, "Z");
        sheet.SetCell(4, 0, "Scale");

        int spacecount = PlayerPrefs.GetInt("spacecount");


        //sheet.Save($"C:/CrossTheRiver/RockData_set/RockData_{spacecount}.csv", true);
    }
}

