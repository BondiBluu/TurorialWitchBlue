using TMPro;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    [SerializeField] GameObject magicDescPanel;
    [SerializeField] TMP_Text moveName;
    [SerializeField] TMP_Text movePwr;
    [SerializeField] TMP_Text moveElement;
    [SerializeField] TMP_Text moveDesc;
    [SerializeField] TMP_Text moveMP;
    BattlePlayerManager battlePlayerManager;

    
    void Start()
    {
        battlePlayerManager = FindAnyObjectByType<BattlePlayerManager>();
    }

    public void DisplayMoves()
    {
        int count = 0;
        foreach (MoveSO move in battlePlayerManager.playerSO.Moveset)
        {
            if(battlePlayerManager.playerSO.Level >= move.MoveLevelLearned)
            {
                count++;
                Debug.Log(count);
            }
        }
    }
}
