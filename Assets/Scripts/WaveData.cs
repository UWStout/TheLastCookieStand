using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "ScriptableObjects/WaveData", order = 1)]
public class WaveData : ScriptableObject
{

    [System.Serializable]
    public class EnemFreq
    {
        //define all of the values for the class
        public GameObject Enemy;
        public int Frequency;
        //define a constructor for the class
        public EnemFreq()
        {

        }
    }

#region PUBLIC_VERIABLE
    public EnemFreq[] EnemiesAndFrequency;
    public int numOfEnemies;
    public float timeBetweenSpawns;
    /*
    public string name;
    public int moveSpeed;
    public Color color;
    public string colorName;*/
#endregion
}
