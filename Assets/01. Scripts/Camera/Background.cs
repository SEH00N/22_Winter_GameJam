using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Background : MonoBehaviour
{
    [SerializeField] List<Color> colors = new List<Color>();
    [SerializeField] float colorChangeDuration = 0.5f;
    [SerializeField, Range(0f, 100f)] float opacity = 38f;

    private SpriteRenderer backgroundRenderer = null;
    private SpriteRenderer foregroundRenderer = null;

    private Sequence seq = null;

    private void Awake()
    {
        backgroundRenderer = GetComponent<SpriteRenderer>();
        foregroundRenderer = transform.Find("Foreground").GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        colors[0] = foregroundRenderer.color;
    }

    public void Reset()
    {
        if(seq.active)
            seq.Kill();

        foregroundRenderer.color = colors[0];
    }

    public void SetRandomColor()
    {
        seq = DOTween.Sequence();

        Color targetColor = colors[Random.Range(0, colors.Count)];
        targetColor.a = opacity / 100f;
        seq.Append(foregroundRenderer.DOColor(targetColor, colorChangeDuration));
        seq.AppendCallback(() => {
            seq.Kill();
        });       
    }
}
