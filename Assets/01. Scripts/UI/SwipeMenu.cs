using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    [SerializeField] Scrollbar scrollbar;
    
    private GameObject[] contents;
    private float[] pos;
    
    private float scrollPos = 0f;
    private float distance;

    private void Awake()
    {
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length - 1);

        for(int i = 0 ; i < pos.Length; i++)
            pos[i] = distance * i;
    }

    private void Update()
    {
        if((Input.touchCount > 0) || Input.GetMouseButton(0))
            scrollPos = scrollbar.value;
        else
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
    }
}
