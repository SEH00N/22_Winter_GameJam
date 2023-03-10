using UnityEngine;

public class DieParticle : ParticlePrefab
{
    private AudioSource soundPlayer = null;

    public override void Reset()
    {
        base.Reset();

        if(soundPlayer == null)
            soundPlayer = GetComponent<AudioSource>();
    }

    public void Init(Vector2 position, Quaternion rotation)
    {
        Vector2 min = new Vector2(CameraManager.Instance.Left, CameraManager.Instance.Bottom);
        Vector2 max = new Vector2(CameraManager.Instance.Right, CameraManager.Instance.Top);

        float x = Mathf.Clamp(position.x, min.x, max.x);
        float y = Mathf.Clamp(position.y, min.y, max.y);

        transform.position = new Vector2(x, y);
        transform.rotation = rotation;
        
        AudioManager.Instance.PlayAudio("Die", soundPlayer);
    }
}
