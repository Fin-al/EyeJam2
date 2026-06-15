using FMODUnity;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tree : MonoBehaviour
{
    int count;
    public EventReference falling, cras;
    private FMOD.Studio.EventInstance c;
    public GameObject crash,farmer,free;
    public bool finalCrash;


    private void Awake()
    {
        count = 0;
        finalCrash = false;
    }

    private void Update()
    {
        if (count == 5 && playerData.instance.pop != 4)
        {
            RuntimeManager.PlayOneShot(falling, transform.position);
            fall();
        }
        else if (count == 5)
        {

           
            fall();
            finalCrash = true;
            farmer.transform.position = free.transform.position;
            FarmerTalking.instance.talking("M4U1DER: THANK YOU FOR SETTING ME FREE");
            FarmerTalking.instance.ShowText();


            Invoke("crashing", 5f);
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
    private void crashing()
    {
        FarmerTalking.instance.talking("M4U1DER: NOW ITS YOUR TURN TO BE FREE");
        
        playerData.instance.changePop(5);
        count++;
       
        Invoke("QuitGame", 5f);
    }
    private void QuitGame()
    {
        finalCrash = false;
        OnDestroy();
        SceneManager.LoadSceneAsync(3);
    }
    private void OnDestroy()
    {
        c.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        c.release();
    }
}