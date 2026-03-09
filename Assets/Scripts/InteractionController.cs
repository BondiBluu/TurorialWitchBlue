using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private bool playerInRange;
    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindAnyObjectByType<DialogueManager>();
    }


    public void DisplayMessage()
    {
        dialogueManager.TurnOnDialogue();
        dialogueManager.dialogue.text = "Message here.";
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
