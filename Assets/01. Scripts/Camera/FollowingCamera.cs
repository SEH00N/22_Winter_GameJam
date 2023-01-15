using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float maxSpeed = 20f;
    [SerializeField] float speedAccel = 0.1f;

    private float currentSpeed = 0f;

    private Background background = null;
    private GameObject confiner = null;

    private bool active = false;

    private void Awake()
    {
        background = FindObjectOfType<Background>();
        confiner = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        currentSpeed = speed;
        // confiner.SetActive(false);
    }

    private void Update()
    {
        if(active == false)
            return;

        float moveAmount = Time.deltaTime * currentSpeed;
        transform.position += new Vector3(0, moveAmount, 0);

        currentSpeed += speedAccel * Time.deltaTime;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
    }

    public void Active(bool active)
    {
        this.active = active;
    }

    public void Init()
    {
        currentSpeed = speed;
        transform.position = new Vector3(0, 0, -10f);
    }
}
