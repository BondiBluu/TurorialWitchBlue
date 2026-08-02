using UnityEngine;
using UnityEngine.UI;

public class FightingButtonsManager : MonoBehaviour
{
    [SerializeField] Button attackButton; //standard attack. replenishes MP. TODO: Bring up enemies bar every time
    [SerializeField] Button magicSkillButton; //magical attack. drains MP. Brings up magical skills
    [SerializeField] Button statusButton; //opens status panel. shows status of characters. TODO: make statuses for familiars 
    [SerializeField] Button fleeButton; //opens flee panel. lets players choose to flee or not.
    public GameObject magicPanel; //magic panel that shows magic skills
    [SerializeField] GameObject statusPanel; //panel that shows the status of characters
    [SerializeField] GameObject fleePanel; //panel that lets players choose to flee or not
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnOffAllPanels();
    }

    //sets status, flee, and magic panels to inactive
    public void TurnOffAllPanels()
    {
        statusPanel.SetActive(false);
        fleePanel.SetActive(false);
        magicPanel.SetActive(false);
    }

    //TODO Go back to overworld
    public void OnFleePressedYes()
    {
        
    }

    //open whatever panel is passed in as a parameter and set it to active
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    //close whatever panel is passed in as a parameter and set it to inactive
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
