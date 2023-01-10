using UnityEngine;
using System.Linq;
using static DEFINE;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private Rigidbody2D rb2d = null;

    private BallRotator currentRotator = null;
    private BallRotator lastRotator = null;
    public bool Rotator => currentRotator != null;

    private Vector2 InitPos;
    private float rotatorDetectRadius;

    public void Init(float rotatorDetectRadius)
    {
        rb2d = GetComponent<Rigidbody2D>();

        this.rotatorDetectRadius = rotatorDetectRadius;

        InitPos = transform.position;
    }
    private void PosReset(){
        transform.position = InitPos;
        SetRotator();
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

    public void RemoveRotator()
    {
        lastRotator = currentRotator;
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
    private void  OnCollisionEnter2D(Collision2D other)
    {
        DieParticle particle = PoolManager.Instance.Pop("DiePrefap") as DieParticle;
        Vector2 dir = (Vector2)particle.transform.position - other.contacts[0].point;
        float angle =Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg;
        if(other.gameObject.CompareTag("Wall")||other.gameObject.CompareTag("FinishRotator")){
            if(Rotator)
                RemoveRotator();
            particle.Init(transform.position,Quaternion.Euler(0,0,angle));
            PosReset();
        }
        if(other.gameObject.CompareTag("ClearWall")){
            if(lastRotator.gameObject.CompareTag("FinishRotator")){
                StageManager.Instance.EndingUiInit();
                StageManager.Instance.EndingUI.Active();
            }else{
                if(Rotator)
                RemoveRotator();
            particle.Init(transform.position,Quaternion.Euler(0,0,angle));
            PosReset();
            }
        }
    }
}
