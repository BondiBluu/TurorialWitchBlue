using UnityEngine;

public class EnemyEncounterRates : MonoBehaviour
{

    //tentative. For enemy spawn rates
    public struct EnemyEncounter
    {
        public FighterSO enemy;
        [Range (0f, 100f)] public float encounterRate;
    }
}
