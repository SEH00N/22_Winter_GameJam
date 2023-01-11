using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private BallController ballController = null;

    private void Awake()
    {
        ballController = GetComponent<BallController>();
    }

    private void  OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("FinishRotator"))
        {
            if (ballController.Rotator)
                ballController.RemoveRotator();
            
            DieParticle(other.contacts[0].point);

            ballController.PosReset();
        }
        if (other.gameObject.CompareTag("ClearWall"))
        {
            if (ballController.LastRotator.CompareTag("FinishRotator"))
            {
                StageManager.Instance.EndingUiInit();
                StageManager.Instance.EndingUI.Active();
            }
            else
            {
                if (ballController.Rotator)
                    ballController.RemoveRotator();
                
                DieParticle(other.contacts[0].point);

                ballController.PosReset();
            }
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
