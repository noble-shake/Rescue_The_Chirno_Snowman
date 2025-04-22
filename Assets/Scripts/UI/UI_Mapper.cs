using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Mapper : MonoBehaviour
{
    public static UI_Mapper Instance;

    private ChirnoManager chirno;

    [Header("UI")]
    [SerializeField] TMP_Text LevelText;
    [SerializeField] TMP_Text ObjectiveText;
    [SerializeField] TMP_Text RemainedText;
    [SerializeField] TMP_Text SizeText;
    [SerializeField] Image GreatFairy;

    [Header("Fairy Image")]
    [SerializeField] Sprite Idle;
    [SerializeField] Sprite PushToLeft;
    [SerializeField] Sprite PushToRight;
    [SerializeField] Sprite Pain;

    [Header("Buttons")]
    [SerializeField] Button RestartBtn;
    [SerializeField] Button MenuBtn;

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
        RestartBtn.onClick.AddListener(Reset);
        MenuBtn.onClick.AddListener(ReturnToMain);
    }

    public void ReturnToMain()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Reset()
    {
        // Effect Instantiate.

        StartCoroutine(ResetPhase());

        // Restart 를 누르거나, 게임이 시작 될 때.
        // StartArea.Instance.Spawn();
    }

    IEnumerator ResetPhase()
    {
        GameManager.Instance.GameClearAllObject();

        yield return null;

        GameManager.Instance.GameStart();
    }

    public void Register()
    { 
        chirno = ChirnoManager.Instance;
    }

    public void SetFairyImage(FairyFace _face)
    {
        switch (_face)
        {
            default:
            case FairyFace.Idle:
                GreatFairy.sprite = Idle;
                break;
            case FairyFace.Pain:
                GreatFairy.sprite = Pain;
                break;
            case FairyFace.PushToLeft:
                GreatFairy.sprite = PushToLeft;
                break;
            case FairyFace.PushToRight:
                GreatFairy.sprite = PushToRight;
                break;
        }
    }

    private void Update()
    {
        if (chirno != null)
        {
            SizeText.text = $"SIZE:  {float.Parse(chirno.gameObject.transform.localScale.x.ToString("N1"))}";
        }

        if (GameManager.Instance != null)
        {
            LevelText.text = $"LEVEL: {string.Format("{0:D2}", GameManager.Instance.CurrentLevel +1)}";
            RemainedText.text = $"<color=blue>{string.Format("{0:D2}", GameManager.Instance.PushLeft)}</color> PUSH Left";
            ObjectiveText.text = $"Size Must Be <color=blue>{GameManager.Instance.ConditionSize} or {(GameManager.Instance.isHigher? "High" : "Lower")}</color>";

        }
    }

}
