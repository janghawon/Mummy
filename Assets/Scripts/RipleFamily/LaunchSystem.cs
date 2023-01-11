using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LaunchSystem : MonoBehaviour
{
    private RaycastHit hitInfo;
    [SerializeField] private Camera camera;
    public GameObject ParticlePrefab;
    Grenade targetGrenade;
    [SerializeField]
    ReBound reBound;

    private void Awake()
    {
        reBound = FindObjectOfType<ReBound>();
    }



    public void LaunchBullet()
    {
        reBound.Shake(2, 2, 0.1f);
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, 300))
        {
            Debug.Log("??");
            GameObject particle = Instantiate(ParticlePrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            if(hitInfo.collider.gameObject.GetComponent<Grenade>())
            {
                targetGrenade = hitInfo.collider.gameObject.GetComponent<Grenade>();
                targetGrenade.Boom();
            }

            if(hitInfo.collider.gameObject.GetComponent<EnemyBase>())
            {
                EnemyBase targetEnemy = hitInfo.collider.gameObject.GetComponent<EnemyBase>();
                Debug.Log(targetEnemy);
                targetEnemy.GetDamage(20f);
                
            }
            Destroy(particle, 2f);
        }
        
    }
    public Vector3 PosReturn()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, 300))
        {
            Debug.Log("∏Æ≈œ");
        }
        return hitInfo.point;
    }
}
