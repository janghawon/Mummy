using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    [SerializeField] Transform target;
    public GameObject grenadePrefab;
    Rigidbody rigid;
    public bool canThrow;
    Vector3 throwSpeed = new Vector3(0, 200, 2000);
    public PlayerSoundManager soundManager;
    GrenadeCool coolTime;

    private void Start()
    {
        coolTime = FindObjectOfType<GrenadeCool>();
        soundManager = GameObject.Find("PlayerSoundManager").GetComponent<PlayerSoundManager>();
        canThrow = true;
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canThrow)
        {
            
            StartCoroutine(ThrowGrenade());
            coolTime.StartCountCoolMethod();
        }
    }
    IEnumerator ThrowGrenade()
    {

        canThrow = false;
        GameObject grenade = Instantiate(grenadePrefab);
        grenade.transform.position = Camera.main.transform.position;
        rigid = grenade.GetComponent<Rigidbody>();
        //rigid.isKinematic = true;

        Vector3 dir = target.transform.position - Camera.main.transform.position;
        dir.Normalize();
        Debug.Log(Camera.main.transform.forward);
        rigid.AddForce( Camera.main.transform.forward * 30, ForceMode.Impulse);
        soundManager.PlaySound(0);
        yield return new WaitForSeconds(5f);
    }
}
