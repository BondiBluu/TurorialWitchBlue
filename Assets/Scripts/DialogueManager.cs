using TMPro;
using UnityEngine;
using UnityEngine.UI; 



public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueHolder;
    public TMP_Text dialogue;
    public TMP_Text dialogueName;
    public Image characterImage1;
    public Image characterImage2;

    void Awake()
    {
        TurnOffDialogue();
    }

    public void TurnOnDialogue()
    {
        dialogueHolder.SetActive(true);
    }

    public void TurnOffDialogue()
    {
        dialogueHolder.SetActive(false);
    }

    public bool IsDialogueActive()
    {
        return dialogueHolder.activeSelf;
    }
}
