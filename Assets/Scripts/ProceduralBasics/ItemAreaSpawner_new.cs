using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAreaSpawner_new : MonoBehaviour
{
    public GameObject itemToSpread;
    public int numItemsToSpawn = 10;

    public float itemXSpread = 10;
    public float itemYSpread = 0;
    public float itemZSpread = 10;

    public float minitemXScale = 5;
    public float maxitemXScale = 15;

    public float SpaceCount = 0;
    public string PlayerName = "Player1";
    public string Date = "03_06_2020";
    public string PathData = "C:/Users/tbthi/Documents/";
    public string NewPathData = "";
    private float scale;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numItemsToSpawn; i++)
        {
            SpreadItem();
        }
    }

    void SpreadItem()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), Random.Range(-itemYSpread, itemYSpread), Random.Range(-itemZSpread, itemZSpread)) + transform.position;
        scale = Random.Range(minitemXScale, maxitemXScale);
        Vector3 randScale = new Vector3(scale, 8, scale);

        // Load a blank ES3Spreadsheet.

        var sheetload = new ES3Spreadsheet();
        sheetload.Load("C:/DataCollect_temp/PlayerAndDate.csv");
        PlayerName = sheetload.GetCell<string>(0, 1);
        Date = sheetload.GetCell<string>(1, 1);

        var sheet = new ES3Spreadsheet();
        sheet.SetCell(0, 0, "");
        sheet.SetCell(1, 0, "");
        sheet.SetCell(2, 0, "");
        sheet.SetCell(4, 0, "");

        sheet.SetCell(0, 1, "X_POS");
        sheet.SetCell(1, 1, "Y_POS");
        sheet.SetCell(2, 1, "Z_POS");
        sheet.SetCell(4, 1, "XZ_SCALE");

        sheet.SetCell(0, 2, randPosition.x);
        sheet.SetCell(1, 2, randPosition.y);
        sheet.SetCell(2, 2, randPosition.z);
        sheet.SetCell(4, 0, scale);

        sheet.Save($"C:/DataCollect/{PlayerName}_{Date}/RockData.csv", true);

        GameObject clone = Instantiate(itemToSpread, randPosition, itemToSpread.transform.rotation);
        clone.transform.localScale = randScale;// Spawn the obstacle here
    }
}




