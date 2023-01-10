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

    [SerializeField] int stageCount = 5;
    public int StageCount => stageCount;

    private Stage currentStage = null;

    public void LoadStage(int index)
    {
        Stage stage = Resources.Load<Stage>($"Stages/Stage{index}");
        currentStage = Instantiate(stage, Vector3.zero, Quaternion.identity);
        currentStage.Init(index);
    }

    public void UnloadStage()
    {
        if(currentStage == null)
            return;

        Destroy(currentStage.gameObject);

        currentStage = null;
    }
}
