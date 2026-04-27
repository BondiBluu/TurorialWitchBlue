using UnityEngine;
using UnityEngine.UI;

public class FightingButtonsManager : MonoBehaviour
{
    [SerializeField] Button attackButton; //standard attack. replenished MP
    [SerializeField] Button magicSkillButton; //magical attack. drains MP
    [SerializeField] Button statusButton;
    [SerializeField] Button fleeButton;
    [SerializeField] GameObject magicPanel;
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
        magicPanel.SetActive(false);
    }

    public void OnAttackPressed()
    {
        //TODO: bring up enemy buttons to attack
    }
    public void OnMagicPressed()
    {
        OpenPanel(magicPanel);
        //TODO: generate buttons for character moves
    }
    public void OnStatusPressed()
    {
        statusPanel.SetActive(true);
    }
    public void OnFleePressed()
    {
        OpenPanel(fleePanel);
    }
    public void OnFleePressedYes()
    {
        
    }
    public void OnFleePressedNo()
    {
        ClosePanel(fleePanel);
    }
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
