using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class StageDialog
{
    public string DisplayText;
    public bool DialogCallback;
}


public class DialogSystem : MenuManager
{
    public static DialogSystem Instance;
    CanvasGroup canvas;
    public CanvasGroup Background;
    public CanvasGroup DialogBar;

    public TMP_Text NameBar;
    public TMP_Text ScriptBar;

    public Image Standing1;
    public Image Standing2;
    public Image Standing3;
    public Image Standing4;
    public Image Standing5;

    private StageDialog CurrentDialog;
    // public Button NextButton;

    private IEnumerator DialogSequencer; 
    private IEnumerator SkipSequencer;

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
        canvas = GetComponent<CanvasGroup>();
        CanvasOff(canvas);
    }

    public void SequenceClose()
    {
        // NextButton.interactable = false;
        Background.alpha = 0f;
        DialogBar.alpha = 0f;
        NameBar.text = "";
        ScriptBar.text = "";
        Standing1.sprite = null;
        Standing2.sprite = null;
        Standing3.sprite = null;
        Standing4.sprite = null;
        Standing5.sprite = null;
        Standing1.color = new Color(1f, 1f, 1f, 0f);
        Standing2.color = new Color(1f, 1f, 1f, 0f);
        Standing3.color = new Color(1f, 1f, 1f, 0f);
        Standing4.color = new Color(1f, 1f, 1f, 0f);
        Standing5.color = new Color(1f, 1f, 1f, 0f);
        Standing1.transform.localScale = Vector3.one;
        Standing2.transform.localScale = Vector3.one;
        Standing3.transform.localScale = Vector3.one;
        Standing4.transform.localScale = Vector3.one;
        Standing5.transform.localScale = Vector3.one;
        CanvasOff(canvas);
    }

    public void OnClickedNext()
    { 
        
    }

    public void PlaySequence(List<DialogStructure> Scripts)
    {
        StartCoroutine(SequencePlay(Scripts, Scripts[0].BackGround));
    }

    public IEnumerator SequencePlay(List<DialogStructure> Scripts, Sprite _Background)
    {
        // Fade
        Background.GetComponent<Image>().sprite = _Background;
        yield return null;

        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime;
            if (alpha > 1f)
            {
                alpha = 1f;
            }
            canvas.alpha = alpha;
            yield return null;
        }

        CanvasOn(canvas);

        yield return null;

        // Background
        alpha = 0f;
        while (alpha < 1f)
        {
            alpha += (Time.deltaTime) * 3f;
            if (alpha > 1f)
            {
                alpha = 1f;
            }
            Background.alpha = alpha;
            yield return null;
        }

        // Dialog Bar On.
        DialogBar.alpha = 1f;

        foreach (DialogStructure curD in Scripts)
        {

            if (curD.Name != null)
            {
                NameBar.text = curD.Name;
            }
            else
            {
                NameBar.text = "";
            }

            if (curD.isAppear1)
            {
                Standing1.color = Color.white;
                Standing1.sprite = curD.Standing1;
                if (curD.flip1)
                {
                    Standing1.transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else
                {
                    Standing1.transform.localScale = new Vector3(1f, 1f, 1f);
                }

                if (curD.WhoIsTalker != 0)
                {
                    Standing1.color = new Color(220f / 255f, 220f / 255f, 220f / 255f, 1f);
                }
            }
            else
            {
                Standing1.color = new Color(1f, 1f, 1f, 0f);
            }

            if (curD.isAppear2)
            {
                Standing2.color = Color.white;
                Standing2.sprite = curD.Standing2;
                if (curD.flip2)
                {
                    Standing2.transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else
                {
                    Standing2.transform.localScale = new Vector3(1f, 1f, 1f);
                }

                if (curD.WhoIsTalker != 1)
                {
                    Standing2.color = new Color(220f / 255f, 220f / 255f, 220f / 255f, 1f);
                }
            }
            else
            {
                Standing2.color = new Color(1f, 1f, 1f, 0f);
            }

            if (curD.isAppear3)
            {
                Standing3.color = Color.white;
                Standing3.sprite = curD.Standing3;
                if (curD.flip3)
                {
                    Standing3.transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else
                {
                    Standing3.transform.localScale = new Vector3(1f, 1f, 1f);
                }

                if (curD.WhoIsTalker != 2)
                {
                    Standing3.color = new Color(220f / 255f, 220f / 255f, 220f / 255f, 1f);
                }
            }
            else
            {
                Standing3.color = new Color(1f, 1f, 1f, 0f);
            }

            if (curD.isAppear4)
            {
                Standing4.color = Color.white;
                Standing4.sprite = curD.Standing1;
                if (curD.flip4)
                {
                    Standing4.transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else
                {
                    Standing4.transform.localScale = new Vector3(1f, 1f, 1f);
                }

                if (curD.WhoIsTalker != 3)
                {
                    Standing4.color = new Color(220f / 255f, 220f / 255f, 220f / 255f, 1f);
                }
            }
            else
            {
                Standing4.color = new Color(1f, 1f, 1f, 0f);
            }

            if (curD.isAppear5)
            {
                Standing5.color = Color.white;
                Standing5.sprite = curD.Standing5;
                if (curD.flip5)
                {
                    Standing5.transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else
                {
                    Standing5.transform.localScale = new Vector3(1f, 1f, 1f);
                }

                if (curD.WhoIsTalker != 4)
                {
                    Standing5.color = new Color(220f / 255f, 220f / 255f, 220f / 255f, 1f);
                }
            }
            else
            {
                Standing5.color = new Color(1f, 1f, 1f, 0f);
            }

            string sequence = curD.Description;
            CurrentDialog = new StageDialog() { DisplayText = sequence, DialogCallback = false };

            DialogSequencer = Sequencing();
            StartCoroutine(DialogSequencer);

            yield return new WaitUntil(() =>
            {
                if (CurrentDialog.DialogCallback)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });

            yield return new WaitForSeconds(0.5f);

            yield return new WaitUntil(() => Input.anyKeyDown);

            yield return null;
        }

        yield return null;
        SequenceClose();
        GameManager.Instance.GameStart();
    }

    IEnumerator Sequencing()
    {
        SkipSequencer = SkipSequencing(DialogSequencer);
        StartCoroutine(SkipSequencer);

        ScriptBar.text = "";

        foreach (char letter in CurrentDialog.DisplayText.ToCharArray())
        {
            ScriptBar.text += letter;

            yield return new WaitForSeconds(0.05f);
        }

        StopCoroutine(SkipSequencer);
        CurrentDialog.DialogCallback = true;
    }

    IEnumerator SkipSequencing(IEnumerator _seq)
    {
        yield return new WaitForSeconds(0.4f);
        // yield return new WaitUntil(() => _interact);
        yield return new WaitUntil(() => Input.anyKeyDown);
        StopCoroutine(_seq);
        ScriptBar.text = CurrentDialog.DisplayText;
        CurrentDialog.DialogCallback = true;
    }



}
