using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision trigger)
    {
        if (trigger.gameObject.CompareTag("BirdKiller"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
