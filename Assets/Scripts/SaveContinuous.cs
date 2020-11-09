using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveContinuous : MonoBehaviour
{
    public string PlayerName = "Player1";
    public string Date = "03_06_2020";

    private Text t1;
    private Text t2;

    private CharacterController player;
    public float counter;
    private int spacecount;
    private int successcountfog;
    private int successprevioustrial;

    private bool success = false;
    int[] fogchoices = {28, 42, 56, 100000};


    void Start()
    {
        player = GetComponent<CharacterController>();
        
        // Random Fog settings

        int rand = Random.Range(0, fogchoices.Length);
        int result = fogchoices[rand];

        //RenderSettings.fog = !RenderSettings.fog;
        RenderSettings.fogStartDistance = result - 4;
        RenderSettings.fogEndDistance = result;          
    }

    void FixedUpdate()
    {
        if (!success)
        {
            counter += Time.deltaTime;
        }

        t1 = GameObject.Find("t1").GetComponent<Text>();
        t2 = GameObject.Find("t2").GetComponent<Text>();

        //t1.text = "Time: " + (counter - 3) + " sec";


        
        // Create a blank ES3Spreadsheet.
        var sheetload = new ES3Spreadsheet();

        sheetload.Load(Application.streamingAssetsPath + "/DataCollect_temp/PlayerAndDate.csv");
        PlayerName = sheetload.GetCell<string>(0, 1);
        Date = sheetload.GetCell<string>(1, 1);
        
        // TRIAL NUMBER
        spacecount = PlayerPrefs.GetInt("spacecount");
        // Save some values into the spreadsheet.
        var sheet = new ES3Spreadsheet();
        if (counter < 0.02)
        {
            sheet.SetCell(0, 0, "");
            sheet.SetCell(1, 0, "");
            sheet.SetCell(2, 0, "");
            sheet.SetCell(3, 0, "");
            sheet.SetCell(4, 0, "");
            sheet.SetCell(5, 0, "");
            sheet.SetCell(6, 0, "");
            sheet.SetCell(7, 0, "");

            sheet.SetCell(0, 1, "");
            sheet.SetCell(1, 1, "X_POS");
            sheet.SetCell(2, 1, "Y_POS");
            sheet.SetCell(3, 1, "Z_POS");
            sheet.SetCell(4, 1, "Y_ROT");
            sheet.SetCell(5, 1, "JUMP");
            sheet.SetCell(6, 1, "SUCCESS");
            sheet.SetCell(7, 1, "TIME");

            sheet.Save(Application.streamingAssetsPath + $"/DataCollect/{PlayerName}_{Date}/{spacecount}/PlayerData.csv", true);
        }

        else
        {
            sheet.SetCell(0, 0, counter);

            // POSITION
            sheet.SetCell(1, 0, transform.localPosition.x);
            sheet.SetCell(2, 0, transform.localPosition.y);
            sheet.SetCell(3, 0, transform.localPosition.z);

            // ROTATION
            sheet.SetCell(4, 0, transform.localRotation.y);

            // JUMP
            if (Input.GetKey(KeyCode.J))
            {
                sheet.SetCell(5, 0, "1");
            }
            else
            {
                sheet.SetCell(5, 0, "0");
            }

            // SUCCESS
            if (transform.localPosition.x > -2 && transform.localPosition.x < 2 && transform.localPosition.z > 238 && transform.localPosition.z < 242)
            {
                success = true;
                sheet.SetCell(6, 0, "1");
                t1.text = "Time: " + (counter) + " sec";
                t2.text = "Well Done ! PRESS SPACE";
            }
            else
            {
                sheet.SetCell(6, 0, "0");
            }


            sheet.SetCell(7, 0, counter);
            sheet.Save(Application.streamingAssetsPath + $"/DataCollect/{PlayerName}_{Date}/{spacecount}/PlayerData.csv", true);

        }

    }
}