using UnityEngine;

public class ObstacleSeeThrough : MonoBehaviour
{
    ObstacleSpawner obstacleSpawner;
    [SerializeField] private GameObject player;
    [SerializeField] private Material material;

    [Range(0f,1f)] public float alpha = 0.9f;

    Color color;


    // Start is called before the first frame update
    void Start()
    {
        alpha = 0.9f;
        color = material.color;
    }

    // Update is called once per frame
    void Update()
    {
        color.a = alpha;
        material.color = color;
    }
}
