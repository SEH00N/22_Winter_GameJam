using UnityEngine;

public class IntroLight : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    private float deg = 0f;

    private void Update()
    {
        deg += Time.deltaTime * speed;

        transform.rotation = Quaternion.AngleAxis(deg, Vector3.forward);
    }
}
