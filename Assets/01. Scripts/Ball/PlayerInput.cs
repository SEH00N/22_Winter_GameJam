using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float gyroReinForce = 0.3f;
    [SerializeField] float rotateSpeed = 2f;
    private Movement movement = null;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        DoMove();
    }

    private void DoMove()
    {
        float x = Input.acceleration.x >= gyroReinForce ? 1f : Input.acceleration.x <= -gyroReinForce ? -1 : 0;

        float targetAngle = -25f * x;
        Quaternion targetRotation = Quaternion.AngleAxis(targetAngle, transform.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);

        movement.MoveTo(new (x, 0, 10f));
    }
}
