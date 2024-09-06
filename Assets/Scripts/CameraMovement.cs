using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] public Transform player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + offset.z);
    }
}
