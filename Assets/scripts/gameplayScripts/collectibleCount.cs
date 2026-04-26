using UnityEngine;
using TMPro;
using FMODUnity;

public class collectibleCount : MonoBehaviour
{
    int count;
    public TMP_Text text;
    public EventReference apple;
    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }
    void OnEnable() => collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        RuntimeManager.PlayOneShot(apple);
        count++;
        text.text = $"{count}";
    }
    public int getCount()
    {
        return count;
    }
}
