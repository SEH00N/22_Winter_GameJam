using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TitleColor : MonoBehaviour
{
    [SerializeField] float cycleDelay = 0.5f;
    [SerializeField] float glowOpacity = 0.6f;
    private Material material = null;
    private Color targetColor = Color.white;
    private Color beforColor = Color.white;

    private float timer = 0f;

    private void Awake()
    {
        material = GetComponent<TextMeshProUGUI>().fontMaterial;
        beforColor = material.GetColor(ShaderUtilities.ID_GlowColor);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Color tempColor = Vector4.Lerp(beforColor, targetColor, timer / cycleDelay);
        tempColor.a = glowOpacity;
        material.SetColor(ShaderUtilities.ID_GlowColor, tempColor);

        if(timer >= cycleDelay)
        {
            timer = 0f;
            beforColor = material.GetColor(ShaderUtilities.ID_GlowColor);
            targetColor = Random.ColorHSV();
        }

    }
}
