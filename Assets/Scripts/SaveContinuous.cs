using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveContinuous : MonoBehaviour
{
    public string PlayerName = "Player1";
    public string Date = "03_06_2020";

    public Text t1;
    public Text t2;

    private CharacterController player;
    private float counter;
    private float SpaceCount;
    private int spacecount;
    private float countersuccess;
    private bool success = false;

    void Start()
    {
        player = GetComponent<CharacterController>();

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

        if (Input.GetKeyDown("f"))
        { // F toggles fog on/off
            RenderSettings.fog = !RenderSettings.fog;
        }
        // Create a blank ES3Spreadsheet.
        var sheetload = new ES3Spreadsheet();

        sheetload.Load(Application.streamingAssetsPath + "/DataCollect_temp/PlayerAndDate.csv");
        PlayerName = sheetload.GetCell<string>(0, 1);
        Date = sheetload.GetCell<string>(1, 1);

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
            sheet.SetCell(7, 1, "TRIALCOUNT");

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
            } else
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

            // TRIAL NUMBER
            spacecount = PlayerPrefs.GetInt("spacecount") ;
            sheet.SetCell(7, 0, spacecount);


        }
        sheet.Save(Application.streamingAssetsPath +  $"/DataCollect/{PlayerName}_{Date}/PlayerData.csv", true);

    }
}