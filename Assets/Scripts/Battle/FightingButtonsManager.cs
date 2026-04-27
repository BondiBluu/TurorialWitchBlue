using UnityEngine;
using UnityEngine.UI;

public class FightingButtonsManager : MonoBehaviour
{
    [SerializeField] Button attackButton; //standard attack. replenished MP
    [SerializeField] Button magicSkillButton; //magical attack. drains MP
    [SerializeField] Button statusButton;
    [SerializeField] Button fleeButton;
    [SerializeField] GameObject statusPanel;
    [SerializeField] GameObject fleePanel;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnOffAllPanels();
    }
    public void TurnOffAllPanels()
    {
        statusPanel.SetActive(false);
        fleePanel.SetActive(false);
    }

    public void OnAttackPressed(){}
    public void OnMagicPressed(){}
    public void OnStatusPressed(){}
    public void OnFleePressed()
    {
        fleePanel.SetActive(true);
    }
    public void OnFleePressedYes(){    }
    public void OnFleePressedNo()
    {
        fleePanel.SetActive(false);
    }
}
