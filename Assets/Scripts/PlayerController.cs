using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;

    [Header("Player Movement")]

    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private float speed = 5f;
    
    [SerializeField] private InputActionReference move;

    [Header("Player Interaction")]

    [SerializeField] private InputActionReference interact;
    public Interaction currentInteractble;
    public DialogueManager dialogueManager;

    
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        //don't destroy the player object when loading a new scene
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

    private void OnEnable()
    {
        interact.action.started += OnInteract;
    }

    
    private void OnDisable()
    {
        interact.action.started -= OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (dialogueManager.IsDialogueActive())
        {
            dialogueManager.NextLine();
            return;
        }

        if(currentInteractble != null)
        {
            Debug.Log("Pressed.");
            currentInteractble.PlayDialogue();
            
        }
    }
}
