using UnityEngine;
using System.Linq;
using static DEFINE;

public class BallController : MonoBehaviour
{
    [SerializeField] bool active = true;
    [SerializeField] float speed = 5f;

    private Rigidbody2D rb2d = null;

    private BallRotator currentRotator = null;
    public bool Rotator => currentRotator != null;

    private BallRotator lastRotator = null;
    public BallRotator LastRotator => lastRotator;

    private Vector2 initPos;
    private float rotatorDetectRadius;

    private AudioSource flyPlayer;
    private AudioSource rotatorPlayer;

    public void Init(float rotatorDetectRadius)
    {
        rb2d = GetComponent<Rigidbody2D>();

        flyPlayer = transform.Find("FlySoundPlayer").GetComponent<AudioSource>();
        rotatorPlayer = transform.Find("RotatorSoundPlayer").GetComponent<AudioSource>();

        this.rotatorDetectRadius = rotatorDetectRadius;

        initPos = transform.position;

        rb2d.velocity = Vector2.zero;        
    }

    public void PosReset()
    {
        transform.position = initPos;
        SetRotator();
    }

    private void Update()
    {
        if (active == false) return;

        if(Input.touches.Length > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if(Rotator)
                    RemoveRotator();
                else
                    SetRotator();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Rotator)
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
        AudioManager.Instance.PlayAudio("Fly", flyPlayer);
    }

    public void SetRotator()
    {
        currentRotator = DetectRotator();

        if (currentRotator == null)
            return;

        rb2d.velocity = Vector2.zero;
        currentRotator.SetBall();
        AudioManager.Instance.PlayAudio("Catch", rotatorPlayer);
    }

    private BallRotator DetectRotator()
    {
        Collider2D[] detectedRotators = Physics2D.OverlapCircleAll(transform.position, rotatorDetectRadius, RotatorLayer);
        
        if (detectedRotators.Length <= 0)
            return null;

        detectedRotators = (
            from r in detectedRotators
            orderby Vector2.Distance(transform.position, r.transform.position)
            select r
        ).ToArray();

        BallRotator targetRotator = detectedRotators[0].GetComponent<BallRotator>();

        return targetRotator;
    }
}
