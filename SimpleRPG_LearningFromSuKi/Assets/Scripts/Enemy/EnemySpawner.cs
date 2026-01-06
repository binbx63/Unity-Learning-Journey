using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    public float spawnTime;
    private float spawnTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnTime)
        {
            spawnTimer = 0;
            SpawnEnemy();
        }
    }
    
    void SpawnEnemy()
    {

        GameObject.Instantiate(enemyPrefab, transform.position, quaternion.identity);
    }
}
