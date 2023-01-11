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
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("RemoverDetector"))
        {
            if (ballController.Rotator)
                ballController.RemoveRotator();

            DieParticle(other.contacts[0].point);
            manager.End();

            Destroy(gameObject);
        }
    }

    private void DieParticle(Vector2 otherPos)
    {
        DieParticle particle = PoolManager.Instance.Pop("DieEffect") as DieParticle;
        Vector2 dir = (Vector2)particle.transform.position - otherPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        particle.Init(transform.position, Quaternion.Euler(angle, 90, -90));
    }
}
