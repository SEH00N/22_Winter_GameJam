using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] MovementSO movementSO;
    [SerializeField] float rayDistance = 2f;

    private Rigidbody rb = null;

    private float currentVelocity = 0f;

    private Vector3 currentDir = Vector3.zero;
    private Vector2 CurrentPlaneVector => new Vector2(currentDir.x, currentDir.z);

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 dir = ((currentDir.x * transform.right) + (currentDir.z * transform.forward)) * currentVelocity;
        dir.y = rb.velocity.y;

        rb.velocity = dir;

        AutoJump();
    }

    private void AutoJump()
    {
        if(Physics.Raycast(transform.position, Vector3.down, rayDistance, DEFINE.GroundLayer))
        {
            Vector3 velo = rb.velocity;
            velo.y = 0;
            rb.velocity = velo;
            rb.AddForce(Vector3.up * movementSO.jumpSpeed, ForceMode.Impulse);
        }
    }

    public void MoveTo(Vector3 input)
    {
        input = input.normalized;
        Vector2 inputPlaneVector = new Vector2(input.x, input.z);

        if(inputPlaneVector.sqrMagnitude > 0f)
        {
            if(Vector2.Dot(inputPlaneVector, CurrentPlaneVector) < 0f)
                currentVelocity = 0f;

            currentDir = input;
        }

        currentVelocity = CalculateSpeed(input);
    }

    private float CalculateSpeed(Vector3 input)
    {
        float factor = input.sqrMagnitude > 0f ? movementSO.inAccel : -movementSO.deAccel;
        currentVelocity += factor * Time.deltaTime;

        return Mathf.Clamp(currentVelocity, 0, movementSO.maxSpeed);
    }

    public void DoStop()
    {
        currentVelocity = 0f;
        currentDir = Vector3.zero;
    }
}
