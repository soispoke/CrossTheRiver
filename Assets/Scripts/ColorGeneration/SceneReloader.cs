using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneReloader : MonoBehaviour
{
    bool firstPlay;
    private int spacecount;
    public SessionTrial trial;

    private string SessionId;
    public int timestamp()

    {
        // In seconds
        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        return (int)((System.DateTime.UtcNow - epochStart).TotalMilliseconds / 1000.0);
    }

    void Start()
    {
        int spacecount = PlayerPrefs.GetInt("spacecount");

        this.SessionId = timestamp().ToString();
        trial = new SessionTrial(PlayerPrefs.GetInt("spacecount"), this.SessionId);
        //var sheet = new ES3Spreadsheet();
        //sheet.SetCell(0, 0, "X");
        //sheet.SetCell(1, 0, "Y");
        //sheet.SetCell(2, 0, "Z");
        //sheet.Save($"C:/CrossTheRiver/RockData_set_new/RockData_{spacecount}.csv", true);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (trial != null)
            {
                trial.Save();
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            spacecount = PlayerPrefs.GetInt("spacecount");

            int newspacecount = PlayerPrefs.GetInt("spacecount");
            newspacecount = newspacecount + 1;
            trial = new SessionTrial(newspacecount,this.SessionId);

            PlayerPrefs.SetInt("spacecount", newspacecount);
            PlayerPrefs.Save();
            //Debug.Log("spacecount" + newspacecount);
        }
    }
}
