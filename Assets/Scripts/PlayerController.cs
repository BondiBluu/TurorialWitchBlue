using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]

    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private float speed = 5f;
    
    [SerializeField] private InputActionReference move;

    [Header("Player Interaction")]

    [SerializeField] private InputActionReference interact;
    public InteractionController currentInteractble;


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
        if(currentInteractble != null)
        {
            Debug.Log("Pressed.");
        }
    }
}
