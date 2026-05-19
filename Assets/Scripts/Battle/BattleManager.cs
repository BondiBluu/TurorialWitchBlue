using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;

public class BattleManager : MonoBehaviour
{
    CharacterStatusManager characterStatusManager;
    BattleSetup battleSetup;

    private BattleState battleState;

    

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //To be added in when testing in Fight Stage scene concludes
        //guaranteedEnemy = EncounterManager.instance.guaranteedEnemy;
        //FighterInstance playerInstance = EncounterManager.instance.playerData;
        battleSetup = FindAnyObjectByType<BattleSetup>();
        battleState = BattleState.BATTLESTART;
        SetupBattle();
    }

       public void SetupBattle()
    {
        if(battleState == BattleState.BATTLESTART)
        {
            battleSetup.SetUpAll();
            battleState = BattleState.PLAYERTURN;
        }  
    }  

 

    

    
}
