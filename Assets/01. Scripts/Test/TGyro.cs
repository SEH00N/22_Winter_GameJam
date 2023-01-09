using UnityEngine;

public class TGyro : MonoBehaviour
{
    [SerializeField] Vector3 input;
    [SerializeField] Vector2 AVector;

    private void Start()
    {
        Input.gyro.enabled = true;
        // Input.gyro.
    }

    private void Update()
    {
        // input = Input.gyro.rotationRateUnbiased;
        // input = Gyro2Vector3(Input.gyro.attitude);
        input = Input.acceleration;
        float x = input.x >= 0.5f ? 1f : input.x <= -0.5f ? -1 : 0;
        float y = input.y >= 0.3f ? 1f : input.y <= -0.3f ? -1 : 0;
        AVector = new (x, y);

        Vector3 moveVector = new (AVector.x, 0, AVector.y);

        transform.Translate(moveVector.normalized * Time.deltaTime);
    
        // input = new ((int)dir.x, (int)dir.y, (int)dir.z);
        

        // transform.rotation = Gyro2Quarternion(Input.gyro.attitude);
        // transform.Translate(new Vector3(Input.gyro.rotationRateUnbiased.z, 0, -Input.gyro.rotationRateUnbiased.x).normalized * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
    }

    private Quaternion Gyro2Quarternion(Quaternion q) => new Quaternion(q.x, q.y, -q.z, -q.w);
    private Vector3 Gyro2Vector3(Quaternion q) => new Quaternion(q.x, q.y, -q.z, -q.w).eulerAngles;
}
