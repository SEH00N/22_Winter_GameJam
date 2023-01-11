using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float cycleDelayDistance = 10f;
    [SerializeField] private float movedDistance = 0f;

    private Background background = null;

    private void Awake()
    {
        background = FindObjectOfType<Background>();
    }

    private void Update()
    {
        float moveAmount = Time.deltaTime * speed;
        transform.position += new Vector3(0, moveAmount, 0);

        movedDistance += moveAmount;

        if(movedDistance >= cycleDelayDistance)
        {
            movedDistance = 0f;
            background.SetRandomColor();
        }
    }
}
