using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private FighterSO guaranteedEnemy;
    private BattleState battleState;

    [Header("Battle Stations")]
    [SerializeField] Transform[] playerStations;

    [SerializeField] Transform[] enemyStations;

    [Header("Prefabs")]
    public GameObject playerPrefab;
    public GameObject enemyPrefab;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        guaranteedEnemy = EncounterManager.instance.guaranteedEnemy;
        battleState = BattleState.BATTLESTART;
        InstantiatePlayers();
    }

    private void InstantiatePlayers()
    {
        if(battleState == BattleState.BATTLESTART)
        {
            for(int i = 0; i < 4; i++)
            {
                //instantiating enemies. We'll worry about instantiating them with their stats later.
            }
        }
        
    }
}
