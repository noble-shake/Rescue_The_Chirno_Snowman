using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionManager : MenuManager
{ 
    public static OptionManager Instance;
    public CanvasGroup canvs;
    public CanvasGroup OptionCanvas;

    private AudioSource audioManager;

    [Header("BGM")]
    public AudioClip Init;
    public AudioClip Loop;

    [Header("SFX")]
    public AudioClip GlassBroken;
    public AudioClip Rolling;
    public AudioClip Push;

    [Header("Back")]
    public Button BackButton;

    [Space]
    [Header("SOUND")]
    public Toggle SoundToggle;

    [Space]
    [Header("RESET")]
    public CanvasGroup ResetCheckBox;
    public Button ResetButton;
    public Button ResetYESButton;
    public Button ResetNOButton;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioManager = GetComponent<AudioSource>();
    }

    private void Start()
    {
        
        canvs = GetComponent<CanvasGroup>();
        BackButton.onClick.AddListener(OnButtonBack);

        ResetButton.onClick.AddListener(OnButtonReset);
        ResetYESButton.onClick.AddListener(OnButtonResetYes);
        ResetNOButton.onClick.AddListener(OnButtonResetNo);

        SoundToggle.onValueChanged.AddListener(OnValueChangedSound);
    }

    public void OnButtonBack()
    {
        CanvasOff(canvs);
        if(TitleManager.Instance != null) CanvasOn(TitleManager.Instance.MainButtons);
        if(PauseManager.Instance != null) CanvasOn(TitleManager.Instance.MainButtons);
    }

    public void OnButtonReset()
    {
        CanvasOff(OptionCanvas);
        CanvasOn(ResetCheckBox);
    }

    public void OnButtonResetYes()
    {
        PlayerPrefs.DeleteAll();
        CanvasOff(ResetCheckBox);
        CanvasOn(OptionCanvas);
    }

    public void OnButtonResetNo()
    {
        CanvasOff(ResetCheckBox);
        CanvasOn(OptionCanvas);


    }

    public void OnValueChangedSound(bool isOn)
    {
        if (isOn)
        {
            audioManager.mute = false;
        }
        else
        {
            audioManager.mute = true;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (string.Equals(scene.name, "TitleScene"))
        {
            if(audioManager.isPlaying == true) audioManager.Stop();
            audioManager.clip = Init;
            audioManager.Play();
        }
    }

    private void Update()
    {
        if (audioManager.clip == Init && audioManager.isPlaying == false)
        {
            audioManager.Stop();
            audioManager.clip = Loop;
            audioManager.loop = true;
            audioManager.Play();
        }
    }

    public void SFXEffect(SFX _sfx)
    {
        switch (_sfx)
        {
            case SFX.Push:
                audioManager.PlayOneShot(Push);
                break;
            case SFX.Roll:
                audioManager.PlayOneShot(Rolling);
                break;
            case SFX.Glass:
                audioManager.PlayOneShot(GlassBroken);
                break;
        }
    }
}
