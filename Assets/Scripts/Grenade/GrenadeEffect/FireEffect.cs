using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    AudioSource audioSource;
    ParticleSystem particle;
    Collider[] onFireRange;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        audioSource.Play();
        StartCoroutine(TickDam());
        Destroy(this.gameObject, 6f);
        //StartCoroutine(FadeOut());
    }
    
    IEnumerator TickDam()
    {
        onFireRange = Physics.OverlapSphere(this.transform.position, 10f);
        foreach (Collider target in onFireRange)
        {
            if (target.gameObject.GetComponent<EnemyBase>())
            {
                EnemyBase targetEnemy = target.GetComponent<EnemyBase>();
                targetEnemy.GetDamage(5f);
            }
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(TickDam());
    }

}
