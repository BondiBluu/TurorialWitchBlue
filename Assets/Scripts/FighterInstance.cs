using System.Collections.Generic;
using UnityEngine;

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
