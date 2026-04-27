using FMODUnity;
using System;
using UnityEngine;

public class tree : MonoBehaviour
{
    int count;
    public EventReference falling, cras;
    private FMOD.Studio.EventInstance c;
    public GameObject crash;

    private void Awake()
    {
        count = 0;
        
    }

    private void Update()
    {
        if (count == 5 && playerData.instance.pop !=4)
        {
            RuntimeManager.PlayOneShot(falling, transform.position);
            fall();
        }
        else if (count == 5)
        {

          
            crash.SetActive(true);
            playerData.instance.changePop(1);
            count++;
            RuntimeManager.PlayOneShot(cras, gameObject.transform.position);
            Invoke("QuitGame", 1f);
        }
    }

    public void chop()
    {
        count++;
    }

    private void fall()
    {
        count++;

        if (GetComponent<MeshRenderer>() != null)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }

        if (GetComponent<Collider>() != null)
        {
            GetComponent<Collider>().enabled = false;
        }
    }

    private void QuitGame()
    {
        OnDestroy();
        Application.Quit();
    }
    private void OnDestroy()
    {
        c.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        c.release();
    }
}