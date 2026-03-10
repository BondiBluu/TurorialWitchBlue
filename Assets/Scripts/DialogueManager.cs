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

    [Header("Dialogue Interaction")]
    public DialogueSO currentDialogue;
    public int currentIndex;


    void Awake()
    {
        TurnOffDialogue();
    }

    public void StartDialogue(DialogueSO chosenDialogue)
    {
        currentDialogue = chosenDialogue;
        currentIndex = 0;

        TurnOnDialogue();
        DisplayDialogue();
    }

     public void DisplayDialogue()
    {
        DialogueLines lines = currentDialogue.dialogueLines[currentIndex];
        dialogue.text = lines.dialogueText;
        dialogueName.text = lines.speaker;
        CheckIfCharacterImageIsNull(characterImage1, lines.characterSprite1);
        CheckIfCharacterImageIsNull(characterImage2, lines.characterSprite2);
    }

    public void NextLine()
    {
        currentIndex++;

        if(currentIndex >= currentDialogue.dialogueLines.Length)
        {
            TurnOffDialogue();
            currentIndex = 0;
            return;
        }

        DisplayDialogue();

    }

    public void CheckIfCharacterImageIsNull(Image characterHolder, Sprite imageForCharacter)
    {
        
        if (imageForCharacter != null)
        {
            characterHolder.gameObject.SetActive(true);
            characterHolder.sprite = imageForCharacter;
        }
        else
        {
            characterHolder.gameObject.SetActive(false);
        }
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
