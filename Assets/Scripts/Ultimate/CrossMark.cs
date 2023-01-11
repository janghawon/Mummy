using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrossMark : MonoBehaviour
{
    private Camera uiCamera;
    private Canvas canvas;
    private RectTransform rectParent;
    private RectTransform rectHP;

    public Transform enemyTransform;
    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        uiCamera = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectHP = this.gameObject.GetComponent<RectTransform>();
        
    }
    private void Start()
    {
        transform.DORotate(new Vector3(0, 0, 0), 0.5f);
        Destroy(this.gameObject, 0.5f);
    }
    private void Update()
    {
        var screenPos = Camera.main.WorldToScreenPoint(enemyTransform.position);
        if (screenPos.z < 0f)
        {
            screenPos *= -1f;
        }
        var localPos = new Vector2(0, 20);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, uiCamera, out localPos);
        rectHP.localPosition = localPos;
    }
}
