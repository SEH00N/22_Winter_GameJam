using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static StageManager instance = null;
    public static StageManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<StageManager>();

            return instance;
        }
    }

    private Stage currentStage = null;

    public void LoadStage(int index)
    {
        Stage stage = Resources.Load<Stage>($"Stages/{index}");
        currentStage = Instantiate(stage, Vector3.zero, Quaternion.identity);
        currentStage.Init();
    }

    public void UnloadStage()
    {
        Destroy(currentStage);

        currentStage = null;
    }
}
