using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    private bool playerInRange;
    private DialogueManager dialogueManager;
    public DialogueSO objectDialogue;

    void Start()
    {
        dialogueManager = FindAnyObjectByType<DialogueManager>();
    }

    public void PlayDialogue()
    {
        dialogueManager.StartDialogue(objectDialogue);
         
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("In position");
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in range");
            collision.GetComponent<PlayerController>().currentInteractble = this;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Out of position");
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player out of range");
            collision.GetComponent<PlayerController>().currentInteractble = null;
        }
    }

    public bool PlayerInRange()
    {
        return playerInRange;
    }
}
