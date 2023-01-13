using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Collider[] detectedColls;
    MeshRenderer meshRenderer;
    public GameObject explosionEffectPrefab;
    public GameObject fireEffectPrefab;
    public GameObject airExplosionEffectPrefab;
    AudioSource audioSource;
    public bool canBoom;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        canBoom = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(canBoom)
        {
            audioSource.Play();
            GameObject explosionEffect = Instantiate(explosionEffectPrefab);
            GameObject fireEffect = Instantiate(fireEffectPrefab);

            explosionEffect.transform.position = this.transform.position;
            fireEffect.transform.position = this.transform.position;
            CalDamage(80f);
            meshRenderer.enabled = false;
            Destroy(this.gameObject, 2f);
        }
        canBoom = false;
    }
    public void Boom()
    {
        canBoom = false;
        audioSource.Play();
        GameObject explosionEffect = Instantiate(explosionEffectPrefab);
        GameObject airExplosionEffect = Instantiate(airExplosionEffectPrefab);

        explosionEffect.transform.position = this.transform.position;
        airExplosionEffect.transform.position = this.transform.position;
        CalDamage(100f);
        meshRenderer.enabled = false;
        Destroy(this.gameObject, 2f);
    }
    private void CalDamage(float damage)
    {
        detectedColls = Physics.OverlapSphere(this.transform.position, 10f); //Àû °¨Áö
        
        foreach(Collider target in detectedColls)
        {
            if(target.gameObject.GetComponent<EnemyBase>())
            {
                EnemyBase targetEnemy = target.GetComponent<EnemyBase>();
                targetEnemy.GetDamage(damage);
            }
            if(target.gameObject.GetComponent<PlayerHP>())
            {
                PlayerHP player = target.GetComponent<PlayerHP>();
                player.GetDamage(80);
            }
        }
    }
}
