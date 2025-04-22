using UnityEngine;

public class GameBinder : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.PhaseStart();
    }
}
