using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;
    int numTowers = 0;
    // Use this for initialization
    public void AddTower(Waypoint baseWaypoint)
    {
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }

    }

    private static void MoveExistingTower()
    {
        print("Tower Limit has been reached");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        numTowers++;
    }
}
