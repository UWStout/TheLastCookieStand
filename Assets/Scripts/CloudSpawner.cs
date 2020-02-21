using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2[] spawnLocationsArray;
    //WaveData contains level information for each wave.
    public WaveData Wave;

    //Time between Spawns.
    public float timeTracker;
    public float timeBetweenSpawns;
    //Lists to select from for randomization reasons.
    public List<Vector2> SpawnLocationList;
    public List<GameObject> CloudList;
    public List<GameObject> CloudListTemp;



    // Start is called before the first frame update
    void Start()
    {
        SetupNewWave();
    }

    // Update is called once per frame


    void Update() {
        //This is just a do something on a timer script.
        if (timeTracker > 0)
        {
            timeTracker -= Time.deltaTime;
        }
        else
        {
            //we could also randomize this by adding or subtracting a random number to this.
            //This really shouldnt be hard coded.
            timeTracker=timeBetweenSpawns+(timeBetweenSpawns*Random.Range(-.3f,.3f));
            timeTracker = timeBetweenSpawns;
            PickWhatToSpawn();
        }
    }

    public void SetupNewWave()
    {
        //Gets a time between each dino.
        timeBetweenSpawns = Wave.timeBetweenSpawns;
        //Makes a new list to keep track of enemies.
        CloudList = new List<GameObject>();
        //Populates a list full of enemies with a number of each equal to their frequency.
        foreach (WaveData.EnemFreq enFr in Wave.EnemiesAndFrequency)
        {
            for (int i = 0; i < enFr.Frequency; i++)
            {
                CloudList.Add(enFr.Enemy);
            }
        }
        //Makes a temporary version to remove stuff some for randomization purposes.
        CloudListTemp = new List<GameObject>(CloudList);
        SpawnLocationList = new List<Vector2>(spawnLocationsArray);


    }

    void PickWhatToSpawn()
    {
        //Pulls a random Item from list then removes it;
        if (CloudListTemp.Count == 0)
        {
            CloudListTemp = new List<GameObject>(CloudList);
        }
        int tempRand = Random.Range(0, CloudListTemp.Count);
        GameObject cloud = CloudListTemp[tempRand];
        CloudListTemp.RemoveAt(tempRand);

        SpawnDino(cloud);
    }

    void SpawnDino(GameObject cloud)
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
        Instantiate(cloud, tempLoc, Quaternion.identity);
        //Tells the game manager stuff about how much longer the level goes for.
    }
}
