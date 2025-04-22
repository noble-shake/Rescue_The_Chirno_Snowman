using UnityEngine;

public class PipelineSystem : MonoBehaviour
{
    [Header("Pipe Size")]
    [SerializeField] public float SizeRestrict;

    [Space]
    [Header("Entrance")]
    [SerializeField] public PipeEntrance Entrace;
    [SerializeField] public PipelineCap Cap;
    private BoxCollider2D CapCollider;

    [Space]
    [Header("Linked Pipe")]
    [SerializeField] public PipelineSystem LinkedPipe;

    [HideInInspector] public PipeExit Exit;

    public float DelayTime;

    private Vector2 Force;

    private void Start()
    {
        Exit = (PipeExit)System.Enum.Parse(typeof(PipeEntrance), LinkedPipe.Entrace.ToString());
        CapCollider = Cap.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (ChirnoManager.Instance == null) return;

        DelayTime -= Time.deltaTime;
        if (DelayTime < 0f)
        {
            DelayTime = 0f;
        }

        float size = ChirnoManager.Instance.transform.localScale.x;

        if (size > SizeRestrict || ChirnoManager.Instance.GetComponent<Rigidbody2D>().linearVelocity == Vector2.zero)
        {
            CapCollider.enabled = false;
        }
        else
        {
            CapCollider.enabled = true;
        }

    }

    public Vector2 ForceVector()
    {
        switch (Exit)
        {
            default:
            case PipeExit.LEFT:
                return Vector2.left * 3f;
            case PipeExit.RIGHT:
                return Vector2.right * 3f;
            case PipeExit.UP:
                return Vector2.up * 3f;
            case PipeExit.DOWN:
                return Vector2.down * 3f;
        }
    }

    public void OnPassing()
    {
        if (DelayTime != 0f && LinkedPipe.DelayTime != 0f) return;

        ChirnoManager.Instance.transform.position = LinkedPipe.Cap.transform.position;
        ChirnoManager.Instance.GetComponent<Rigidbody2D>().AddForce(ForceVector(), ForceMode2D.Impulse);
        DelayTime = 0.3f;
        LinkedPipe.DelayTime = 0.3f;
    }

}
