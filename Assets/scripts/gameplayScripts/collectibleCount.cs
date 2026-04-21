using UnityEngine;

public class collectibleCount : MonoBehaviour
{
    int count;

    private void Awake()
    {
        
    }
    void OnEnable() => collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        Debug.Log(++count);
    }
    public int getCount()
    {
        return count;
    }
}
