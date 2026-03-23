using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fighter", menuName = "Scriptable Objects/Fighter")]
public class FighterSO : ScriptableObject
{
    [SerializeField] private int level;
    [SerializeField] private ElementType attribute;
    [SerializeField] private int hp;
    [SerializeField] private int mp;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int speed;
    [SerializeField] private List<CharacterStatusEffects> statusEffects;
    [SerializeField] private List<ElementType> resistances;
    [SerializeField] private List<ElementType> immunities;
    [SerializeField] private CharacterAlliance alignment;

    //shorthand for getters
    public int Level => level;
    public ElementType Attribute => attribute;
    public int HP => hp;
    public int MP => mp;
    public int Attack => attack;
    public int Defense => defense;
    public int Speed => speed;
    public List<CharacterStatusEffects> StatusEffects => statusEffects;
    public List<ElementType> Resistances => resistances;
    public List<ElementType> Immunities => immunities;
    public CharacterAlliance Alignment => alignment;
}
