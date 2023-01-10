using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class EndingUI : MonoBehaviour
{
    private GameObject background = null;
    private GameObject nextObject = null;
    private TextMeshProUGUI endingText = null;
    private TextMeshProUGUI stageText = null;
    private StageLoadCallback nextButtonCallback = null;
    private Button nextButton = null;

    private void Awake()
    {
        background = transform.Find("Background").gameObject;
        nextObject = transform.Find("UI/Next").gameObject;

        endingText = transform.Find("UI/EndingText").GetComponent<TextMeshProUGUI>();
        stageText = transform.Find("UI/StageText").GetComponent<TextMeshProUGUI>();

        nextButton = nextObject.transform.Find("NextButton").GetComponent<Button>();
        nextButtonCallback = nextButton.GetComponent<StageLoadCallback>();
    }

    private void Start()
    {
        InactiveImmediately();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            Active();

        if(Input.GetKeyDown(KeyCode.S))
            Inactive();
    }

    public void Init(int stageIndex)
    {
        stageText.text = $"{stageIndex + 1}/{StageManager.Instance.StageCount}";

        nextButtonCallback.SetStage(stageIndex + 2);
    }

    //클리어할 때
    public void Active()
    {
        Sequence seq = DOTween.Sequence();
        
        background.SetActive(true);

        seq.AppendInterval(0.3f);
        seq.Append(nextObject.transform.DOMoveY(nextObject.transform.position.y - 1920f, 0.3f).SetEase(Ease.Linear));
        seq.Append(stageText.transform.DOMoveY(stageText.transform.position.y - 1920f, 0.3f).SetEase(Ease.Linear));
        seq.Append(endingText.transform.DOMoveY(endingText.transform.position.y - 1920f, 0.3f).SetEase(Ease.Linear))
            .AppendInterval(0.3f)
            .AppendCallback(() => {
                nextButton.interactable = true;
                seq.Kill();
            });
    }

    //다음 스테이지 밑 나가기 눌렀을 때
    public void Inactive()
    {
        Sequence seq = DOTween.Sequence();
        
        nextButton.interactable = false;

        seq.AppendInterval(0.3f);
        seq.Append(endingText.transform.DOMoveY(endingText.transform.localPosition.y + 1920f, 0.3f).SetEase(Ease.Linear));
        seq.Append(stageText.transform.DOMoveY(stageText.transform.localPosition.y + 1920f, 0.3f).SetEase(Ease.Linear));
        seq.Append(nextObject.transform.DOMoveY(nextObject.transform.localPosition.y + 1920f, 0.3f).SetEase(Ease.Linear))
            .AppendInterval(0.3f)
            .AppendCallback(() => {
                background.SetActive(false);
                seq.Kill();
            });
    }

    public void InactiveImmediately()
    {
        Sequence seq = DOTween.Sequence();
        
        nextButton.interactable = false;

        seq.Append(endingText.transform.DOMoveY(endingText.transform.localPosition.y + 1920f, 0).SetEase(Ease.Linear));
        seq.Append(stageText.transform.DOMoveY(stageText.transform.localPosition.y + 1920f, 0).SetEase(Ease.Linear));
        seq.Append(nextObject.transform.DOMoveY(nextObject.transform.localPosition.y + 1920f, 0).SetEase(Ease.Linear))
            .AppendCallback(() => {
                background.SetActive(false);
                seq.Kill();
            });
    }
}