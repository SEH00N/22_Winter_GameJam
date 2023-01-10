using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StageSelectMenu : MonoBehaviour
{
    private Image blockImage = null;

    private void Awake()
    {
        blockImage = DEFINE.StaticCanvas.Find("BlockImage").GetComponent<Image>();
        
        InactiveImmediately();
    }

    private void Start()
    {
        Active();
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
        transform.position = new Vector3(transform.position.x, transform.position.y + 1920);
        blockImage.color = new Color(blockImage.color.r, blockImage.color.g, blockImage.color.b, 1f);
    }
}
