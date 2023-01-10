using System.Timers;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
    [SerializeField] float cycleDelay = 1f;
    private TextMeshProUGUI text = null;

    private bool onInc = false;
    private float timer = 0f;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        text.alpha = Mathf.Lerp(onInc ? 0f : 1f, onInc ? 1f : 0f, timer / cycleDelay);

        if(timer >= cycleDelay)
        {
            onInc = !onInc;
            timer = 0f;
        }
    }
}
