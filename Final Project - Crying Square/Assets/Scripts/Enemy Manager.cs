using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    float currentTimeBetweenSpawn;

    Transform enemiesParent;

    public static EnemyManager instance;

    private void Awake()
    {
        //This line allows other scripts to call it
        if (instance == null) instance = this;
    }

    private void Start()
    {
        enemiesParent = GameObject.Find("Enemies").transform;

    }

    private void Update()
    {
        currentTimeBetweenSpawn -= Time.deltaTime;

        if (currentTimeBetweenSpawn <= 0)
        {
            SpawnEnemy();
            currentTimeBetweenSpawn = timeBetweenSpawn;
        }
    }

    //Reference https://www.youtube.com/watch?v=IbiwNnOv5So
    Vector2 RandomPosition()
    {
        return new Vector2(Random.Range(-16, 16), Random.Range(-8, 8));
    }
    void SpawnEnemy()
    { 
        var e = Instantiate(enemyPrefab, RandomPosition(), Quaternion.identity);
        e.transform.SetParent(enemiesParent);
    }

    public void DestroyAllEnemies()
    {
        foreach (Transform e in  enemiesParent)
            Destroy(e.gameObject);
            
    }
}
