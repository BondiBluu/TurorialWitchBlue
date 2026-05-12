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
    [SerializeField] TMP_Text moveElement;
    [SerializeField] TMP_Text moveDesc;
    [SerializeField] TMP_Text moveMP;
    [SerializeField] GameObject moveButtonPrefab;
    BattlePlayerManager battlePlayerManager;
    FightingButtonsManager fightingButtonsManager;

    
    void Start()
    {
        HideMoveInfo();
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

                moveButton.GetComponentInChildren<TMP_Text>().text = move.MoveName;

                //add hover logic
                EventTrigger trigger = moveButton.AddComponent<EventTrigger>();

                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback.AddListener(_ => ShowMoveInfo());
                trigger.triggers.Add(entry);

                EventTrigger.Entry exit = new EventTrigger.Entry();
                exit.eventID = EventTriggerType.PointerExit;
                exit.callback.AddListener(_ => HideMoveInfo());
                trigger.triggers.Add(exit);
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

    public void ShowMoveInfo()
    {
        magicDescPanel.SetActive(true);
    }
    public void HideMoveInfo()
    {
        magicDescPanel.SetActive(false);
    }
}
