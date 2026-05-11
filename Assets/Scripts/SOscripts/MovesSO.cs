using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Scriptable Objects/Moves")]
public class MoveSO : ScriptableObject
{
    [SerializeField] string moveName;
    [SerializeField] string moveDesc;
    [SerializeField] int moveLevelLearned;
    [SerializeField] int attackAmount;
    [SerializeField] int magicPointsNeeded;

    public string MoveName => moveName;
    public string MoveDesc => moveDesc;
    public int MoveLevelLearned => moveLevelLearned;
    public int AttackAmount => attackAmount;
    public int MagicPointsNeeded => magicPointsNeeded;
}