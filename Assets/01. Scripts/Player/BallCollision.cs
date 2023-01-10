using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag("Walll"))
            return;

        
    }
}
