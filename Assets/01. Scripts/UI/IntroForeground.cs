using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroForeground : MonoBehaviour
{
    [SerializeField] List<Color> colors = new List<Color>();
    [SerializeField] float cycleDelay = 0.25f;
    [SerializeField] float alpha = 0.3f;

    private float timer = 0f;
    private int currentIndex = 0;

    private SpriteRenderer spriteRenderer = null;
    private Color targetColor = Color.white;
    private Color beforColor = Color.white;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void Start()
    {
        targetColor = colors[currentIndex];
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Color tempColor = Vector4.Lerp(beforColor, targetColor, timer / cycleDelay);
        tempColor.a = alpha;
        spriteRenderer.color = tempColor;

        if(timer >= cycleDelay)
        {
            timer = 0f;
            beforColor = spriteRenderer.color;

            currentIndex = (currentIndex + 1) % colors.Count;            
            targetColor = colors[currentIndex];
        }
    }
}
