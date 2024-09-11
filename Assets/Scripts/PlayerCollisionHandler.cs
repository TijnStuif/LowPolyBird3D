using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] AudioManager audioManager;

    private void OnCollisionEnter(Collision trigger)
    {
        if (trigger.gameObject.CompareTag("BirdKiller"))
        {
            audioManager.PlaySFX(audioManager.deathSound);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
