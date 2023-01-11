using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float cycleDelayDistance = 10f;
    [SerializeField] private float movedDistance = 0f;

    private Background background = null;
    private GameObject confiner = null;

    private bool active = false;

    private void Awake()
    {
        background = FindObjectOfType<Background>();
        confiner = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if(active == false)
            return;

        float moveAmount = Time.deltaTime * speed;
        transform.position += new Vector3(0, moveAmount, 0);

        movedDistance += moveAmount;

        if(movedDistance >= cycleDelayDistance)
        {
            movedDistance = 0f;
            background.SetRandomColor();
        }
    }

    public void Active(bool active)
    {
        this.active = active;
        confiner.SetActive(active);
    }

    public void Init()
    {
        background.Init();
        transform.position = new Vector3(0, 0, -10f);
    }
}
