using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfinityModeManager : MonoBehaviour
{
    [SerializeField] float gap;
    private float yPos = 0f;

    private int score = 0;
    private TextMeshProUGUI scoreText = null;

    private InfinityModeUI infinityModeUI = null;
    private FollowingCamera followingCamera = null;
    private GameObject reviveAdUI = null;

    private BallController ballController = null;

    private ReviveAd reviveAd = null;
    private Button reviveCancelButton = null;
    private bool revived = false;

    public List<Gimmick> gimmicks = new List<Gimmick>();

    private void Awake() 
    {
        infinityModeUI = GameObject.Find("Canvas/InfinityModeEndingUI").GetComponent<InfinityModeUI>();
        followingCamera = DEFINE.MainCam.GetComponent<FollowingCamera>();

        scoreText = GameObject.Find("Canvas").transform.Find("InfinityModeScoreText/Text").GetComponent<TextMeshProUGUI>();
        reviveAdUI = GameObject.Find("Canvas").transform.Find("ReviveAdUI").gameObject;
        reviveCancelButton = reviveAdUI.transform.Find("Panel/CancelButton").GetComponent<Button>();

        ballController = transform.Find("Ball").GetComponent<BallController>();
    }

    private void Start()
    {
        reviveCancelButton.onClick.AddListener(End);
        reviveAdUI.SetActive(false);
     
        InitGame();
        ballController.Init(4f, this);
    }

    private void InitGame()
    {
        GameManager.Instance.ResetSpeed();
        scoreText.gameObject.SetActive(true);

        score = 0;
        scoreText.text = $"{score}";

        followingCamera.Active(true);

        for (int i = 0; i < 3; i++)
            SpawnGimmick();
    }

    public void SpawnGimmick()
    {
        Gimmick gimmick = PoolManager.Instance.Pop($"Gimmick{Random.Range(1, 20)}") as Gimmick;

        gimmick.Init(this, 4f);
        gimmick.transform.position = new Vector3(0f, yPos, 0f);

        yPos += gimmick.height+gap;
    }

    public void AddScore() 
    {
        score ++;
        scoreText.text = $"{score}";
    }

    public void End()
    {
        Time.timeScale = 1f;
        followingCamera.Active(false);

        if(revived == false)
        {
            reviveAdUI.SetActive(true);
            revived = true;
        }
        else
        {
            scoreText.gameObject.SetActive(false);

            infinityModeUI.Init(score);
            infinityModeUI.Active();
        }
    }
}