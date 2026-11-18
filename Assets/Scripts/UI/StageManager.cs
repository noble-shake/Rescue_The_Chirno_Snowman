using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MenuManager
{
    public List<Button> StageMenus;
    public Button BackBtn;

    private void Start()
    {
        BackBtn.onClick.AddListener(OnButtonBack);

        for (int idx = 0; idx < StageMenus.Count; idx++)
        {
            int deleIndex = idx;

            if (idx == StageMenus.Count - 1)
            {
                StageMenus[deleIndex].onClick.AddListener(OnButtonEnd);
                continue;
            }
            StageMenus[deleIndex].onClick.AddListener(() => OnButtonClicked(deleIndex));
        }

        StageLockCheck();
    }

    public void StageLockCheck()
    {
        for (int idx = 1; idx < System.Enum.GetValues(typeof(enumStage)).Length; idx++)
        {
            string key = ((enumStage)idx).ToString();
            if (PlayerPrefs.HasKey(key) == false)
            {
                StageMenus[idx].interactable = false;
            }
        }
    }

    public void OnButtonEnd()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void OnButtonClicked(int index)
    {
        Debug.Log($"Stage {index} button");
        int targetidx = index;
        PlayerPrefs.SetInt("Stage", targetidx);
        GameManager.Instance.CurrentStage = GameManager.Instance.StagePrefabs[targetidx];
        SceneManager.LoadSceneAsync(2);
    }

    public void OnButtonBack()
    {
        CanvasOff(GetComponent<CanvasGroup>());
        CanvasOn(TitleManager.Instance.MainButtons);
    }

    private void Update()
    {
        StageLockCheck();
    }
}
