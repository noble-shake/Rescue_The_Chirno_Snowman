using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class PauseManager : MenuManager
{
    public static PauseManager Instance;

    [SerializeField] Button Next;
    [SerializeField] TMP_Text NextText;
    [SerializeField] Button Main;

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
        Next.onClick.AddListener(OnClickedNext);
        Main.onClick.AddListener(OnClickedMain);
    }

    public void OnClickedNext()
    {

        int targetidx = GameManager.Instance.CurrentLevel;

        if (targetidx == System.Enum.GetValues(typeof(enumStage)).Length -2)
        {
            Debug.Log("END");
            SceneManager.LoadSceneAsync(3);
            return;
        }

        CanvasOff(this.GetComponent<CanvasGroup>());
        StartCoroutine(GameManager.Instance.NextPhase(targetidx));
        // GameManager.Instance.PhaseStart();

    }

    public void OnClickedMain()
    {
        SceneManager.LoadSceneAsync(0);
    }

}

