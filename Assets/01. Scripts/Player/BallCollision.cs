using System.ComponentModel;
using System;
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
        Debug.DrawLine(otherPos, otherPos + Vector2.left * 2f, Color.red, 5f);
        Debug.DrawLine(otherPos, otherPos + Vector2.up * 2f, Color.red, 5f);
        Debug.DrawLine(otherPos, otherPos + Vector2.right * 2f, Color.red, 5f);
        Debug.DrawLine(otherPos, otherPos + Vector2.down * 2f, Color.red, 5f);

        DieParticle particle = PoolManager.Instance.Pop("DieEffect") as DieParticle;
        Vector3 dir = (otherPos - (Vector2)transform.position).normalized;
        
        float rad = MathF.Atan2(dir.y, dir.x);
        float deg = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        particle.Init(otherPos, Quaternion.Euler(0f, 0f, deg + 90f));
    }
}
