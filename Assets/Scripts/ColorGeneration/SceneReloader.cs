using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneReloader : MonoBehaviour
{
    bool firstPlay;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            if (PlayerPrefs.HasKey("spacecount"))
            {
                int newspacecount = PlayerPrefs.GetInt("spacecount");
                newspacecount = newspacecount + 1;
                PlayerPrefs.SetInt("spacecount", newspacecount);
                PlayerPrefs.Save();
                Debug.Log("spacecount" + newspacecount);

            }

            else {
                PlayerPrefs.SetInt("spacecount", 0);
                int newspacecount = PlayerPrefs.GetInt("spacecount");
                PlayerPrefs.Save();
                Debug.Log("spacecount" + newspacecount);

            }


        }
        if (Input.GetKey(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
