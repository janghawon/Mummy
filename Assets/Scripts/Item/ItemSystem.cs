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
    public GameObject DropItem()
    {
        percentCal = Random.Range(0, 100);
        if(percentCal < 5)
        {
            randomItemSelecter = Random.Range(0, 4);

            switch (randomItemSelecter)
            {
                case 0:
                    return itemContainer[0];

                case 1:
                    return itemContainer[1];

                case 2:
                    return itemContainer[2];

                case 3:
                    return itemContainer[3];
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
    IEnumerator BuffOff(int buffKinds)
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

        }
        
    }
}
