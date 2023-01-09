using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSystem : MonoBehaviour
{
    private RaycastHit hitInfo;
    [SerializeField] private Camera camera;
    public GameObject ParticlePrefab;

   

    public void LaunchBullet()
    {
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, 30))
        {
            GameObject particle = Instantiate(ParticlePrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(particle, 2f);
        }
    }
}
