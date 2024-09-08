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
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;
        Vector3 viewPos = camera.WorldToViewportPoint(player.transform.position);
        if (viewPos.x < 0.2 || viewPos.x > 0.8 || viewPos.y < 0.2 || viewPos.y > 0.8)
        {
            player.position = new Vector3(0, 5, player.transform.position.z);
        }
        Vector3 movement = new Vector3(playerInput.x, 0, playerInput.y);
        player.AddForce(speed * Time.fixedDeltaTime * movement);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            player.velocity = new Vector3(player.velocity.x, 0, player.velocity.z);
            player.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
}
