using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    private static GimmickManager instance = null;
    public static GimmickManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<GimmickManager>();

            return instance;
        }
    }

    [SerializeField] List<Gimmick> gimmicks = new List<Gimmick>();
    [SerializeField] Transform gimmickSpawnPosition = null;
    [SerializeField] float gimmickSpawnDelayDistance = 50f;
    public float GimmickSpawnDelayDistance => gimmickSpawnDelayDistance;

    //player에서 GimmickManager.Instance.SpawnRandomGimmick() 해서 일정 딜레이마다 호출해야됨
    public void SpawnRandomGimmick()
    {
        Gimmick randomGimmick = gimmicks[Random.Range(0, gimmicks.Count)];
        randomGimmick = PoolManager.Instance.Pop(randomGimmick.name) as Gimmick;

        randomGimmick.transform.position = gimmickSpawnPosition.position;
    }
}