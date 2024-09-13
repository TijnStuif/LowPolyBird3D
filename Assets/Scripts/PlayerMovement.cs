using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    private Vector2 playerInput;
    [SerializeField] private float speed;
    [SerializeField] new private Camera camera;
    [SerializeField] AudioManager audioManager;
    Animator animator;
    private bool isOnScreen;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;
        Vector3 movement = new Vector3(playerInput.x, 0, playerInput.y);
        CheckOnScreen();
        player.AddForce(speed * Time.fixedDeltaTime * movement);
        DoSidewaysRotation();
        CheckFallingVelocity();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // This if-statement causes the player to stop moving in a y-direction, and then give them upwards jumping momentum
        if (context.performed && isOnScreen)
        {
            player.velocity = new Vector3(player.velocity.x, 0, player.velocity.z);
            player.AddForce(Vector3.up * 5, ForceMode.Impulse);
            animator.SetTrigger("TriggerJump");
            animator.SetBool("IsJumping", true);
            audioManager.PlaySFX(audioManager.jumpSound);
        }
    }

    private void CheckOnScreen()
    {
        Vector3 viewPos = camera.WorldToViewportPoint(player.transform.position);
        // This if-statement prevents exploitation of the system by sending the player back on the screen if they leave it
        if (viewPos.x < 0.08 || viewPos.x > 0.92 || viewPos.y < 0.08 || viewPos.y > 0.92)
        {
            player.position = new Vector3(0, 5, 0);
        }
        // These following if-statements cause the player to bounce from the walls
        if (viewPos.x < 0.1 || viewPos.x > 0.9)
        {
            if (isOnScreen)
            {
                isOnScreen = false;
                player.velocity = new Vector3(player.velocity.x * -0.5f, player.velocity.y, player.velocity.z);
            }
        }
        else if (viewPos.y < 0.1 || viewPos.y > 0.9)
        {
            if (isOnScreen)
            {
                isOnScreen = false;
                player.velocity = new Vector3(player.velocity.x, player.velocity.y * -0.5f, player.velocity.z);
            }
        } else isOnScreen = true;
    }

    private void DoSidewaysRotation()
    {
        Vector3 newRotation = new(0, 0, player.velocity.x * Time.deltaTime * speed * -0.5f);
        if (newRotation.z > 45 || newRotation.z < -45) return;
        player.rotation = Quaternion.Euler(newRotation);
    }

    private void CheckFallingVelocity()
    {
        if (player.velocity.y <= -2)
        {
            animator.SetBool("IsJumping", false);
        }
    }
}
