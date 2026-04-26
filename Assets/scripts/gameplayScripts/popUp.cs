using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PopUp : MonoBehaviour
{
    public UIDocument _document, doc2;
    private Button _popUpButton, _popUpButton2;
    private VisualElement _root, _root2;
    public EventReference pop;
    public static PopUp instance;

    private void Awake()
    {
        if (instance == null) instance = this;

        _root = _document.rootVisualElement;
        _root2 = doc2.rootVisualElement;

        _root.style.display = DisplayStyle.None;
        _root2.style.display = DisplayStyle.None;

        _popUpButton = _root.Q<Button>("ButtonExit");
        _popUpButton2 = _root2.Q<Button>("ButtonExit");

        if (_popUpButton != null)
        {
            _popUpButton.clicked += OnButtonClicked;
        }

        if (_popUpButton2 != null)
        {
            _popUpButton2.clicked += OnButtonClicked;
        }
    }

    public void ShowPopup()
    {
        if (playerData.instance.pop == 3)
        {
            _root2.style.display = DisplayStyle.Flex;
        }
        else
        {
            _root.style.display = DisplayStyle.Flex;
        }

        RuntimeManager.PlayOneShot(pop);
    }

    public void HidePopup()
    {
        _root.style.display = DisplayStyle.None;
        _root2.style.display = DisplayStyle.None;
    }

    private void OnButtonClicked()
    {
        HidePopup();
        SceneManager.LoadSceneAsync(0);
    }

    private void OnDestroy()
    {
        if (_popUpButton != null)
        {
            _popUpButton.clicked -= OnButtonClicked;
        }

        if (_popUpButton2 != null)
        {
            _popUpButton2.clicked -= OnButtonClicked;
        }
    }
}