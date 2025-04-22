using UnityEngine;

public class PipelineCap : MonoBehaviour
{
    [SerializeField] PipelineSystem pipelineSystem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pipelineSystem.OnPassing();
        }
    }
}
