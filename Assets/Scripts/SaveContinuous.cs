using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveContinuous : MonoBehaviour
{
    private string PlayerName;
    private string Date;

    private Text t1;
    private Text t2;

    private CharacterController player;
    public float counter;
    private int spacecount;
    private bool success = false;
    int[] fogchoices = {28, 42, 56, 100000};
    //int[] fogchoices = {100000 };

    void Start()
    {
        // Get Player Prefs
        PlayerName = PlayerPrefs.GetString("PlayerName");
        Date = PlayerPrefs.GetString("Date");

        // Random Fog settings
        int rand = Random.Range(0, fogchoices.Length);
        int result = fogchoices[rand];
        RenderSettings.fogStartDistance = result - 4;
        RenderSettings.fogEndDistance = result;
        counter = 0f;
    }

    void FixedUpdate()
    {
        if (!success)
        {
            counter += Time.deltaTime;
        }

        //// Create New Spreadsheet to save continuous data
        //var sheet = new ES3Spreadsheet();
        t1 = GameObject.Find("t1").GetComponent<Text>();
        t2 = GameObject.Find("t2").GetComponent<Text>();

        //// TRIAL NUMBER
        //spacecount = PlayerPrefs.GetInt("spacecount");

        //// POSITION
        //sheet.SetCell(0, 0, transform.localPosition.x);
        //sheet.SetCell(1, 0, transform.localPosition.y);
        //sheet.SetCell(2, 0, transform.localPosition.z);

        //// ROTATION
        //sheet.SetCell(3, 0, transform.localRotation.y);

        //// JUMP
        //if (Input.GetKey(KeyCode.J))
        //{
        //    sheet.SetCell(4, 0, "1");
        //}
        //else
        //{
        //    sheet.SetCell(4, 0, "0");
        //}

        // SUCCESS
        if (transform.localPosition.x > -2 && transform.localPosition.x < 2 && transform.localPosition.z > 238 && transform.localPosition.z < 242)
        {
            success = true;
            //sheet.SetCell(5, 0, "1");
            t1.text = "Time: " + (counter) + " sec";
            t2.text = "Well Done ! PRESS SPACE";
        }
        //else
        //{
        //    sheet.SetCell(5, 0, "0");
        //}

        //sheet.SetCell(6, 0, counter);
        //sheet.Save(Application.streamingAssetsPath + $"/DataCollect/{PlayerName}_{Date}/{spacecount}/xyz_rot_jump_success_time_PlayerData.csv", true);
    }
}