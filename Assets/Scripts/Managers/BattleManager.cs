using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public EncounterManager encounterManager;
    private FighterSO guaranteedEnemy;
    private BattleState battleState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        encounterManager = FindAnyObjectByType<EncounterManager>();
        guaranteedEnemy = encounterManager.guaranteedEnemy;
        battleState = BattleState.BATTLESTART;
        InstantiatePlayers();
    }

    private void InstantiatePlayers()
    {
        if(battleState == BattleState.BATTLESTART)
        {
            Debug.Log("Battle is starting. Instantiating players.");
            Debug.Log($"Guaranteed enemy is {guaranteedEnemy}");
        }
        
    }
}
