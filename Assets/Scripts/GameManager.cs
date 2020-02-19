using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    //Other important Controllers
    public MouseControl mc;
    public EnemySpawner es;
    public PauseManager pc;


    //States so the manager can behave differently.
    public int state;
    public enum STATES { EnemiesLeft, NoEnemiesLeft, Prompts };

    //Current wave
    public int CurrentWave = 0;

    //Level Setups.
    public GameObject[] LevelSetup;
    
    //Putting these here so the UI, Enemies, and Spawner can both access them.
    public int EnemiesLeftAlive = 0;
    public int EnemiesTotal = 0;
    public int EnemiesLeftToSpawn = 0;
    
    //Dialogue Controller
    public GameObject DialogueObject;
    public DialogueSystem diaSys;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        //Commenting out this don't destroy on load thing.
        //DontDestroyOnLoad(gameObject);

        Debug.Log("Yes?");

        mc = GameObject.FindWithTag("MainCamera").GetComponent<MouseControl>();
        Debug.Log(mc);
    }

    IEnumerator DialogueSetup(int conv)
    {
        yield return new WaitForSecondsRealtime(.25f);
        DialogueObject.SetActive(true);
        diaSys.SetupDialogue(conv);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DialogueSetup(CurrentWave));
        es.SetupNewWave();
        state=(int)STATES.NoEnemiesLeft;

    }


    public void WaveClear()
    {



    }


    public void BootToMainMenu()
    {
        pc.MainMenu();

    }

    void NewLevel()
    {
        if(CurrentWave>=0)
        {
            LevelSetup[CurrentWave].SetActive(false);
        }
        CurrentWave+=1;
        LevelSetup[CurrentWave].SetActive(true);
        StartCoroutine(DialogueSetup(CurrentWave));
        es.SetupNewWave();

    }



    // Update is called once per frame
    void Update()
    {
        if(state==(int)STATES.EnemiesLeft&&EnemiesLeftAlive==0&&EnemiesLeftToSpawn==0)
        {


            NewLevel();
            state=(int)STATES.NoEnemiesLeft;
            //Starts next level.


        }
        else if(EnemiesLeftAlive>=1)
        {
            state=(int)STATES.EnemiesLeft;

        }

    }
}
