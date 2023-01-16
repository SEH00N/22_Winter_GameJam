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
    public BallRotator LastRotator 
    {
        get => lastRotator;
        set => lastRotator = value;}
    private Vector2 lastRotaterPos;
    public Vector2 LastRotaterPos => lastRotaterPos;

    private Vector2 initPos;
    private float rotatorDetectRadius;
    private InfinityModeManager manager = null;

    private AudioSource flyPlayer;
    private AudioSource rotatorPlayer;

    [SerializeField] float maxHoldTime = 1f;
    private float holdTimer = 0f;
    private bool onHold = false;

    public void Init(float rotatorDetectRadius,InfinityModeManager manager = null)
    {
        rb2d = GetComponent<Rigidbody2D>();

        flyPlayer = transform.Find("FlySoundPlayer").GetComponent<AudioSource>();
        rotatorPlayer = transform.Find("RotatorSoundPlayer").GetComponent<AudioSource>();

        this.manager = manager;
        this.rotatorDetectRadius = rotatorDetectRadius;

        initPos = transform.position;
        lastRotaterPos = transform.position;

        rb2d.velocity = Vector2.zero;        
    }

    public void PosReset()
    {
        SetRotator();
    }

    private void Update()
    {

        MobileInput();
        PCInput();

        if(onHold)
            holdTimer += Time.deltaTime;

        if(holdTimer >= maxHoldTime)
        {
            onHold = false;
            Time.timeScale = 1f;
        }
    }

    private void MobileInput()
    {
        if(Input.touchCount <= 0)
            return;

        if(Rotator)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Time.timeScale = 0.5f;
                onHold = true;
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Time.timeScale = 1f;
                onHold = false;
                RemoveRotator();
            }
        }
        else if(Input.GetTouch(0).phase == TouchPhase.Ended)
            SetRotator();
    }

    private void PCInput()
    {
        if(Rotator)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 0.5f;
                onHold = true;
                Debug.Log("터치");
            }
            else if(Input.GetKeyUp(KeyCode.Space))
            {
                Time.timeScale = 1f;
                onHold = false;
                RemoveRotator();
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space)){
            SetRotator();
                Debug.Log("터치");
    }
    }

    public void RemoveRotator()
    {
        currentRotator.RemoveBall();
        lastRotator = currentRotator;
        currentRotator = null;
        lastRotaterPos = transform.position;


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
        Debug.Log(currentRotator);

        if (currentRotator == null)
            return;
        if(lastRotator != null)
            manager?.AddScore();
        
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

        return lastRotator == targetRotator ? null: targetRotator;
    }
}
