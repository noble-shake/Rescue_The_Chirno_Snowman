using UnityEngine;

public class ChirnoGroundCollider : MonoBehaviour
{
    ChirnoManager Chirno;

    private void Start()
    {
        Chirno = ChirnoManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Chirno.OnGround(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        
        Chirno.OnGround(collision);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTag.SnowGround.ToString()) || collision.CompareTag(GameTag.HeatGround.ToString()))
        {
            Chirno.OffGround();
        }
        if (collision.CompareTag(GameTag.ColdArea.ToString()) || collision.CompareTag(GameTag.HeatArea.ToString()))
        {
            Chirno.ExitArea();
        }

    }
}