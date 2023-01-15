using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOverManager : MonoBehaviour
{
    GameObject overPannel;
    public RectTransform pannelTransform;
    private void Awake()
    {
        overPannel = GameObject.Find("OverPannel");
        pannelTransform = overPannel.GetComponent<RectTransform>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           // Debug.Log(1);
            pannelTransform.transform.DOLocalMoveY(0f, 0.7f).SetEase(Ease.OutBounce);
        }
    }
    public void YesBtn()
    {

    }
    public void NoBtn()
    {
        pannelTransform.localPosition = new Vector3(0, -860, 0);
    }
}
