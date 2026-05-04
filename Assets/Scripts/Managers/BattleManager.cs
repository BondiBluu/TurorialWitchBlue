using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;

public class BattleManager : MonoBehaviour
{
    CharacterStatusManager characterStatusManager;
    [SerializeField] FighterSO guaranteedEnemy;
    public List<FighterSO> familiarList;

    private BattleState battleState;

    [Header("Battle Stations")]
    [SerializeField] Transform[] playerStations;

    [SerializeField] Transform[] enemyStations;

    [Header("Prefabs")]
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    [Header("To be deleted when testing is over")]
    public List<FighterSO> enemyList;
    public FighterSO playerStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //To be added in when testing in Fight Stage scene concludes
        //guaranteedEnemy = EncounterManager.instance.guaranteedEnemy;
        //FighterInstance playerInstance = EncounterManager.instance.playerData;
        characterStatusManager = FindAnyObjectByType<CharacterStatusManager>();
        battleState = BattleState.BATTLESTART;
        SetupBattle();
        SetUpCharacterStats();
    }

    public void SetUpCharacterStats()
    {
        characterStatusManager.BattleStartStats(playerStats);
    }

    private void SetupBattle()
    {
        if(battleState == BattleState.BATTLESTART)
        {
            CreateNumberOfEnemies();
            InstantiatePlayerAndAlly(playerStats);
        }  
    }

    public void InstantiatePlayerAndAlly(FighterSO fighter)
    {
        switch (fighter.Alignment)
        {
            case CharacterAlliance.Player:
                GameObject friendlyGO = InstantiateFighters(playerPrefab, playerStations[0]);
                friendlyGO.GetComponent<FighterBattleData>().SetupData(playerStats);   
                break;
            case CharacterAlliance.Familiar:
                break;
        }
        
        Debug.Log("Instantiating player");                
    }

    //TODO: see if any player station is full. If not, make that  where the next familiar goes
    private void CreateFamiliar(){}

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
                int randomEnemyAttribute = UnityEngine.Random.Range(0, enemyList.Count);
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
