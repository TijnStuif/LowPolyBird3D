using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private GameObject obstacleParent;
    [SerializeField] private GameObject player;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] AudioManager audioManager;
    private List<GameObject> obstacles = new();
    private List<GameObject> obstaclesToRemove = new();
    private float offset = 25f;
    private float speed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnFirstObstacle();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistanceToPlayer();
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.transform.position = new Vector3(0, 0, obstacle.transform.position.z - speed * Time.deltaTime);
        }
        RemoveObstacles();
    }

    private void SpawnFirstObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], transform.position, Quaternion.identity);
        obstacle.transform.SetParent(obstacleParent.transform);
        obstacles.Add(obstacle);
    }

    private void SpawnObstacle()
    {
        GameObject lastObstacle = obstacles[obstacles.Count - 1];
        Vector3 nextObstaclePosition = new(lastObstacle.transform.position.x, lastObstacle.transform.position.y, lastObstacle.transform.position.z + offset);
        GameObject obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], nextObstaclePosition, Quaternion.identity);
        obstacle.transform.SetParent(obstacleParent.transform);
        obstacles.Add(obstacle);
    }

    private void CheckDistanceToPlayer()
    {
        if (obstacles.Count > 0 && obstacles[0].transform.position.z <= -2.5)
        {
            Destroy(obstacles[0]);
            obstaclesToRemove.Add(obstacles[0]);
            SpawnObstacle();
        }
    }

    private void RemoveObstacles()
    {
        foreach (GameObject obstacle in obstaclesToRemove)
        {
            scoreManager.ScoreLabelUpdate();
            scoreManager.SaveScore();
            audioManager.PlaySFX(audioManager.scoreSound);
            obstacles.Remove(obstacle);
            if (speed < 12f) 
            {
                speed += 1f;
            } 
        }
        obstaclesToRemove.Clear();
    }
}