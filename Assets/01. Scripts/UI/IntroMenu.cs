using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IntroMenu : MonoBehaviour
{
    private Image blockImage = null;

    private void Awake()
    {
        blockImage = DEFINE.StaticCanvas.Find("BlockImage").GetComponent<Image>();
    }

    public void StartGame()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(blockImage.DOFade(1f, 0.3f));
        seq.AppendCallback(() => {
            SceneLoader.Instance.LoadAsync("StageScene");
            seq.Kill();
        });
    }
}
