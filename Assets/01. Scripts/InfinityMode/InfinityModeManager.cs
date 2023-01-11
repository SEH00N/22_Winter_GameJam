using UnityEngine;
using static DEFINE;

public class InfinityModeManager : MonoBehaviour
{
    [SerializeField] float ySize;
    [SerializeField] string[] stageName;
    private float yPos = 0f;

    private int score = 0;

    private InfinityModeUI infinityModeUI = null;
    private FollowingCamera followingCamera = null;

    private void Awake() 
    {
        infinityModeUI = GameObject.Find("Canvas/InfinityModeEndingUI").GetComponent<InfinityModeUI>();
        followingCamera = DEFINE.MainCam.GetComponent<FollowingCamera>();

        InitGame();
    
        Ball.Init(4f);
    }

    private void InitGame()
    {
        score = 0;
        followingCamera.Active(true);

        for (int i = 0; i < 3; i++)
            SpawnGimmick();
    }

    public void SpawnGimmick()
    {
        Gimmick gimmick = PoolManager.Instance.Pop(stageName[Random.Range(0, stageName.Length)]) as Gimmick;

        gimmick.Init(this, 4f);
        gimmick.transform.position = new Vector3(0f, yPos, 0f);

        yPos += ySize;
    }

    public void AddScore() => score ++;

    public void End()
    {
        followingCamera.Active(false);
        followingCamera.Reset();
        
        infinityModeUI.Init(score);
        infinityModeUI.Active();
    }
}