using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IntroMenu : MonoBehaviour
{
    [SerializeField] float rotateRadius = 10f;
    [SerializeField] Animator ballAnim = null;
    private Image blockImage = null;
    private StageLoadCallback stageLoader;

    private void Awake()
    {
        blockImage = DEFINE.StaticCanvas.Find("BlockImage").GetComponent<Image>();
        GameObject.Find("BallRotator").GetComponent<BallRotator>().Init(rotateRadius);
        stageLoader = GetComponent<StageLoadCallback>();
        // GameObject.Find("Ball").GetComponent<BallController>().Init(rotateRadius);

        // blockImage.color = Color.black;
    }
    
    public void StartGame(float interval)
    {
        ballAnim.SetTrigger("Start");
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(interval);
        seq.Append(blockImage.DOFade(1f, 0.3f));
        seq.AppendCallback(() => {
            SceneLoader.Instance.LoadAsync("InGame", () => {
                stageLoader.LoadStage();
            });
            seq.Kill();
        });
    }
}
