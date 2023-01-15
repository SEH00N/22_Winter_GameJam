using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }

    public float rotatorSpeed = 0.5f;

    private void Awake()
    {
        if(instance != null) { Debug.LogWarning("Multiple gameManager instance is running, destroy this"); Destroy(gameObject); }

        instance = this;
        DontDestroyOnLoad(gameObject);

        Application.targetFrameRate = 50;
    }
}
