using UnityEngine;

public class InfinityModeBall : MonoBehaviour
{
    private BallController ballController = null;
    // private InfinityModeManager manager = null;

    private void Awake()
    {
        ballController = GetComponent<BallController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Wall"))
            return;

        if (ballController.Rotator)
            ballController.RemoveRotator();

        DieParticle(other.contacts[0].point);
        //manager.End();
    }

    private void DieParticle(Vector2 otherPos)
    {
        DieParticle particle = PoolManager.Instance.Pop("DieEffect") as DieParticle;
        Vector2 dir = (Vector2)particle.transform.position - otherPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        particle.Init(transform.position, Quaternion.Euler(angle, 90, -90));
    }
}

public class A
{
    //private InfinityModeUI infinityModeUI = null;

    private void Awake()
    {
        // infinityModeUI = GameObject.Find("Canvas/InfinityModeUI").GetComponent<InfinityModeBall>();
    }

    public void End()
    {
        // infinityModeUI.Init();
    }
}
