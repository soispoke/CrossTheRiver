using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAlignerNoOverlap : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public float raycastDistance = 100f;
    public float overlapTestBoxSize = 1f;
    public LayerMask spawnedObjectLayer;
    public float minitemXScale = 6;
    public float maxitemXScale = 10;
    private float scale;
    public string PlayerName = "Player1";
    public string Date = "03_06_2020";

    // Start is called before the first frame update
    void Start()
    {
     PositionRaycast_second();
    }


    void PositionRaycast_second()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            Vector3 overlapTestBoxScale = new Vector3(overlapTestBoxSize, overlapTestBoxSize, overlapTestBoxSize);
            Collider[] collidersInsideOverlapBox = new Collider[1];
            int numberOfCollidersFound = Physics.OverlapBoxNonAlloc(hit.point, overlapTestBoxScale, collidersInsideOverlapBox, spawnRotation, spawnedObjectLayer);

            if (numberOfCollidersFound == 0)
            {
                Pick_second(hit.point, spawnRotation);
            }

        }
    }

    void Pick_second(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        scale = Random.Range(minitemXScale, maxitemXScale);
        Vector3 randScale = new Vector3(scale, 8, scale);
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);

        var sheet = new ES3Spreadsheet();

        sheet.SetCell(0, 0, positionToSpawn.x);
        sheet.SetCell(1, 0, positionToSpawn.y+40);
        sheet.SetCell(2, 0, positionToSpawn.z+110);
        sheet.SetCell(4, 0, scale);

        int spacecount = PlayerPrefs.GetInt("spacecount");

        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);// Spawn the obstacle here
        clone.transform.localScale = randScale;
        sheet.Save($"C:/CrossTheRiver/RockData_set_new/RockData_{spacecount}.csv", true);

    
    }

}
