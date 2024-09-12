using UnityEngine;

public class LightMovement : MonoBehaviour
{
    [SerializeField] public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.LookAt(player);
    }
}
