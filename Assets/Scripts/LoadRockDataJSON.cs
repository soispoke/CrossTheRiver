using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using SimpleJSON;

[System.Serializable]
public class Record
{
    public string x_pos;
    public string y_pos;
    public string z_pos;
}

public class LoadRockDataJSON : MonoBehaviour
{
    public GameObject itemToSpread;
    void Start()
    {
        int spacecount = PlayerPrefs.GetInt("spacecount");
        var jsonasset = Resources.Load<TextAsset>("RockData_" + spacecount.ToString());

        JSONNode datajson = JSON.Parse(jsonasset.text);

        foreach (JSONNode record in datajson)
        {
            float number;
            if (float.TryParse(record["X"].Value, out number))
            {
                float newx_pos = float.Parse(record["X"].Value);
                float newy_pos = float.Parse(record["Y"].Value + 40);
                float newz_pos = float.Parse(record["Z"].Value);

                Vector3 Position = new Vector3(newx_pos, newy_pos, newz_pos);
                GameObject clone = Instantiate(itemToSpread, Position, itemToSpread.transform.rotation);
            }
        }
    }
}






