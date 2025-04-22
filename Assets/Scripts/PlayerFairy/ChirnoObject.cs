using UnityEngine;

public class ChirnoObject : MonoBehaviour
{
    public static ChirnoObject Instance;
    public ChirnoManager chirnoManager;

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
        if(chirnoManager != null)  chirnoManager = ChirnoManager.Instance;
    }

    private void Update()
    {
        if (chirnoManager == null) return; 

        transform.position = chirnoManager.transform.position;
        transform.rotation = chirnoManager.transform.rotation;
    }
}