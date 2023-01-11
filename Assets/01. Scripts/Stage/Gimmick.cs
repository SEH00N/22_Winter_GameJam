using System.Collections.Generic;
using UnityEngine;

public class Gimmick : PoolableMono
{
    private InfinityModeManager manager = null;

    private List<BallRotator> rotators = new List<BallRotator>();

    private Collider2D col2d = null;

    public override void Reset()
    {
        col2d = GetComponent<Collider2D>();
        col2d.enabled = true;
    }

    public void Init(InfinityModeManager manager, float rotatorDetectRadius)
    {
        this.manager = manager;
        transform.SetParent(manager.transform);

        transform.GetComponentsInChildren<BallRotator>(rotators);

        rotators.ForEach(rotator => rotator.Init(rotatorDetectRadius));
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            manager.SpawnGimmick();
            col2d.enabled = false;
        }
    }
}
