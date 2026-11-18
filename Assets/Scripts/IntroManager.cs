using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public static IntroManager Instance;

    public CanvasGroup FadeScreen;
    public Button Skip;
    public TMP_Text SkipText;

    public List<CanvasGroup> CutScenes;
    public int Count;
    public bool isNextReady;

    bool isFadeDone;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Count = 0;
        Skip.onClick.AddListener(OnClickedNextButton);
        StartCoroutine(FadeEffect());
    }
    public void OnClickedNextButton()
    {
        if (isNextReady == false) return;

        if (Count > CutScenes.Count - 1)
        {

            if (PlayerPrefs.HasKey("STAGE01") == false)
            {
                PlayerPrefs.SetInt("STAGE01", 1);

                SceneManager.LoadSceneAsync(2);
            }
            else
            {
                SceneManager.LoadSceneAsync(0);
            }

        }
        else if (Count == CutScenes.Count - 1)
        {
            // Next Scene
            SkipText.text = "START";
            StartCoroutine(OpenEffect(Count));
        }
        else
        {
            StartCoroutine(OpenEffect(Count));
        }

    }

    public IEnumerator OpenEffect(int idx)
    {
        isNextReady = false;
        yield return null;

        float alpha = 0;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * 2f;

            if (alpha > 1f)
            {
                alpha = 1f;
            }
            CutScenes[idx].alpha = alpha;
            yield return null;
        }

        Count++;
        isNextReady = true;
    }


    public IEnumerator FadeEffect()
    { 
        yield return null;

        float alpha = 0;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime;

            if (alpha > 1f)
            { 
                alpha = 1f;
            }
            FadeScreen.alpha = alpha;
            yield return null;
        }

        isFadeDone = true;
        isNextReady = true;
        Skip.GetComponent<CanvasGroup>().alpha = 1f;
        Skip.GetComponent<CanvasGroup>().interactable = true;
        Skip.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
