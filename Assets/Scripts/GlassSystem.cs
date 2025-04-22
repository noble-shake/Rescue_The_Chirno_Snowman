using UnityEngine;

public class GlassSystem : MonoBehaviour
{
    [SerializeField] float sizeRestrict;
    BoxCollider2D collider;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite Breaked;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            BreakCheck();
        }
    }

    public void BreakCheck()
    {
        float size = ChirnoManager.Instance.transform.localScale.x;

        if (size >= sizeRestrict)
        {
            OptionManager.Instance.SFXEffect(SFX.Glass);
            spriteRenderer.sprite = Breaked;
            collider.enabled = false;
        }
    }
}
