using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 moveDirection = Vector2.zero; //Atajo de (X:0;Y:0)
    private PlayerInputsAction playerControls;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputsAction();
    }

    private void OnEnable()
    {
        //Podría ser cualquier actionMap, por ejemplo Ui en vez de Player.
        //objeto.ActionMap.Action
        playerControls.Player.Move.Enable();
       

        //Suscribe la función Fire al event system del nuevo Input System.
        //Cuando el jugador aprete la tecla de Fire se ejecuta el evento Fire() de esta clase.
       // playerControls.Player.Fire.performed += Fire;
    }

    private void OnDisable()
    {
        playerControls.Player.Move.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}
