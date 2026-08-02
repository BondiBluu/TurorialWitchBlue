using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
    [SerializeField] Transform magicContainer;
    [SerializeField] GameObject magicDescPanel;
    [SerializeField] TMP_Text moveName;
    [SerializeField] TMP_Text movePwr;
    [SerializeField] TMP_Text moveDesc;
    [SerializeField] TMP_Text moveMP;
    public GameObject moveButtonPrefab;
    BattlePlayerManager battlePlayerManager;
    FightingButtonsManager fightingButtonsManager;

    
    void Start()
    {
        battlePlayerManager = FindAnyObjectByType<BattlePlayerManager>();
        fightingButtonsManager = FindAnyObjectByType<FightingButtonsManager>();
    }

    //if the player's level is more than or equal to the move, display move buttons in container and change its name
    public void DisplayMoves()
    {
        ClearMoves(magicContainer);
        
        foreach (MoveSO move in battlePlayerManager.playerSO.Moveset)
        {
            if(battlePlayerManager.playerSO.Level >= move.MoveLevelLearned)
            {
                GameObject moveButton = Instantiate(moveButtonPrefab, magicContainer);

                moveButton.GetComponentInChildren<TMP_Text>().text = move.MoveName;

                //add hover logic so move
                MoveSO currentMove = move;
                EventTrigger trigger = moveButton.AddComponent<EventTrigger>();

                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback.AddListener(_ => ShowMoveInfo(currentMove));
                trigger.triggers.Add(entry);

                EventTrigger.Entry exit = new EventTrigger.Entry();
                exit.eventID = EventTriggerType.PointerExit;
                exit.callback.AddListener(_ => fightingButtonsManager.ClosePanel(magicDescPanel));
                trigger.triggers.Add(exit);
            }
        }
    }

    //clear all moves from container
    public void ClearMoves(Transform container)
    {
        foreach (Transform button in container)
        {
            Destroy(button.gameObject);
        }
    }

    //show move name, desc, and stats
    public void ShowMoveInfo(MoveSO move)
    {
        magicDescPanel.SetActive(true);

        moveName.text = move.MoveName;
        movePwr.text = $"PWR: {move.AttackAmount}";
        moveMP.text = $"{move.MagicPointsNeeded}";
        moveDesc.text = move.MoveDesc;
    }
}
