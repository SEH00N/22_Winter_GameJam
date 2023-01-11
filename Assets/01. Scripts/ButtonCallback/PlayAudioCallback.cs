using UnityEngine;

public class PlayAudioCallback : MonoBehaviour
{
    public void PlayAudio(string name)
    {
        AudioManager.Instance.PlaySystem(name);
    }
}
