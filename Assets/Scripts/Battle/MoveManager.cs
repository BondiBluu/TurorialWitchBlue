using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
    [SerializeField] Transform magicContainer;
    [SerializeField] GameObject magicDescPanel;
    [SerializeField] TMP_Text moveName;
    [SerializeField] TMP_Text movePwr;
    [SerializeField] TMP_Text moveElement;
    [SerializeField] TMP_Text moveDesc;
    [SerializeField] TMP_Text moveMP;
    [SerializeField] GameObject moveButtonPrefab;
    BattlePlayerManager battlePlayerManager;
    FightingButtonsManager fightingButtonsManager;

    
    void Start()
    {
        battlePlayerManager = FindAnyObjectByType<BattlePlayerManager>();
        fightingButtonsManager = FindAnyObjectByType<FightingButtonsManager>();
    }

    public void DisplayMoves()
    {
        ClearMoves(magicContainer);
        
        foreach (MoveSO move in battlePlayerManager.playerSO.Moveset)
        {
            if(battlePlayerManager.playerSO.Level >= move.MoveLevelLearned)
            {
                GameObject moveButton = Instantiate(moveButtonPrefab, magicContainer);
            }
        }
    }

    public void ClearMoves(Transform container)
    {
        foreach (Transform button in container)
        {
            Destroy(button.gameObject);
        }
    }
}
