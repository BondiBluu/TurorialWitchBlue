using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Scriptable Objects/Moves")]
public class MoveSO : ScriptableObject
{
    [SerializeField] string moveName;
    [SerializeField] string moveDesc;
    [SerializeField] int moveLevelLearned;
    [SerializeField] ElementType moveElement;
    [SerializeField] int attackAmount;
    [SerializeField] int magicPointsNeeded;

}