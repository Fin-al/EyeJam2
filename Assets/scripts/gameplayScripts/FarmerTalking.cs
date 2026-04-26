using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class FarmerTalking : MonoBehaviour
{
    private UIDocument _document;
     
    private VisualElement _root;
    public EventReference pop;
    public static FarmerTalking instance;
    private Label farmertext;

    private void Awake()
    {
        if (instance == null) instance = this;

        _document = GetComponent<UIDocument>();
        _root = _document.rootVisualElement;
        

        
        farmertext = _root.Q<Label>("Label");

   
        HideText();
    }

    public void ShowText()
    {
        _root.style.display = DisplayStyle.Flex;
        RuntimeManager.PlayOneShot(pop);
    }

    public void HideText()
    {
        _root.style.display = DisplayStyle.None;
    }

    private void OnButtonClicked()
    {
        SceneManager.LoadSceneAsync(0);
        HideText();
    }
    public void talking(string words)
    {
        farmertext.text = words;
    }

    
}
