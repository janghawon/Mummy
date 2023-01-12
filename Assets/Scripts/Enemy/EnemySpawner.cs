using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyContainer = new List<GameObject>();
    public int num;
    
    public void SpawnEnemyBefore(int number)
    {
        StartCoroutine(SpawnEnemy(number));
    }
    IEnumerator SpawnEnemy(int number)
    {
        for(int i = 0; i < number; i++)
        {
            float randomX = Random.Range(-50, 43);
            float randomZ = Random.Range(-50, 43);
            GameObject enemy = Instantiate(EnemyContainer[0]);
            EnemyBase eb = enemy.GetComponent<EnemyBase>();
            Debug.Log(num);
            eb.SetHpBar(num);
            enemy.transform.position = new Vector3(randomX, 8, randomZ);
            num++;
            yield return null;
        }
         
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SpawnEnemyBefore(1);
        }
    }

}
