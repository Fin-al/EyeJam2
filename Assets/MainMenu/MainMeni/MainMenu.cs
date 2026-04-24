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
        }
        Debug.Log("HELLO");
    }
    private void OnButtonClicked()
    {
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
}
