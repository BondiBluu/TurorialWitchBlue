using TMPro;
using UnityEngine;
using UnityEngine.UI; 


//manages the dialogue system in the game
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private GameObject dialogueHolder;
    public TMP_Text dialogue;
    public TMP_Text dialogueName;
    public Image characterImage1;
    public Image characterImage2;

    [Header("Dialogue Interaction")]
    public DialogueSO currentDialogue;
    public int currentIndex;

    private static DialogueManager instance;

    //singleton pattern to ensure only one instance of the DialogueManager exists
    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(dialogueCanvas.gameObject);

        TurnOffDialogue();

    }

    //displays the character's dialogue, displaying it in the dialogue panel
    public void StartDialogue(DialogueSO chosenDialogue)
    {
        currentDialogue = chosenDialogue;
        currentIndex = 0;

        TurnOnDialogue();
        DisplayDialogue();
    }

    //displays the current line of dialogue and the character's name and image
    //checks if the character image is null and hides the image if it is
     public void DisplayDialogue()
    {
        DialogueLines lines = currentDialogue.dialogueLines[currentIndex];
        dialogue.text = lines.dialogueText;
        dialogueName.text = lines.speaker;
        CheckIfCharacterImageIsNull(characterImage1, lines.characterSprite1);
        CheckIfCharacterImageIsNull(characterImage2, lines.characterSprite2);
    }

    //goes to the next line of dialogue or turns off the dialogue if there are no more lines
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

    //checks if the character image is null and hides the image if it is
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
