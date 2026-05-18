using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;

public class BattleManager : MonoBehaviour
{
    CharacterStatusManager characterStatusManager;
    BattleSetup battleSetup;
    [SerializeField] FighterSO guaranteedEnemy;

    private BattleState battleState;

    

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
        battleSetup = FindAnyObjectByType<BattleSetup>();
        battleState = BattleState.BATTLESTART;
        SetupBattle();
    }

       public void SetupBattle()
    {
        if(battleState == BattleState.BATTLESTART)
        {
            battleSetup.CreateNumberOfEnemies(enemyList, guaranteedEnemy);
            battleSetup.InstantiatePlayerAndAlly(playerStats);
            SetUpCharacterStats();
        }  
    }  

        public void SetUpCharacterStats()
    {
        characterStatusManager.BattleStartStats(playerStats);
    }

    

    
}
