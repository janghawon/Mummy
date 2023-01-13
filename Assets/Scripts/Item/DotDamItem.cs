using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDamItem : ItemBase
{
    public GameObject playerPosition;
    public Collider[] rangeInEnemy;
    [SerializeField] GameObject effectPrefab;
    public override void GiveEffect()
    {
        StartCoroutine(DamTurm());
    }
    IEnumerator DamTurm()
    {
        playerPosition = GameObject.Find("PlayerPosition");
        rangeInEnemy = Physics.OverlapSphere(playerPosition.transform.position, 30);
        foreach (Collider enemy in rangeInEnemy)
        {
            if (enemy.gameObject.GetComponent<EnemyBase>())
            {
                EnemyBase targetEnemy = enemy.GetComponent<EnemyBase>();
                GameObject effect = Instantiate(effectPrefab);
                effect.transform.position = targetEnemy.transform.position;
                targetEnemy.GetDamage(20);
            }
        }
    }
}
