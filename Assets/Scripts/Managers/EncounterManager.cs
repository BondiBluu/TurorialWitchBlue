using System.Collections.Generic;
using UnityEngine;

//this script holds the guaranteed enemy data and list of all slimes in the game to be used with Battle Manager
public class EncounterManager : MonoBehaviour
{
    public static EncounterManager instance;
    public FighterSO guaranteedEnemy;
    public FighterInstance playerData;
    public List<EnemyEncounterRates> enemyList;
    //won't destroy on load
     void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
