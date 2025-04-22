using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] public int CurrentLevel;
    [SerializeField] public int PushLeft;
    [SerializeField, Range(1f, 5f)] public float ConditionSize;
    [SerializeField] public bool isHigher;

    private int stageIndex;
    [SerializeField] public List<StageScriptableObject> StagePrefabs;
    [SerializeField] public StageScriptableObject CurrentStage;
    [SerializeField] public GameObject StageObject;

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            
        }

    }

    public void SequneceStart()
    {
        DialogSystem.Instance.PlaySequence(CurrentStage.Dialogs.ToList<DialogStructure>());
    }

    public void GameStart()
    {
        CurrentLevel = CurrentStage.LEVEL;
        PushLeft = CurrentStage.PushCondition;
        ConditionSize = CurrentStage.SizeCondition;
        isHigher = CurrentStage.isHigh;

        CurrentStage = Instantiate(CurrentStage);
        StageObject = Instantiate(CurrentStage.MapPrefab);
        StageObject.transform.position = Vector3.zero;
    }

    public void GameClearAllObject()
    {
        Destroy(StageObject.gameObject);
        if (ChirnoManager.Instance != null) Destroy(ChirnoManager.Instance.gameObject);
        if (ChirnoObject.Instance != null) Destroy(ChirnoObject.Instance.gameObject);
    }

    public void PhaseStart()
    {
        Debug.Log("Phase Start");

        if (PlayerPrefs.HasKey("Stage") == false)
        {
            PlayerPrefs.SetInt("Stage", 0);
        }
        stageIndex = PlayerPrefs.GetInt("Stage");
        Debug.Log(stageIndex);

        if (CurrentStage.Dialogs.Length == 0)
        {
            GameStart();
        }
        else
        {
            SequneceStart();
        }
    }

    public IEnumerator NextPhase(int idx)
    {
        GameManager.Instance.GameClearAllObject();

        yield return null;
        PlayerPrefs.SetInt("Stage", idx+1);
        GameManager.Instance.CurrentStage = GameManager.Instance.StagePrefabs[idx+1];
        GameManager.Instance.GameStart();
    }

}