using UnityEngine;

public class TMove : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.MaximizedWindow);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * 1f * Time.deltaTime);
    }
}
