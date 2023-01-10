using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
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
        meshRenderer.enabled = false;
        Destroy(this.gameObject, 2f);
    }
}