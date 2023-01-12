using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PerecentManager : MonoBehaviour
{
    TextMeshProUGUI perecentText;
    Image fullChargeIcon;
    public Image percentCircle;

    
    public int percentage;
    public float timeAndScore;
    public bool canUseUltimateSkill;
    
    private void Awake()
    {
        perecentText = GameObject.Find("Precent").GetComponent<TextMeshProUGUI>();
        fullChargeIcon = GameObject.Find("UltimateIcon").GetComponent<Image>();
        percentCircle = GameObject.Find("PrecentCircle").GetComponent<Image>();
    }
    private void Start()
    {
        percentCircle.fillAmount = 0;
        percentage = 0;
        perecentText.text = percentage.ToString() + "%";
        fullChargeIcon.gameObject.SetActive(false);
    }
    public void GetScore(float score)
    {
        if(!canUseUltimateSkill)
            timeAndScore += score / 10;
    }
    private void Update()
    {
        if(percentCircle.fillAmount < 1 )
        {
            if(!canUseUltimateSkill)
            {
                timeAndScore += Time.deltaTime;
                percentCircle.fillAmount = timeAndScore / 100;
                fullChargeIcon.gameObject.SetActive(false);
                percentage = Mathf.CeilToInt(timeAndScore);
                perecentText.text = percentage.ToString() + "%";

                canUseUltimateSkill = false;
            }
        }
        else
        {
            canUseUltimateSkill = true;
        }


        if(canUseUltimateSkill)
        {
            percentCircle.gameObject.SetActive(false);
            perecentText.gameObject.SetActive(false);

            fullChargeIcon.gameObject.SetActive(true);
        }
        else if(!canUseUltimateSkill)
        {
            percentCircle.gameObject.SetActive(true);
            perecentText.gameObject.SetActive(true);

            fullChargeIcon.gameObject.SetActive(false);
        }
    }
}
