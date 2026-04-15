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

    private void CreateNumberOfEnemies()
    {
        int numberOfenemies = UnityEngine.Random.Range(1,4);

        for(int i = 0; i < numberOfenemies; i++)
        {
            Debug.Log("Number of enemies: " + numberOfenemies);
            InstantiateFighters(enemyPrefab, enemyStations[i]);
        }
    }

    private void InstantiateFighters(GameObject fighter, Transform fighterPosition)
    {
        //instantiate whoever is there
        Debug.Log("Instantiating");
        Instantiate(fighter, fighterPosition.position, Quaternion.identity, fighterPosition);
    }
}
