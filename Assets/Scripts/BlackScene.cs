using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class BlackScene : MonoBehaviour
{
    // Start is called before the first frame update
    Image blackScreen;
    RectTransform thisRect;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        blackScreen = GetComponentInChildren<Image>();
        thisRect = GetComponent<RectTransform>();
    }
    void Start()
    {
        StartCoroutine(FillBlack());
    }
    private void Update()
    {
        thisRect.SetAsFirstSibling();
    }

    IEnumerator FillBlack()
    {
        yield return new WaitForSeconds(0.1f);
        blackScreen.transform.DOLocalMoveY(0, 1).SetEase(Ease.OutBounce);

        yield return new WaitForSeconds(1.5f);
        blackScreen.transform.DOLocalMoveY(1140, 1).SetEase(Ease.OutQuad);
    }
}
