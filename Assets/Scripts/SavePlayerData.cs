using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SavePlayerData : MonoBehaviour
{
    //public string PlayerName = "Player1";
    //public string Date = "03_06_2020";
    private void Start()
    {
        //PlayerPrefs.SetInt("spacecount", 0);

    }

    void Update()
    {
        // Create a blank ES3Spreadsheet.
        var sheet = new ES3Spreadsheet();

        GameObject PlayerNameGO = GameObject.Find("PlayerName");
        InputField PlayerNameIP = PlayerNameGO.GetComponent<InputField>();

        GameObject DateGO = GameObject.Find("Date");
        InputField DateIP = DateGO.GetComponent<InputField>();

        if (Input.GetKey(KeyCode.Return))
        {
          
        sheet.SetCell(0, 0, PlayerNameIP.text);
        sheet.SetCell(1, 0, DateIP.text);
            
            sheet.Save(Application.streamingAssetsPath + "/DataCollect_temp/PlayerAndDate.csv", true);
        }
    }
}