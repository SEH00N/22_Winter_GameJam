using System.Runtime.InteropServices;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StageSelectMenu : MonoBehaviour
{
    private Image blockImage = null;

    private void Awake()
    {
        blockImage = DEFINE.StaticCanvas.Find("BlockImage").GetComponent<Image>();
    }

    private void Start()
    {
        InactiveImmediately();

        Active();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
            Active();
    
        if(Input.GetKeyDown(KeyCode.F))
            Inactive();
    }

    public void Active()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(blockImage.DOFade(0f, 0.3f));
        seq.Join(transform.DOMoveY(transform.position.y - 2020, 0.5f));
        seq.Append(transform.DOMoveY(transform.position.y - 1920, 0.05f));
        seq.AppendCallback(() => seq.Kill() );
    }   

    public void Inactive()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOMoveY(transform.position.y - 100, 0.1f));
        seq.Append(transform.DOMoveY(transform.position.y + 1920, 0.5f));
        seq.Join(blockImage.DOFade(1f, 0.3f));
        seq.AppendCallback(() => seq.Kill() );
    }

    public void InactiveImmediately()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOMoveY(transform.position.y - 100, 0));
        seq.Append(transform.DOMoveY(transform.position.y + 1920, 0));
        seq.Join(blockImage.DOFade(1f, 0));
        seq.AppendCallback(() => seq.Kill() );
    }
}
