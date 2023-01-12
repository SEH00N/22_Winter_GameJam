using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StageSelectMenu : MonoBehaviour
{
    private Image blockImage = null;
    private Button exitButton = null;
    private GameObject stageExitButton = null;

    private void Awake()
    {
        blockImage = DEFINE.StaticCanvas.Find("BlockImage").GetComponent<Image>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();
        stageExitButton = transform.parent.Find("StageExitButton").gameObject;
        
        InactiveImmediately();
    }

    private void Start()
    {
        Active();
    }

    public void Active()
    {
        Sequence seq = DOTween.Sequence();

        AudioManager.Instance.PlaySystem("UISlide");

        seq.Append(blockImage.DOFade(0f, 0.3f));
        seq.Join(transform.DOMoveY(transform.position.y - 2020, 0.5f));
        seq.Append(transform.DOMoveY(transform.position.y - 1920, 0.05f));
        seq.AppendCallback(() => {
            exitButton.interactable = true;
            exitButton.gameObject.SetActive(true);
            seq.Kill();
        });
    }   

    public void Inactive()
    {
        Sequence seq = DOTween.Sequence();

        exitButton.interactable = false;
        exitButton.gameObject.SetActive(false);

        seq.Append(transform.DOMoveY(transform.position.y - 100, 0.1f).OnComplete(() => AudioManager.Instance.PlaySystem("UISlide")));
        seq.Append(transform.DOMoveY(transform.position.y + 1920, 0.5f));
        seq.Join(blockImage.DOFade(1f, 0.3f));
        seq.AppendCallback(() => {
            stageExitButton.SetActive(true);
            seq.Kill();
        });
    }

    public void InactiveImmediately()
    {
        exitButton.interactable = false;
        exitButton.gameObject.SetActive(false);

        transform.position = new Vector3(transform.position.x, transform.position.y + 1920);
        blockImage.color = new Color(blockImage.color.r, blockImage.color.g, blockImage.color.b, 1f);
    }
}
