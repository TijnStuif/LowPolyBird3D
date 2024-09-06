using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartPlatform : MonoBehaviour
{
    [SerializeField] Transform startPlatform;
    private float startLevelCounter = 0;
    private float movementMultiplier = -0.33f;
    private float platformMovementDown;
    // Start is called before the first frame update
    void Start()
    {
        platformMovementDown = startPlatform.position.y * movementMultiplier * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(startPlatform.position.y);
        if (startLevelCounter >= 3)
        {
            Destroy(gameObject);
        }
        startLevelCounter += Time.deltaTime;
        
        startPlatform.position = new Vector3(startPlatform.position.x, startPlatform.position.y + platformMovementDown, startPlatform.position.z);
    }
}
