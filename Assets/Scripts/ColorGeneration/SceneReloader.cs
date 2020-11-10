using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneReloader : MonoBehaviour
{
    bool firstPlay;
    private int spacecount;
    private int Date;

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            spacecount = PlayerPrefs.GetInt("spacecount");

            int newspacecount = PlayerPrefs.GetInt("spacecount");
            newspacecount = newspacecount + 1;
            PlayerPrefs.SetInt("spacecount", newspacecount);
            PlayerPrefs.Save();
            Debug.Log("spacecount" + newspacecount);
        }
    }
}
