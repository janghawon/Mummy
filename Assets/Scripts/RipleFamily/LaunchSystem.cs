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
   

    public Vector3 LaunchBullet()
    {
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, 300))
        {
            GameObject particle = Instantiate(ParticlePrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            if(hitInfo.collider.gameObject.GetComponent<Grenade>())
            {
                targetGrenade = hitInfo.collider.gameObject.GetComponent<Grenade>();
                targetGrenade.Boom();
            }
            Destroy(particle, 2f);
        }
        return hitInfo.point;
    }
}
