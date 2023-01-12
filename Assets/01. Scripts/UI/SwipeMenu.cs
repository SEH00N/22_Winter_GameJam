using System.Collections.Concurrent;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    [SerializeField] Scrollbar scrollbar;
    
    private GameObject[] contents;
    private float[] pos;
    
    private float scrollPos = 0f;
    private float distance;

    private float tempDelay = 0.3f;
    private float timer = 0f;

    private void Awake()
    {
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length - 1);

        for(int i = 0 ; i < pos.Length; i++)
            pos[i] = distance * i;
    }

    private void Update()
    {
        if(Input.touches.Length > 0 || Input.GetMouseButtonDown(0))
            timer = 0f;
        if(timer >= tempDelay)
        {
            for(int i = 0; i < pos.Length; i ++)
            {
                if(scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
                {
                    scrollbar.value = Mathf.Lerp(scrollbar.value, pos[i], 0.1f);

                    Transform target = transform.GetChild(i);
                    target.localScale = Vector2.Lerp(target.localScale, Vector2.one, 0.1f);
                }
                else
                {
                    Transform target = transform.GetChild(i);
                    target.localScale = Vector2.Lerp(target.localScale, Vector2.one * 0.8f, 0.1f);
                }
            }
        }
        else
            scrollPos = scrollbar.value;

        timer += Time.deltaTime;
    }
}
