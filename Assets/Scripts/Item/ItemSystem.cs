using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    public List<GameObject> itemContainer = new List<GameObject>();
    int percentCal;
    int randomItemSelecter;
    public LaunchSystem riple;
    public BulletSystem bullet;
    DotDamItem dotDamItem;

    public GameObject playerPosition;
    public Collider[] rangeInEnemy;
    [SerializeField] GameObject effectPrefab;
    public bool canDeal;
    public GameObject DropItem()
    {
        percentCal = Random.Range(0, 100);
        Debug.Log(percentCal);
        if (percentCal < 10)  //100
        {
            randomItemSelecter = Random.Range(0, 4);

            switch (randomItemSelecter)
            {
                case 0:
                    return itemContainer[0]; //0

                case 1:
                    return itemContainer[1]; //1

                case 2:
                    return itemContainer[2]; //2

                case 3:
                    return itemContainer[3]; //3
            }
        }
        return itemContainer[4];
    }

    public void DamageBuff()
    {
        riple = FindObjectOfType<LaunchSystem>();
        riple.attackDamage += 20;
        StartCoroutine(BuffOff(0));
    }
    public void AtkSpeedBuff()
    {
        bullet = FindObjectOfType<BulletSystem>();
        float futureAttackCool = 0;
        futureAttackCool = bullet.atkCool - 0.15f;

        if (futureAttackCool < 0)
        {
            bullet.atkCool = 0;
        }
        else
        {
            bullet.atkCool -= 0.15f;
        }
        StartCoroutine(BuffOff(1));
    }
    public void DotDamBuff()
    {
        StartCoroutine(BuffOff(2));
        canDeal = true;
        StartCoroutine(DamTurm());
    }
    IEnumerator DamTurm()
    {
        if (canDeal)
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
        yield return new WaitForSeconds(2);
        StartCoroutine(DamTurm());
    }
    public IEnumerator BuffOff(int buffKinds)
    {
        switch(buffKinds)
        {
            case 0:
                yield return new WaitForSeconds(10);
                riple.attackDamage -= 20;
                break;

            case 1:
                yield return new WaitForSeconds(10);
                bullet.atkCool += 0.15f;
                break;
            case 2:
                yield return new WaitForSeconds(10);
                Debug.Log("버프 끝남");
                canDeal = false;
                break;

        }
        
    }
}
