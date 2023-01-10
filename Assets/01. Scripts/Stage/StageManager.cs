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
    private EndingUI endingUI = null;
    public EndingUI EndingUI {
        get{
            if(endingUI == null){
                endingUI = FindObjectOfType<EndingUI>();
            }
            return endingUI;
        }
    }

    [SerializeField] int stageCount = 5;
    public int StageCount => stageCount;

    private Stage currentStage = null;

    public void EndingUiInit(){
        EndingUI.Init(currentStage.stageIndex);
    }   
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
