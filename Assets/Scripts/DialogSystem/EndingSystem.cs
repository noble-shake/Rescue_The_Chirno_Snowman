using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using NUnit.Framework;
using System;

[System.Serializable]
public class DialogsRead
{
    public string info;
    public bool check_read;
}

[System.Serializable]
public class DialogCycle
{
    public List<DialogsRead> info = new List<DialogsRead>();
    public int cycle_index;
    public bool check_cycle_read;
}


public class EndingSystem : MonoBehaviour
{
    public static EndingSystem Instance;

    public CanvasGroup EndIllust;
    public CanvasGroup EndWriting;
    public TMP_Text ScriptArea;

    [TextArea] public List<string> EndingScripts;

    public List<CanvasGroup> CreditList;

    DialogsRead CurrentDialog;

    void Awake()
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
        StartCoroutine(IllustEffect());
        
    }

    public IEnumerator CreditEffect()
    {
        float alpha = 0f;
        yield return null;

        for (int idx = 0; idx < CreditList.Count; idx++)
        {
            alpha = 0f;
            while (alpha < 1f)
            {
                alpha += Time.deltaTime / 4f;
                if (alpha > 1f)
                {
                    alpha = 1f;
                }
                CreditList[idx].alpha = alpha;

                yield return null;


            }
            alpha = 0f;
            while (alpha < 1f)
            {
                alpha += Time.deltaTime / 2f;
                if (alpha > 1f)
                {
                    alpha = 1f;
                }
                CreditList[idx].alpha = 1 - alpha;

                yield return null;
            }

            yield return new WaitForSeconds(2f);
        }
        SceneManager.LoadSceneAsync(0);
    }


    public IEnumerator IllustEffect()
    {
        float alpha = 0f;
        yield return null;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime / 2f;
            if (alpha > 1f)
            {
                alpha = 1f;
            }
            EndIllust.alpha = alpha;

            yield return null;
        }
        StartCoroutine(CreditEffect());
        StartCoroutine(EndingSequence());
    }

    public IEnumerator EndingWriteOn()
    {
        float alpha = 0f;
        yield return null;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime / 3f;
            if (alpha > 1f)
            {
                alpha = 1f;
            }
            EndWriting.alpha = alpha;

            yield return null;



        }

    }

    public IEnumerator EndingSequence()
    {
        Queue<DialogsRead> text_seq = new Queue<DialogsRead>();
        yield return null;

        for (int i = 0; i < EndingScripts.Count; i++)
        {
            DialogsRead dialogObject =  new DialogsRead() { info = EndingScripts[i], check_read = false };
            text_seq.Enqueue(dialogObject);
        }


        for (int idx = 0; idx < EndingScripts.Count; idx++)
        {
            CurrentDialog = text_seq.Dequeue();
            
            StartCoroutine(SequanceCoroutine(CurrentDialog.info));

            yield return new WaitUntil(() =>
            {
                if (CurrentDialog.check_read)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });

            yield return new WaitForSeconds(3f);
        }

        StartCoroutine(EndingWriteOn());
    }

    IEnumerator SequanceCoroutine(string _text)
    {
        yield return null;

        ScriptArea.text = "";

        foreach (char letter in _text.ToCharArray())
        {
            ScriptArea.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

        CurrentDialog.check_read = true;

    }


    }
