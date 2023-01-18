using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpBtnInner : MonoBehaviour
{
    Canvas helpCanvas;
    private void Awake()
    {
        helpCanvas = GetComponentInParent<Canvas>();
    }
    public void ExitHelp()
    {
        Destroy(helpCanvas.gameObject);
    }
}
