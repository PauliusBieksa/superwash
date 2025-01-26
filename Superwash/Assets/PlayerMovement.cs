using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MoveSpeed = 5f;
    //public InputAction PlayerMovement;
    //public InputAction PlayerAttack;
    //public PlayerInput PlayerInteract;
    public InputAction PlayerControls;

    Vector2 MoveDirection = Vector2.zero;

    //private Vector2 MoveInput;
   // private InputAction move;
    //private InputAction fire;

    private void Awake()
    {
      // PlayerControls = new PlayerInput();
    }
    private void OnEnable()
    {
        //move = PlayerControls.Player.move;
        //move.Enable();

        PlayerControls.Enable();
    }

    private void OnDisable() 
    {
        PlayerControls.Disable();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
       // rb.linearVelocity = MoveInput * MoveSpeed;

       MoveDirection = PlayerControls.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("We Fired");
    }
}
