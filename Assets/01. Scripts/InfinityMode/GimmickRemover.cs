using UnityEngine;

public class GimmickRemover : MonoBehaviour
{
    private Gimmick gimmick = null;

    private void Awake()
    {
        gimmick = transform.parent.GetComponent<Gimmick>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("RemoverDetector"))
        {
            PoolManager.Instance.Push(gimmick);
        }
    }
}
