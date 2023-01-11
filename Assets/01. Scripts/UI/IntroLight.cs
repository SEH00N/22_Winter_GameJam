using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class IntroLight : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    private float deg = 0f;

    [SerializeField] float cycleDelay = 0.5f;
    private Light2D light2D = null;
    private float timer = 10f;

    private Color targetColor = Color.white;
    private Color beforColor = Color.white;

    private void Awake()
    {
        light2D = transform.GetChild(0).GetComponent<Light2D>();
    }

    private void Update()
    {
        deg += Time.deltaTime * speed * 360f;

        transform.rotation = Quaternion.AngleAxis(deg, Vector3.forward);

        timer += Time.deltaTime;
        Color tempColor = Vector4.Lerp(beforColor, targetColor, timer / cycleDelay);
        tempColor.a = 1f;
        light2D.color = tempColor;

        if(timer >= cycleDelay)
        {
            timer = 0f;
            beforColor = light2D.color;
            targetColor = Random.ColorHSV();
        }
    }
}
