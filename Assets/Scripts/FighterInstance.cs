using System.Collections.Generic;
using UnityEngine;

//this script is a runtime class that holds the state of the characters. Character stats are changed through here.
//Every character that levels up should have this. 
public class FighterInstance
{
    public FighterSO baseData;
    public int currentLevel;
    public int currentHP;
    public int currentMP;
    public int currentAttack;
    public int currentDefense;
    public int currentSpeed;
    public List<CharacterStatusEffects> characterStatusEffects;

    //copies the base stats from the FighterSO. These are where the base stats start.
    public FighterInstance(FighterSO data)
    {
        baseData = data;
        
        currentLevel = data.Level;
        currentHP = data.HP;
        currentMP = data.MP;
        currentAttack = data.Attack;
        currentDefense = data.Defense;
        currentSpeed = data.Speed;
        characterStatusEffects = new List<CharacterStatusEffects>();
    }

    
}
