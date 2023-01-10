using UnityEngine;

public class BallRotator : MonoBehaviour
{
    [SerializeField] float radius = 10f;
    [SerializeField] float speed = 5f;
    [SerializeField] float deg = 0f;

    private bool active = false;

    private BallController ball = null;
    private PlayerDetector playerDetector = null;

    public void Init(float rotatorDetectRadius)
    {
        ball = DEFINE.Ball;
        playerDetector = transform.GetChild(0).GetComponent<PlayerDetector>();

        playerDetector.Init(rotatorDetectRadius);
    }

    private void Update()
    {
        if(active)
            Rotating();
    }

    private void Rotating()
    {
        deg += Time.deltaTime * 360f * speed;

        if(deg >= 360f)
            deg = 0f;

        float radAngle = deg * Mathf.Deg2Rad;
        float xFactor = Mathf.Cos(radAngle);
        float yFactor = Mathf.Sin(radAngle);

        Vector2 factor = new Vector2(xFactor, yFactor) * radius;

        ball.transform.position = factor + (Vector2)transform.position;
        ball.transform.rotation = Quaternion.AngleAxis(deg, Vector3.forward);
    }

    public void SetBall()
    {
        active = true;
        
        Vector2 factor = ball.transform.position - transform.position;
        float x = Mathf.Pow(factor.x, 2);
        float y = Mathf.Pow(factor.y, 2);

        radius = Mathf.Sqrt(x + y);

        Vector2 normal = factor.normalized;
        float angle = Mathf.Atan2(normal.y, normal.x);

        deg = angle * Mathf.Rad2Deg;
        ball.transform.rotation = Quaternion.Euler(0, 0, -deg);
    }

    public void RemoveBall()
    {
        active = false;
    }
}
