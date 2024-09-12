using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] AudioManager audioManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private EndScreen endScreen;

    private void OnCollisionEnter(Collision trigger)
    {
        if (trigger.gameObject.CompareTag("BirdKiller"))
        {
            audioManager.PlaySFX(audioManager.deathSound);
            endScreen.Enable();
            scoreManager.Disable();
        }
    }
}
