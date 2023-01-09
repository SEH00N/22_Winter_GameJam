using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float speedIncAmountPerSec = 1f;
    [SerializeField] float gyroReinForce = 0.3f;
    [SerializeField] float rotateSpeed = 2f;
    private Movement movement = null;

    private float movedDistance = 0f;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        DoMove();
    
        moveSpeed += Time.deltaTime * speedIncAmountPerSec;

        movedDistance += movement.CurrentVelocity * Time.deltaTime;
        if(movedDistance >= GimmickManager.Instance.GimmickSpawnDelayDistance)
        {
            movedDistance = 0f;
            GimmickManager.Instance.SpawnRandomGimmick();
        }
    }

    private void DoMove()
    {
        float x = Input.acceleration.x >= gyroReinForce ? 1f : Input.acceleration.x <= -gyroReinForce ? -1 : 0;

        float targetAngle = -25f * x;
        Quaternion targetRotation = Quaternion.AngleAxis(targetAngle, transform.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);

        movement.MoveTo(new (x, 0, moveSpeed));
    }
}
