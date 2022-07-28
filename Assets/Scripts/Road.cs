using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public Vector3 lastPos;
    public float offSet = 0.707f;
    int roadCount = 0;

    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, 0.15f);
    }
    public void CreateNewRoadPart()
    {
        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);
        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offSet, lastPos.y, lastPos.z + offSet);
        }
        else
            spawnPos = new Vector3(lastPos.x - offSet, lastPos.y, lastPos.z + offSet);

        GameObject g = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));
        lastPos = g.transform.position;
        roadCount++;
        if (roadCount % 4 == 0)
            g.transform.GetChild(0).gameObject.SetActive(true);
    }
}
