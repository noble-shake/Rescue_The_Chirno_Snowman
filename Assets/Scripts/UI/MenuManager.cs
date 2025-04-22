using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void CanvasOn(CanvasGroup Group)
    {
        Group.alpha = 1.0f;
        Group.blocksRaycasts = true;
        Group.interactable = true;
    }

    public void CanvasOff(CanvasGroup Group)
    {
        Group.alpha = 0f;
        Group.blocksRaycasts = false;
        Group.interactable = false;
    }
}
