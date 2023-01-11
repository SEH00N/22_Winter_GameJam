using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfinityModeUI : MonoBehaviour
{
    private GameObject background = null;
    private GameObject restartObject = null;
    private GameObject exitObject = null;

    private TextMeshProUGUI endingText = null;
    private TextMeshProUGUI scoreText = null;

    private Button restartButton = null;
    private Button exitButton = null;

    private void Awake()
    {
        background = transform.Find("Background").gameObject;
        restartObject = transform.Find("UI/Restart").gameObject;
        exitObject = transform.Find("UI/Exit").gameObject;

        endingText = transform.Find("UI/EndingText").GetComponent<TextMeshProUGUI>();
        scoreText = transform.Find("UI/ScoreText").GetComponent<TextMeshProUGUI>();

        restartButton = restartObject.transform.Find("RestartButton").GetComponent<Button>();
        exitButton = exitObject.transform.Find("ExitButton").GetComponent<Button>();
    }

    public void Init(int score)
    {
        scoreText.text = $"SCORE\n{score}";
    }

    public void Active()
    {
        Sequence seq = DOTween.Sequence();
        
        background.SetActive(true);

        seq.AppendInterval(0.3f);
        seq.Append(restartObject.transform.DOMoveY(restartObject.transform.position.y - 1920f, 0.3f).SetEase(Ease.Linear));
        seq.Join(exitObject.transform.DOMoveY(exitObject.transform.position.y - 1920f, 0.3f).SetEase(Ease.Linear));
        seq.Append(scoreText.transform.DOMoveY(scoreText.transform.position.y - 1920f, 0.3f).SetEase(Ease.Linear));
        seq.Append(endingText.transform.DOMoveY(endingText.transform.position.y - 1920f, 0.3f).SetEase(Ease.Linear))
            .AppendInterval(0.3f)
            .AppendCallback(() => {
                exitButton.interactable = true;
                restartButton.interactable = true;
                seq.Kill();
            });
    }

    public void Inactive()
    {
        Sequence seq = DOTween.Sequence();
        
        restartButton.interactable = false;
        exitButton.interactable = true;

        seq.AppendInterval(0.3f);
        seq.Append(endingText.transform.DOMoveY(endingText.transform.position.y + 1920f, 0.3f).SetEase(Ease.Linear));
        seq.Append(scoreText.transform.DOMoveY(scoreText.transform.position.y + 1920f, 0.3f).SetEase(Ease.Linear));
        seq.Append(restartObject.transform.DOMoveY(restartObject.transform.position.y + 1920f, 0.3f).SetEase(Ease.Linear));
        seq.Join(exitObject.transform.DOMoveY(exitObject.transform.position.y + 1920f, 0.3f).SetEase(Ease.Linear))
            .AppendInterval(0.3f)
            .AppendCallback(() => {
                background.SetActive(false);
                seq.Kill();
            });
    }

    public void InactiveImmediately()
    {
        restartButton.interactable = false;
        exitButton.interactable = false;
        background.SetActive(false);

        endingText.transform.position = new Vector3(endingText.transform.position.x, endingText.transform.position.y + 1920f);
        scoreText.transform.position = new Vector3(scoreText.transform.position.x, scoreText.transform.position.y + 1920f);
        restartObject.transform.position = new Vector3(restartObject.transform.position.x, restartObject.transform.position.y + 1920f);
        exitObject.transform.position = new Vector3(exitObject.transform.position.x, exitObject.transform.position.y + 1920f);
    }
}