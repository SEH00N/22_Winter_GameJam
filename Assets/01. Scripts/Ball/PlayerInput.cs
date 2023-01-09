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
        // float z = Input.acceleration.y >= gyroReinForce ? 1f : Input.acceleration.y <= -gyroReinForce ? -1 : 0;
        
        // float x = Mathf.Abs(Input.acceleration.x) >= gyroReinForce ? Input.acceleration.x : 0;
        // float z = Mathf.Abs(Input.acceleration.y) >= gyroReinForce ? Input.acceleration.y : 0;

        float zAngle = transform.eulerAngles.z;
        zAngle += Mathf.Lerp(-25, 25, (x + 1) / 2f) * Time.deltaTime * rotateSpeed;
        zAngle = Mathf.Clamp(-zAngle, -25f, 25f);

        transform.rotation = Quaternion.Euler(0, 0, zAngle);

        movement.MoveTo(new (x, 0, 10f));
    }

    // 0 ~ 25
}
