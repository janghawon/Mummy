using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    public LaunchSystem launch;
    public LineRenderer line;
    Vector3 RipleHeadPos, TargetPos;
    [SerializeField] private GameObject launchEffectPrefab;
    private void Awake()
    {
        launch = FindObjectOfType<LaunchSystem>();
        line = GetComponent<LineRenderer>();
        line.startWidth = 0.01f;
        line.endWidth = 0.01f;

        
    }
    public void MakeAfterImage()
    {
        RipleHeadPos = gameObject.GetComponent<Transform>().position;
        TargetPos = launch.LaunchBullet();

        GameObject launchEffect = Instantiate(launchEffectPrefab, RipleHeadPos, Quaternion.LookRotation(RipleHeadPos.normalized));
        Destroy(launchEffect, 1f);

        line.SetPosition(0, RipleHeadPos);
        line.SetPosition(1, TargetPos);
        StartCoroutine(FadeAfterImage());
    }
    IEnumerator FadeAfterImage()
    {
        line.material.color = new Color(0.7f, 0.7f, 0.7f, 1);
        line.material.ToFadeMode();
        for (float f = 1; f > 0; f -= 0.005f)
        {
            Color color = line.material.color;
            
            color.a = f;
            line.material.color = color ;
            yield return null;
        }

    }
}
public static class MaterialExtensions
{
    public static void ToFadeMode(this Material material)
    {
        material.SetOverrideTag("RenderType", "Transparent");
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
    }
}