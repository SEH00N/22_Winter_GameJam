using UnityEngine;

public class ParticlePrefab : PoolableMono
{
    [SerializeField] protected float lifeTime = 10f;
    protected float timer = 0f;

    public override void Reset()
    {
        timer = 0f;
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;

        if(timer >= lifeTime)
        {
            PoolManager.Instance.Push(this);
        }
    }
}
