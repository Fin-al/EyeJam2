using FMODUnity;
using System;
using UnityEngine;

public class tree : MonoBehaviour
{
    int count;
    public EventReference falling;

    private void Awake()
    {
        count = 0;
    }

    private void Update()
    {
        if (count == 5)
        {
            RuntimeManager.PlayOneShot(falling, transform.position);
            fall();
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
}