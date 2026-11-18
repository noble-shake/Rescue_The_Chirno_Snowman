using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public enum ChrinoFace
{ 
    Idle,
    Panic,
    Arrogant,
}

public class ChirnoManager: MonoBehaviour
{ 
    public static ChirnoManager Instance;

    [SerializeField] Sprite ChrinoIdle;
    [SerializeField] Sprite ChrinoPanic;
    [SerializeField] Sprite ChrinoArrogant;

    [SerializeField] public SpriteRenderer ChirnoFace;
    [SerializeField] SpriteRenderer ChirnoSnowBall;
    [SerializeField] SpriteRenderer ChirnoSnowShadow;

    private Rigidbody2D rigid;
    public bool isGround;
    public bool isSnow;
    public bool isHeat;
    public bool isHeatArea;
    public bool isColdArea;

    private float soundDelay;

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
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        soundDelay -= Time.deltaTime;
        if (soundDelay < 0f)
        {
            soundDelay = 0f;
        }
            // bool Panic or...
         if (rigid.linearVelocity.magnitude < 0.5f)
        {
            // Peaceful
            if(ChirnoFace != null) ChirnoFace.sprite = FaceChange(ChrinoFace.Idle);
            // return;


        }
        else
        {
            if (isGround && soundDelay == 0f)
            {
                soundDelay = 1.5f;
                if (OptionManager.Instance != null) OptionManager.Instance.SFXEffect(SFX.Roll);
            }

            if (ChirnoFace != null) ChirnoFace.sprite = FaceChange(ChrinoFace.Panic);
            if (isGround && isSnow) SizeUp();
            if (isGround && isHeat) SizeOff();
        }

        if(isColdArea) SizeUp();
        if(isHeatArea) SizeOff();

        if (GameManager.Instance.PushLeft < 1)
        {
            if (ChirnoFace != null) ChirnoFace.sprite = FaceChange(ChrinoFace.Arrogant);
        }

    }

    public void PushChirno(bool isToLeft)
    {
        // Pushing Use AddFroce.
        if (GameManager.Instance.PushLeft > 0)
        {
            if(OptionManager.Instance != null) OptionManager.Instance.SFXEffect(SFX.Push);
            GameManager.Instance.PushLeft--;
            rigid.AddForce((isToLeft ? Vector2.left : Vector2.right) * 5f, ForceMode2D.Impulse);
        }

    }

    public Sprite FaceChange(ChrinoFace _face)
    {
        switch (_face)
        {
            default:
            case ChrinoFace.Idle:
                return ChrinoIdle;
            case ChrinoFace.Panic:
                return ChrinoPanic;
            case ChrinoFace.Arrogant:
                return ChrinoArrogant;
        }
    }

    public void OnGround(Collider2D collision)
    {
        isGround = true;
        if (collision.CompareTag(GameTag.SnowGround.ToString()))
        {
            isSnow = true;
        }
        if (collision.CompareTag(GameTag.HeatGround.ToString()))
        {
            isHeat = true;
        }
        if (collision.CompareTag(GameTag.HeatArea.ToString()))
        {
            isHeatArea = true;
        }
        if (collision.CompareTag(GameTag.ColdArea.ToString()))
        {
            isColdArea = true;
        }
    }

    public void OffGround()
    {
        isGround = false;
        isSnow = false;
        isHeat = false;
    }

    public void ExitArea()
    {
        isHeatArea = false;
        isColdArea = false;
    }

    float Scaler = 1f;

    // TODO : Size up by Velocity Value.
    private void SizeUp()
    {
        Scaler = 0.25f * Time.deltaTime;
        

        transform.localScale += new Vector3(Scaler, Scaler, Scaler);
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, 1f, 5f), Mathf.Clamp(transform.localScale.y, 1f, 5f), Mathf.Clamp(transform.localScale.z, 1f, 5f)); ;
        ChirnoFace.gameObject.transform.localScale = Vector3.one;
    }

    private void SizeOff()
    {
        Scaler = -0.25f * Time.deltaTime;


        transform.localScale += new Vector3(Scaler, Scaler, Scaler);
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, 1f, 5f), Mathf.Clamp(transform.localScale.y, 1f, 5f), Mathf.Clamp(transform.localScale.z, 1f, 5f)); ;
        ChirnoFace.gameObject.transform.localScale = Vector3.one;
    }


}