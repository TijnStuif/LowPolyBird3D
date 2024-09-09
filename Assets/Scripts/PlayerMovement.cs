using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody player;
    private Vector2 playerInput;
    [SerializeField] private float speed;
    [SerializeField] new private Camera camera;
    private bool isOnScreen;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;
        Vector3 movement = new Vector3(playerInput.x, 0, playerInput.y);
        CheckOnScreen();
        player.AddForce(speed * Time.fixedDeltaTime * movement);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isOnScreen)
        {
            player.velocity = new Vector3(player.velocity.x, 0, player.velocity.z);
            player.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }

    private void CheckOnScreen()
    {
        Vector3 viewPos = camera.WorldToViewportPoint(player.transform.position);
        if (viewPos.x < 0.22 || viewPos.x > 0.78)
        {
            if (isOnScreen)
            {
                isOnScreen = false;
                player.velocity = new Vector3(player.velocity.x * -1, player.velocity.y, player.velocity.z);
            }
        }
        else if (viewPos.y < 0.22 || viewPos.y > 0.78)
        {
            if (isOnScreen)
            {
                isOnScreen = false;
                player.velocity = new Vector3(player.velocity.x, player.velocity.y * -1, player.velocity.z);
            }
        } else isOnScreen = true;
    }
}
