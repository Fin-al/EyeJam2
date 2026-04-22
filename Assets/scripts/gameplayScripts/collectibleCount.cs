using UnityEngine;

public class collectibleCount : MonoBehaviour
{
    int count;
    TMPro.TMP_Text text;
    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }
    void OnEnable() => collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        count++;
        text.text = $"{count}";
    }
    public int getCount()
    {
        return count;
    }
}
