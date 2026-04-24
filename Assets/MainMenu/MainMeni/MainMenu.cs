using FMODUnity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    private UIDocument _document;
    private Button start,end ;
    private VisualElement _root;
    public EventReference click,hover;
    private readonly Color normalColor = new Color(0.376f, 0.18f, 0.039f);

    private void Awake()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
            Debug.Log("Playing: " + audio.clip.name);
        }
        else
        {
            Debug.LogError("No AudioSource found on this object!");
        }

        Time.timeScale = 1f;
        if (instance == null) instance = this;

        _document = GetComponent<UIDocument>();
        _root = _document.rootVisualElement;

        start = _root.Q<Button>("NewGame");
        end = _root.Q<Button>("Exit");

        if (start != null && end!=null)
        {
            start.clicked += OnButtonClicked;
            end.clicked += exit;

            start.RegisterCallback<PointerEnterEvent>(OnButtonHover);
            end.RegisterCallback<PointerEnterEvent>(OnButtonHover);
            start.RegisterCallback<PointerLeaveEvent>(OnButtonLeave);
            end.RegisterCallback<PointerLeaveEvent>(OnButtonLeave);
        }
        Debug.Log("HELLO");
    }
    private void OnButtonClicked()
    {
        RuntimeManager.PlayOneShot(click);
        Debug.Log("Pressed");
        SceneManager.LoadSceneAsync(1);
    }
    private void load()
    {
        SceneManager.LoadSceneAsync(1);

    }
    private void exit()
    {
        playerData.instance.changePop(1);
        Application.Quit();
    }
    private void OnButtonHover(PointerEnterEvent evt)
    {
        RuntimeManager.PlayOneShot(hover);
        VisualElement button = evt.target as VisualElement;
        button.style.backgroundColor = new StyleColor(new Color(0.6f, 0.4f, 0.2f));
        button.style.scale = new StyleScale(new Vector2(1.05f, 1.05f));
    }
    private void OnButtonLeave(PointerLeaveEvent evt)
    {
        VisualElement button = evt.target as VisualElement;
        button.style.backgroundColor = normalColor;
        button.style.scale = new StyleScale(new Vector2(1.0f, 1.0f));
    }
}
