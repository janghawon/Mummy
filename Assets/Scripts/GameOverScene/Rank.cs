using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    public List<Sprite> rankContainer = new List<Sprite>();
    Image spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<Image>();
    }
    private void Start()
    {
        spriteRenderer.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void RateRankSystem(float score)
    {
        spriteRenderer.enabled = true;
        if(score < 10)
        {
            spriteRenderer.sprite = rankContainer[0];
        }
        else if(score >= 10 && score < 40)
        {
            spriteRenderer.sprite = rankContainer[1];
        }
        else if(score >= 40 && score <= 80)
        {
            spriteRenderer.sprite = rankContainer[2];
        }
        else if(score > 80)
        {
            spriteRenderer.sprite = rankContainer[3];
        }
    }
}
