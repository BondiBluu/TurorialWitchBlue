using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleManager : MonoBehaviour
{
    [SerializeField] FighterSO guaranteedEnemy;
    private BattleState battleState;

    [Header("Battle Stations")]
    [SerializeField] Transform[] playerStations;

    [SerializeField] Transform[] enemyStations;

    [Header("Prefabs")]
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    [Header("To be deleted when testing is over")]
    public List<FighterSO> enemyList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //To be added in when testing in Fight Stage scene concludes
        //guaranteedEnemy = EncounterManager.instance.guaranteedEnemy;
        battleState = BattleState.BATTLESTART;
        SetupBattle();
    }

    private void SetupBattle()
    {
        if(battleState == BattleState.BATTLESTART)
        {
            CreateNumberOfEnemies();
        }  
    }


    /*create a random number of enemies
    first enemy will always be the guaranteed attribute player ran into
    all others will be random*/
    private void CreateNumberOfEnemies()
    {
        int numberOfEnemies = UnityEngine.Random.Range(1,4);
        Debug.Log("Number of enemies: " + numberOfEnemies);
        

        for(int i = 0; i < numberOfEnemies; i++)
        {
            
            GameObject enemyGameObject =  InstantiateFighters(enemyPrefab, enemyStations[i]);

            if(i == 0)
            {
                enemyGameObject.GetComponent<FighterBattleData>().SetupData(guaranteedEnemy);
            }
            else
            {
                int randomEnemyAttribute = UnityEngine.Random.Range(0, enemyList.Count - 1);
                enemyGameObject.GetComponent<FighterBattleData>().SetupData(enemyList[randomEnemyAttribute]);
            }

        }
    }

    private GameObject InstantiateFighters(GameObject fighter, Transform fighterPosition)
    {
        //instantiate whoever is there
        Debug.Log("Instantiating");
        return Instantiate(fighter, fighterPosition.position, Quaternion.identity, fighterPosition);
    }
}
