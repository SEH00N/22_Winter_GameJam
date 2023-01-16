using UnityEngine;

public class InfinityModeBall : MonoBehaviour
{
    private BallController ballController = null;
    private InfinityModeManager manager = null;

    private void Awake()
    {
        ballController = GetComponent<BallController>();
        manager = transform.parent.GetComponent<InfinityModeManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("RemoverDetector") || other.gameObject.CompareTag("FinishRotator"))
        {
            if (ballController.Rotator)
                ballController.RemoveRotator();

            DieParticle(other.contacts[0].point);
            manager.End();

            gameObject.SetActive(false);
        }
    }

    private void DieParticle(Vector2 otherPos)
    {
        DieParticle particle = PoolManager.Instance.Pop("DieEffect") as DieParticle;
        Vector3 dir = (otherPos - (Vector2)transform.position).normalized;
        
        float rad = Mathf.Atan2(dir.y, dir.x);
        float deg = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        particle.Init(otherPos, Quaternion.Euler(0f, 0f, deg + 90f));
    }
}
