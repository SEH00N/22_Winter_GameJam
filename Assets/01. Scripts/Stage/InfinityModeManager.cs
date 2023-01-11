using UnityEngine;
using static DEFINE;

public class InfinityModeManager : MonoBehaviour
{
    private float yPos = 0f;
    [SerializeField] float ySize;
    [SerializeField] string[] stageName;

    private void Awake() 
    {
        InitGame();
    
        Ball.Init(4f);
    }

    private void InitGame()
    {
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
}