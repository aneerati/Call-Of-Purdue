using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject enemy;
    private float spawnTik = 15.0f;
    private float time = 0.0f;
    private int round = 1;
    
    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnTik) {
            GameObject newObject = Instantiate(enemy, new Vector2(Random.Range(transform.position.x-3,transform.position.x+3), Random.Range(transform.position.y-1,transform.position.y+1)), transform.rotation);
            time = 0.0f;
            Enemy newEnemy = newObject.GetComponent<Enemy>();
            newEnemy.health += Mathf.Abs(Random.Range(-round * 3, round * 6));
            newEnemy.damage += Mathf.Abs(Random.Range(-round/2, round));
            newEnemy.speed += Mathf.Abs(Random.Range(-round/2, round));
            newEnemy.radius *= 0.99f;
            round += 1;
            spawnTik *= 0.999f;
        }
    }
}
