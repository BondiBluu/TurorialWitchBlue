using UnityEngine;

public class EnemyEncounterRates : MonoBehaviour
{
    public struct EnemyEncounter
    {
        public FighterSO enemy;
        [Range (0f, 100f)] public float encounterRate;
    }
}
