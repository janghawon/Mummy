using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyContainer = new List<GameObject>();
    int num;
    public void SpawnEnemy(int enemyNum)
    {
        float randomX = Random.Range(-50, 43);
        float randomZ = Random.Range(-50, 43);
        GameObject enemy = Instantiate(EnemyContainer[enemyNum]);
        EnemyBase eb = enemy.GetComponent<EnemyBase>();
        eb.SetHpBar(num);
        enemy.transform.position = new Vector3(randomX, 8, randomZ);
        num++;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SpawnEnemy(0);
        }
    }
}
