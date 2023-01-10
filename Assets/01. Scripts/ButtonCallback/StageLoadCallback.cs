using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StageLoadCallback : MonoBehaviour
{
    [SerializeField] int stageIndex = 0;

    private Image blockImage = null;

    private void Awake()
    {
        blockImage = DEFINE.StaticCanvas.Find("BlockImage").GetComponent<Image>();
    }

    public void SetStage(int index)
    {
        stageIndex = index;
    }

    public void LoadStage() 
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(0.3f);
        seq.Append(blockImage.DOFade(1f, 0.5f).OnComplete(() => {
            UnloadStage();
            StageManager.Instance.LoadStage(stageIndex);
        }));
        seq.Append(blockImage.DOFade(0f, 0.5f));
        seq.AppendCallback(() => seq.Kill());
    }

    public void UnloadStage() => StageManager.Instance.UnloadStage();
}
