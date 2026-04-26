using FMODUnity;
using System;
using UnityEngine;

public class collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public float bobIntensity = 0.25f;
    public float bobSpeed = 1f;
    public EventReference apple;
    private Vector3 startPos;
    private FMOD.Studio.EventInstance soundInstance;

    void Start()
    {
        startPos = transform.position;

        soundInstance = RuntimeManager.CreateInstance(apple);
        RuntimeManager.AttachInstanceToGameObject(soundInstance, transform);
        soundInstance.start();
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(-90f, Time.time * 100f, 0);
        float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobIntensity;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            ShutUp();
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        ShutUp();
    }

    void ShutUp()
    {
        if (soundInstance.isValid())
        {
            soundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            soundInstance.release();
        }
    }
}