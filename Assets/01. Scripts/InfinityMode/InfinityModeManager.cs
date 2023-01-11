using TMPro;
using UnityEngine;
using static DEFINE;

public class InfinityModeManager : MonoBehaviour
{
    [SerializeField] float gap;
    [SerializeField] Gimmick[] stageName;
    private float yPos = 0f;

    private int score = 0;
    private TextMeshProUGUI scoreText = null;

    private InfinityModeUI infinityModeUI = null;
    private FollowingCamera followingCamera = null;

    private BallController ballController = null;

    private void Awake() 
    {
        infinityModeUI = GameObject.Find("Canvas/InfinityModeEndingUI").GetComponent<InfinityModeUI>();
        followingCamera = DEFINE.MainCam.GetComponent<FollowingCamera>();

        scoreText = transform.Find("InfinityModeCanvas/ScoreText").GetComponent<TextMeshProUGUI>();

        InitGame();
        Ball.Init(4f);
    }

    private void InitGame()
    {
        scoreText.gameObject.SetActive(true);

        score = 0;
        scoreText.text = $"{score}";

        followingCamera.Active(true);

        for (int i = 0; i < 3; i++)
            SpawnGimmick();
    }

    public void SpawnGimmick()
    {
        Gimmick gimmick = PoolManager.Instance.Pop(stageName[Random.Range(0, stageName.Length)]) as Gimmick;

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
        scoreText.gameObject.SetActive(false);

        followingCamera.Active(false);
        
        infinityModeUI.Init(score);
        infinityModeUI.Active();
    }
}