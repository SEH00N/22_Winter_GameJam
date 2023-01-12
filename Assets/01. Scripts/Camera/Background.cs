using System.Reflection.Emit;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Background : MonoBehaviour
{
    [SerializeField] List<Color> colors = new List<Color>();
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] float cycleDelay = 0.5f;
    [SerializeField, Range(0f, 100f)] float opacity = 38f;

    private SpriteRenderer foregroundRenderer = null;

    private int currentIndex = 0;

    private Color beforColor;
    private Color targetColor;
    private float timer = 0f;

    private bool changing = false;

    private void Awake()
    {
        foregroundRenderer = transform.Find("Foreground").GetComponent<SpriteRenderer>();
    }

    public void Init()
    {
        foregroundRenderer.color = defaultColor;
        currentIndex = 0;
    }

    public void Stop()
    {
        changing = false;
    }

    private void Update()
    {
        if(changing == false)
            return;

        timer += Time.deltaTime;
        Color tempColor = Vector4.Lerp(beforColor, targetColor, timer / cycleDelay);
        tempColor.a = opacity / 100f;
        foregroundRenderer.color = tempColor;

        if(timer >= cycleDelay)
        {
            timer = 0f;
            beforColor = foregroundRenderer.color;

            currentIndex = (currentIndex + 1) % colors.Count;            
            targetColor = colors[currentIndex];
        }
    }

    public void SetColor()
    {
        changing = true;
    }
}
