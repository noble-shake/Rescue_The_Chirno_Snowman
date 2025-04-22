using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    public List<Sprite> Backgrounds;
    int target = 0;

    public Image CurrentBG;
    CanvasGroup CurrentCG;
    public Image ChangeBG;
    CanvasGroup ChangeCG;
    float Delay;


    private void Start()
    {
        CurrentCG = CurrentBG.GetComponent<CanvasGroup>();
        ChangeCG = ChangeBG.GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        Delay -= Time.deltaTime;

        if (Delay < 0f)
        {
            StartCoroutine(BackgroundChange());
            Delay = 5f;
        }

    }


    IEnumerator BackgroundChange()
    {
        float alpha = 0f;

        ChangeCG.alpha = 0f;
        CurrentCG.alpha = 1f;
        
        target++;
        if (target == Backgrounds.Count) target = 0;
        ChangeBG.sprite = Backgrounds[target];
        while (alpha < 1f)
        {
            alpha += Time.deltaTime / 5f;    
            if (alpha >= 1f)
            {
                alpha = 1f;
                CurrentBG.sprite = Backgrounds[target];
            }

            ChangeCG.alpha += alpha;
            CurrentCG.alpha += (1- alpha);
            yield return null;
        }
        
        ChangeCG.alpha = 0f;
        CurrentCG.alpha = 1f;
        yield return null;



    }



}
