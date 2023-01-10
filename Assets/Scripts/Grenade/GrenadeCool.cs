using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GrenadeCool : MonoBehaviour
{
    Image coolFilter;
    TextMeshProUGUI coolText;
    GrenadeController grenadeController;

    private void Awake()
    {
        coolFilter = GameObject.Find("GrenadeCoolFilter").GetComponent<Image>();
        coolText = GameObject.Find("GrenadeCoolText").GetComponent<TextMeshProUGUI>();
        grenadeController = FindObjectOfType<GrenadeController>();
    }
    private void Start()
    {
        coolFilter.fillAmount = 0;
        coolText.gameObject.SetActive(false);
    }

    public void StartCountCoolMethod()
    {
        StartCoroutine(StartCountCool());
        StartCoroutine(StartCountCoolText());
    }
    IEnumerator StartCountCool()
    {
        coolFilter.fillAmount = 1;
        while (coolFilter.fillAmount > 0)
        {
            coolFilter.fillAmount -= 1 * Time.deltaTime / 5;
            yield return null;
        }
        grenadeController.canThrow = true;
    }
    IEnumerator StartCountCoolText()
    {
        int coolCount = 5;
        coolText.gameObject.SetActive(true);
        while(coolCount > 0)
        {
            yield return new WaitForSeconds(1);
            coolCount--;
            coolText.text = coolCount.ToString();
        }
        coolText.gameObject.SetActive(false);
        
    }
}
