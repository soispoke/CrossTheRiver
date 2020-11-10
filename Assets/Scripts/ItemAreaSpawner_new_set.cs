using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemAreaSpawner_new_set : MonoBehaviour
{
    public GameObject itemToSpread;

    public float itemXSpread = 100;
    public float itemYSpread = 0;
    public float itemZSpread = 100;

    private string scale;
    private string x_pos;
    private string y_pos;
    private string z_pos;

    // Start is called before the first frame update
    void Start()
    {
        int spacecount = PlayerPrefs.GetInt("spacecount");
        string strspacecount = spacecount.ToString();

        var sheetrockload = new ES3Spreadsheet();
        // Debug.Log(Application.streamingAssetsPath + $"/RockData_set/RockData_{strspacecount}.csv");
        sheetrockload.Load(Application.streamingAssetsPath + $"/RockData_set/RockData_{strspacecount}.csv");

        int rowcount = sheetrockload.RowCount;
        // Debug.Log("ROWCOUNT  " + rowcount);
        for (int i = 0; i < rowcount-2; i++)
        {
            x_pos = sheetrockload.GetCell<string>(0, i+2);
            y_pos = sheetrockload.GetCell<string>(1, i+2);
            z_pos = sheetrockload.GetCell<string>(2, i+2);
            scale = sheetrockload.GetCell<string>(4, i+2);

            float newx_pos = float.Parse(x_pos);
            float newy_pos = float.Parse(y_pos);
            float newz_pos = float.Parse(z_pos);
            float new_scale = float.Parse(scale);

            Vector3 randPosition = new Vector3(newx_pos, newy_pos, newz_pos);

            Vector3 randScale = new Vector3(new_scale, 8, new_scale);

            GameObject clone = Instantiate(itemToSpread, randPosition, itemToSpread.transform.rotation);
            clone.transform.localScale = randScale;// Spawn the obstacle here        }
        }
    }
}





