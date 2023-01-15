using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCanvas : MonoBehaviour
{
    RectTransform transform;
    private void Awake()
    {
        transform = GetComponent<RectTransform>();
    }
    void Update()
    {
        transform.SetAsFirstSibling();
    }
}
