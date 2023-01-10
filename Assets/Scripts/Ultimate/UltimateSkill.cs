using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateSkill : MonoBehaviour
{
    public BulletSystem bulletSystem;
    public Canvas ultimateSkillCanvas;
    public GameObject crossPrefab;

    public Collider[] detectedColls;
    public List<GameObject> onScreenEnemy = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tick());
    }
    IEnumerator Tick()
    {
        detectedColls = Physics.OverlapSphere(this.transform.position, 100f);
        foreach(Collider target in detectedColls)
        {
            if(target.GetComponent<EnemyBase>())
            {
                onScreenEnemy.Add(target.gameObject);
            }
        }
        yield return new WaitForSeconds(1f);
        onScreenEnemy.Clear();
        StartCoroutine(Tick());
    }
    void UseUltimateSkill()
    {
        ultimateSkillCanvas = GameObject.Find("UltimateSkillCanvas").GetComponent<Canvas>();
        for(int i = 0; i < onScreenEnemy.Count; i++)
        {
            GameObject crossMark = Instantiate(crossPrefab, ultimateSkillCanvas.transform);

            var _crossMark = crossMark.GetComponent<CrossMark>();
            _crossMark.enemyTransform = onScreenEnemy[i].gameObject.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            UseUltimateSkill();
        }
    }
}
