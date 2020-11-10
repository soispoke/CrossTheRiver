using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SavePlayerData : MonoBehaviour
{
    private string PlayerName;
    private string Date;

    void Update()
    {   // Create a blank ES3Spreadsheet.
        var sheet = new ES3Spreadsheet();

        GameObject PlayerNameGO = GameObject.Find("PlayerName");
        InputField PlayerNameIP = PlayerNameGO.GetComponent<InputField>();

        GameObject DateGO = GameObject.Find("Date");
        InputField DateIP = DateGO.GetComponent<InputField>();
   
        if (Input.GetKey(KeyCode.Return))
        {
            PlayerPrefs.SetString("PlayerName", PlayerNameIP.text);
            PlayerPrefs.SetString("Date", DateIP.text);
            PlayerPrefs.SetInt("spacecount", 0);

            PlayerPrefs.Save();
        }
    }
}