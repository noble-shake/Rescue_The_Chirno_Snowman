using UnityEngine;

public class GoalArea : MonoBehaviour
{
    GameManager gameManager;
    bool isChecked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ClearCheck();
        }
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void ClearCheck()
    {
        float size = ChirnoManager.Instance.gameObject.transform.localScale.x;

        if (gameManager.isHigher && gameManager.ConditionSize <= size)
        {
            if (isChecked) return;
            isChecked = true;
            Debug.Log("Clear!");
            PauseManager.Instance.CanvasOn(PauseManager.Instance.GetComponent<CanvasGroup>());

            PlayerPrefs.SetInt(((enumStage)(GameManager.Instance.CurrentLevel + 1)).ToString(), 1);
        }
        else if (gameManager.isHigher == false && gameManager.ConditionSize >= size)
        {
            if (isChecked) return;
            isChecked = true;
            Debug.Log("Clear!");
            PauseManager.Instance.CanvasOn(PauseManager.Instance.GetComponent<CanvasGroup>());

            PlayerPrefs.SetInt(((enumStage)(GameManager.Instance.CurrentLevel + 1)).ToString(), 1);
        }
        else
        {
            Debug.Log("Condition Must be...");
        }
    }


}
