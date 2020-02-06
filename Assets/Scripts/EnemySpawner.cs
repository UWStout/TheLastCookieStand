using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameManager gm;
    //Where we want to spawn the dinos.
    public Vector2[] spawnLocationsArray;
    //WaveData contains level information for each wave.
    public WaveData[] Waves;

    //Time between Spawns.
    public float timeTracker;
    public float timeBetweenSpawns;
    //Lists to select from for randomization reasons.
    public List<Vector2> SpawnLocationList;
    public List<GameObject> EnemyList;
    public List<GameObject> EnemyListTemp;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


    void Update()
    {
        //It might make since to temporarily disable the enemy spawner when it is not being used. Right now I am just using a check though.
        if (gm.EnemiesLeftToSpawn>0)
        {
            //This is just a do something on a timer script.
            if (timeTracker > 0)
            {
                timeTracker -= Time.deltaTime;
            }
            else
            {
                //we could also randomize this by adding or subtracting a random number to this.
                timeTracker = timeBetweenSpawns;
                PickWhatToSpawn();
            }
        }
    }

    public void SetupNewWave()
    {
        //Tells the game manager how many enemies to expect.
        gm.EnemiesLeftToSpawn = Waves[gm.CurrentWave].numOfEnemies;
        //Gets a time between each dino.
        timeBetweenSpawns = Waves[gm.CurrentWave].timeBetweenSpawns;
        //Makes a new list to keep track of enemies.
        EnemyList = new List<GameObject>();
        //Populates a list full of enemies with a number of each equal to their frequency.
        foreach (WaveData.EnemFreq enFr in Waves[gm.CurrentWave].EnemiesAndFrequency)
        {
            for (int i = 0; i < enFr.Frequency; i++)
            {
                EnemyList.Add(enFr.Enemy);
            }
        }
        //Makes a temporary version to remove stuff some for randomization purposes.
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
        EnemyListTemp.RemoveAt(tempRand);

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
        //Makes a dino
        Instantiate(dinosaur, tempLoc, Quaternion.identity);
        //Tells the game manager stuff about how much longer the level goes for.
        gm.EnemiesLeftAlive += 1;
        gm.EnemiesLeftToSpawn -= 1;
    }
}
