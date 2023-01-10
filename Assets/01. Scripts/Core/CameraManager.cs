using System.Net.Security;
using System.Collections;
using Cinemachine;
using UnityEngine;
using static DEFINE;

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

    private float x;
    private float y;

    public float Bottom => MainCam.transform.position.y - y;
    public float Top => MainCam.transform.position.y + y;
    public float Left => MainCam.transform.position.x - x;
    public float Right => MainCam.transform.position.x + x;

    private CinemachineVirtualCamera cmMainCam = null;
    private CinemachineBasicMultiChannelPerlin perlin = null;
    private bool onShake = false;

    private void Awake()
    {
        cmMainCam = DEFINE.CmMainCam;
        // perlin = cmMainCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        y = MainCam.orthographicSize;
        x = MainCam.orthographicSize * Screen.width / Screen.height;
    }

    private void Start()
    {
        // perlin.m_AmplitudeGain = 0f;
        // perlin.m_FrequencyGain = 0f;
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
