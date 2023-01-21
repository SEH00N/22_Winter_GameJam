using UnityEngine;

public class GimmickRemover : MonoBehaviour
{
    private Gimmick gimmick = null;
    private InfinityModeManager manager = null;

    private void Awake()
    {
        gimmick = transform.parent.GetComponent<Gimmick>();
    }
    private void Start() {
        manager = gimmick.manager;
        Debug.Log(manager);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("RemoverDetector"))
        {
            manager.gimmicks.Add(gimmick);
            PoolManager.Instance.Push(gimmick);
        }
    }
}
