using UnityEngine;
using System.Linq;
using static DEFINE;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private Rigidbody2D rb2d = null;

    private BallRotator currentRotator = null;
    public bool Rotator => currentRotator != null;

    private float rotatorDetectRadius = 10f;
    private Vector2 InitPos;

    public void Init(float rotatorDetectRadius)
    {
        rb2d = GetComponent<Rigidbody2D>();

        this.rotatorDetectRadius = rotatorDetectRadius;

        InitPos = transform.position;
    }
    private void PosReset(){
        transform.position = InitPos;
    }   

    private void Start()
    {
        SetRotator();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Rotator)
                RemoveRotator();
            else
                SetRotator();
        }
    }

    private void RemoveRotator()
    {
        currentRotator.RemoveBall();
        currentRotator = null;

        Push();
    }

    private void Push()
    {
        rb2d.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    public void SetRotator()
    {
        currentRotator = DetectRotator();

        if(currentRotator == null)
            return;

        rb2d.velocity = Vector2.zero;
        currentRotator.SetBall();
    }

    private BallRotator DetectRotator()
    {
        Collider2D[] detectedRotators = Physics2D.OverlapCircleAll(transform.position, rotatorDetectRadius, RotatorLayer);
        if(detectedRotators.Length <= 0)
            return null;

        detectedRotators = (
            from r in detectedRotators
            orderby Vector2.Distance(transform.position, r.transform.position)
            select r
        ).ToArray();

        BallRotator targetRotator = detectedRotators[0].GetComponent<BallRotator>();

        return targetRotator;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wall")){
            //파티클
            PosReset();
        }    
    }
}
