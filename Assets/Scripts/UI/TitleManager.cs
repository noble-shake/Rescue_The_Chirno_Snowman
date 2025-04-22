using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MenuManager
{
    public static TitleManager Instance;

    public CanvasGroup MainButtons;
    public Button StartButton;
    public Button OptionButton;
    public Button ExitButton;

    public CanvasGroup StartCanvas;
    public CanvasGroup OptionCanvas;

    public Texture2D Idle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Cursor.SetCursor(Idle, new Vector2(Idle.width / 2, Idle.height / 2), CursorMode.ForceSoftware);

        StartButton.onClick.AddListener(OnClickedStart);
        OptionButton.onClick.AddListener(OnClickedOption);
        ExitButton.onClick.AddListener(OnClikckedExit);
    }

    public void OnClickedStart()
    {
        CanvasOff(MainButtons);
        CanvasOn(StartCanvas);

    }

    public void OnClickedOption()
    {
        CanvasOff(MainButtons);
        if (OptionCanvas != null)
        {
            CanvasOn(OptionCanvas);
        }
        else
        {
            OptionCanvas = OptionManager.Instance.canvs;
            CanvasOn(OptionCanvas);
        }
    }

    public void OnClikckedExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
