using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadMainMenuCallback : MonoBehaviour
{
    private Image blockImage = null;

    private void Awake()
    {
        blockImage = DEFINE.StaticCanvas.Find("BlockImage").GetComponent<Image>();
    }

    public void LoadMainMenu(float interval)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(interval);
        seq.Append(blockImage.DOFade(1f, 0.3f));
        seq.AppendCallback(() => {
            SceneLoader.Instance.LoadAsync("IntroScene", () => {
                blockImage.DOFade(0f, 0.3f);
            });
            seq.Kill();
        });
    }
}
