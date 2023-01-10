using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IntroMenu : MonoBehaviour
{
    [SerializeField] float rotateRadius = 10f;
    private Image blockImage = null;

    private void Awake()
    {
        blockImage = DEFINE.StaticCanvas.Find("BlockImage").GetComponent<Image>();
        GameObject.Find("BallRotator").GetComponent<BallRotator>().Init(rotateRadius);
        GameObject.Find("Ball").GetComponent<BallController>().Init(rotateRadius);
    }

    public void StartGame(float interval)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(interval);
        seq.Append(blockImage.DOFade(1f, 0.3f));
        seq.AppendCallback(() => {
            SceneLoader.Instance.LoadAsync("StageScene");
            seq.Kill();
        });
    }
}
