using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PopUp : MonoBehaviour
{
    private UIDocument _document;
    private Button _popUpButton;
    private VisualElement _root;  

    public static PopUp instance;

    private void Awake()
    {
        if (instance == null) instance = this;

        _document = GetComponent<UIDocument>();
        _root = _document.rootVisualElement;

        _popUpButton = _root.Q<Button>("ButtonExit");

        if (_popUpButton != null)
        {
            _popUpButton.clicked += OnButtonClicked;
        }
        HidePopup();
    }

    public void ShowPopup()
    {
        _root.style.display = DisplayStyle.Flex;
    }

    public void HidePopup()
    {
        _root.style.display = DisplayStyle.None;
    }

    private void OnButtonClicked()
    {
        SceneManager.LoadSceneAsync(0);
        HidePopup();
    }

    private void OnDestroy() 
    {
        if (_popUpButton != null)
        {
            _popUpButton.clicked -= OnButtonClicked;
        }
    }
}