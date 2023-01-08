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

    [SerializeField] bool cursorActive = false;
    public bool CursorActive {
        get => cursorActive;
        set {
            cursorActive = value;
            Cursor.visible = cursorActive;
            Cursor.lockState = cursorActive ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    private void Awake()
    {
        if(instance != null) { Debug.LogWarning("Multiple gameManager instance is running, destroy this"); Destroy(gameObject); }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        CursorActive = cursorActive;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftAlt))
            if(Input.GetKey(KeyCode.LeftShift))
                if(Input.GetKeyDown(KeyCode.Comma))
                    CursorActive = !CursorActive;
    }
}
