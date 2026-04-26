using FMODUnity;
using UnityEngine;

public class axe : MonoBehaviour
{
    public bool isAxe;
    public GameObject door, door2;
    private int count;
    public EventReference axe1;
    private FMOD.Studio.EventInstance soundInstance;

    private void Awake()
    {
        isAxe = false;
        count = 0;
    }

    void Update()
    {
        if (isAxe && count == 1)
        {
            if (!soundInstance.isValid())
            {
                soundInstance = RuntimeManager.CreateInstance(axe1);
                RuntimeManager.AttachInstanceToGameObject(soundInstance, transform);
                soundInstance.start();
            }
        }
    }

    public void axeTask()
    {
        isAxe = true;
        door.transform.localRotation = Quaternion.Euler(0, 0, 90f);
        door2.transform.localRotation = Quaternion.Euler(0, 0, -270f);
        count++;
    }

    public void pickUp()
    {
        ShutUp();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        if (gameObject.GetComponent<Collider>() != null)
        {
            gameObject.GetComponent<Collider>().enabled = false;
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