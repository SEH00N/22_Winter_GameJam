using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadStageMenuCallback : MonoBehaviour
{
    private Image blockImage = null;

    private void Awake()
    {
        blockImage = DEFINE.StaticCanvas.Find("BlockImage").GetComponent<Image>();
    }

    public void LoadStageMenu(float interval)
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
