using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance = null;
    public static CameraManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<CameraManager>();
            return instance;
        }
    }

    private CinemachineVirtualCamera cmMainCam = null;
    private CinemachineBasicMultiChannelPerlin perlin = null;
    private bool onShake = false;

    private void Awake()
    {
        cmMainCam = DEFINE.CmMainCam;
        perlin = cmMainCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Start()
    {
        perlin.m_AmplitudeGain = 0f;
        perlin.m_FrequencyGain = 0f;
    }

    public void ShakeCam(float duration, float power, float frequency)
    {
        if(onShake) return;

        onShake = true;
        perlin.m_AmplitudeGain = power;
        perlin.m_FrequencyGain = frequency;

        StartCoroutine(PerlinResetCoroutine(duration));
    }

    private IEnumerator PerlinResetCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        perlin.m_AmplitudeGain = 0f;
        perlin.m_FrequencyGain = 0f;

        onShake = false;
    }
}
