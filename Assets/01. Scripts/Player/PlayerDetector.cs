using UnityEngine;
using static DEFINE;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 1f;
    private SpriteRenderer spriteRenderer = null;
    private float Alpha {
        get => spriteRenderer.color.a;
        set {
            Color color = spriteRenderer.color;
            color.a = value;
            spriteRenderer.color = color;
        }
    }
    private float rotatorDetectRadius;
    private float timer = 0f;

    private bool isNear = false;

    public void Init(float rotatorDetectRadius)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        this.rotatorDetectRadius = rotatorDetectRadius;

        transform.localScale = Vector3.one * rotatorDetectRadius * 2f;
    }

    private void Update()
    {
        bool near = IsNear();
        if(isNear != near)
        {
            timer = 0f;
            isNear = near;
        }

        timer += Time.deltaTime;
        Alpha = Mathf.Lerp(isNear ? 0f : 1f, isNear ? 1f : 0f, timer * fadeSpeed);
    }

    public bool IsNear() => Physics2D.OverlapCircle(transform.position, rotatorDetectRadius, PlayerLayer);
}
