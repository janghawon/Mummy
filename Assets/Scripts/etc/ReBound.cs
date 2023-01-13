using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FD.Dev;

public class ReBound : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    public CinemachineBasicMultiChannelPerlin cbmcp;

    private void Awake()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        cbmcp = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void Start()
    {
        cbmcp.m_AmplitudeGain = 0;
        cbmcp.m_FrequencyGain = 0;
    }

    public void Shake(float value, float shame, float duration)
    {
        FAED.InvokeDelay(() =>
        {
            cbmcp.m_AmplitudeGain -= value;
            cbmcp.m_FrequencyGain -= shame;
        }, duration);
        cbmcp.m_AmplitudeGain += value;
        cbmcp.m_FrequencyGain -= shame;
    }
}
