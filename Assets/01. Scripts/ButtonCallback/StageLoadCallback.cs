using UnityEngine;

public class StageLoadCallback : MonoBehaviour
{
    public void LoadStage(int index) => StageManager.Instance.LoadStage(index);
    public void UnloadStage() => StageManager.Instance.UnloadStage();
}
