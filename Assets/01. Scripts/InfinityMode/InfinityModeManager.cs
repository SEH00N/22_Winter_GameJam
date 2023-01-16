using TMPro;
using UnityEngine;
using static DEFINE;

public class InfinityModeManager : MonoBehaviour
{
    [SerializeField] float gap;
    private float yPos = 0f;

    private int score = 0;
    private TextMeshProUGUI scoreText = null;

    private InfinityModeUI infinityModeUI = null;
    private GameObject reviveAdUI = null;
    private FollowingCamera followingCamera = null;

    private float rotatorSpeed;

    private ReviveAd reviveAd = null;
    private bool revived = false;

    private void Awake() 
    {
        infinityModeUI = GameObject.Find("Canvas/InfinityModeEndingUI").GetComponent<InfinityModeUI>();
        followingCamera = DEFINE.MainCam.GetComponent<FollowingCamera>();

        scoreText = GameObject.Find("Canvas").transform.Find("InfinityModeScoreText/Text").GetComponent<TextMeshProUGUI>();
        reviveAdUI = GameObject.Find("Canvas/ReviveAdUI");
    }

    private void Start()
    {
        reviveAdUI.SetActive(false);
        InitGame();
        Ball.Init(4f,this);
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