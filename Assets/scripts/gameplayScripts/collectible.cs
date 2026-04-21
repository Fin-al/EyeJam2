using System;
using UnityEngine;

public class collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public float bobIntensity = 0.25f;
    public float bobSpeed = 1f;

    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f,Time.time * 100f,0);
        float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobIntensity;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

    }
     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
