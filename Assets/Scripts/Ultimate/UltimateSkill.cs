using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UltimateSkill : MonoBehaviour
{
    public BulletSystem bulletSystem;
    public Canvas ultimateSkillCanvas;
    public GameObject crossPrefab;
    public Image UltimateScrren;

    public Collider[] detectedColls;
    public List<GameObject> onScreenEnemy = new List<GameObject>();
    private RectTransform screen_Rect;
    bool isUltimate;
    float fadeCount;
    // Start is called before the first frame update
    private void Awake()
    {
        bulletSystem = FindObjectOfType<BulletSystem>();
        UltimateScrren = GameObject.Find("Ultimate_Screen").GetComponent<Image>();
        UltimateScrren.enabled = false;
        screen_Rect = UltimateScrren.GetComponent<RectTransform>();
        fadeCount = 0;

    }
    void Start()
    {
        StartCoroutine(Tick());
        screen_Rect.sizeDelta = new Vector2(1920f, 310f);
        UltimateScrren.color = new Color(1, 1, 1, fadeCount);
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
        bulletSystem.useUltimate = true;
        bulletSystem.bulletCountText.text = "¡Ä";
        bulletSystem.atkCool = 0.1f;
        UltimateScrren.enabled = true;
        isUltimate = true;
        StartCoroutine(UseSkill());
        StartCoroutine(UseSkill2());
        StartCoroutine(UltimateSystem());
    }
    IEnumerator UltimateSystem()
    {
        if(isUltimate)
        {
            ultimateSkillCanvas = GameObject.Find("UltimateSkillCanvas").GetComponent<Canvas>();
            for (int i = 0; i < onScreenEnemy.Count; i++)
            {
                GameObject crossMark = Instantiate(crossPrefab, ultimateSkillCanvas.transform);

                var _crossMark = crossMark.GetComponent<CrossMark>();
                _crossMark.enemyTransform = onScreenEnemy[i].gameObject.transform;
            }
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(UltimateSystem());
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            UseUltimateSkill();
        }
        
            
    }
    IEnumerator UseSkill()
    {
        while (isUltimate)
        {
            screen_Rect.sizeDelta = new Vector2(1920, Mathf.Lerp(screen_Rect.sizeDelta.y, 1080f, Time.deltaTime * 10));
            
            yield return null;
        }
        
    }
    IEnumerator UseSkill2()
    {
        while (fadeCount < 1)
        {
            fadeCount += 0.1f;
            UltimateScrren.color = new Color(1, 1, 1, fadeCount);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
