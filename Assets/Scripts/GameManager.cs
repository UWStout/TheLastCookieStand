using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    //Other important Controllers
    public MouseControl mc;
    public EnemySpawner es;


    //States so the manager can behave differently.
    public int state;
    public enum states { EnemiesLeft, NoEnemiesLeft, Prompts };

    //Current wave
    public int CurrentWave = 0;


    
    //Putting these here so the UI, Enemies, and Spawner can both access them.
    public int EnemiesLeftAlive = 0;
    public int EnemiesTotal = 0;
    public int EnemiesLeftToSpawn = 0;
    


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        Debug.Log("Yes?");

        mc = GameObject.FindWithTag("MainCamera").GetComponent<MouseControl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Temporary. The game should probably start out with some text based tutorialization.
        es.SetupNewWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
