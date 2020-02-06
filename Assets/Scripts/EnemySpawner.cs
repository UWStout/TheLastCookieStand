using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Time between Spawns.
    float timeBetweenSpawns;
    float timeTracker;
    //MaybeThisShouldBeOnManager
    int phase;
    enum phases { Upgrades, EnemiesLeft, NoEnemiesLeft};
    int EnemiesLeftAlive = 0;
    int CurrentWave = 0;

    
    Vector2[] spawnLocationsArray;
    WaveData[] Waves;

    //Lists to select from
    List<Vector2> SpawnLocationList;
    List<GameObject> EnemyList;
    List<GameObject> EnemyListTemp;



    // Start is called before the first frame update
    void Start()
    {
        SetupNewWave();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(timeTracker>0)
        {
            timeTracker -= Time.deltaTime;
        }
        else
        {
            timeTracker = timeBetweenSpawns;
            PickWhatToSpawn();
        }
    }

    void SetupNewWave()
    {
        timeBetweenSpawns = Waves[CurrentWave].timeBetweenSpawns;
        EnemyList = new List<GameObject>();
        foreach (WaveData.EnemFreq enFr in Waves[CurrentWave].EnemiesAndFrequency)
        {
            for (int i = 0; i < enFr.Frequency; i++)
            {
                EnemyList.Add(enFr.Enemy);
            }
        }
        EnemyListTemp = new List<GameObject>(EnemyList);
        SpawnLocationList = new List<Vector2>(spawnLocationsArray);

    }

    void PickWhatToSpawn()
    {
        //Pulls a random Item from list then removes it;
        if (EnemyListTemp.Count == 0)
        {
            EnemyListTemp = new List<GameObject>(EnemyList);
        }
        int tempRand = Random.Range(0, EnemyListTemp.Count);
        GameObject dino = EnemyListTemp[tempRand];
        SpawnDino(dino);
    }

    void SpawnDino(GameObject dinosaur)
    {
        //Pulls a location from the list then removes it. Insuring even spread across lanes.
        if (SpawnLocationList.Count==0)
        {
            SpawnLocationList = new List<Vector2>(spawnLocationsArray);
        }
        int tempRand = Random.Range(0, SpawnLocationList.Count);
        Vector2 tempLoc = SpawnLocationList[tempRand];
        SpawnLocationList.RemoveAt(tempRand);
        Instantiate(dinosaur, tempLoc, Quaternion.identity);
    }


    void EndOfAWave()
    {

    }


}
