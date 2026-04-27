//using Palmmedia.ReportGenerator.Core;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class farmerTalkin1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float interactionDistance = 5.0f;
    public axe axing;
    public GameObject intText;
    public collectibleCount count;
    public TMPro.TMP_Text text;
    public bool on;
   
    void Start()
    {
        on = false;
    }
    // Update is called once per frame

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject.tag == "farmer")
            {
           
                
                intText.SetActive(true);
                if((playerData.instance.pop == 1 || playerData.instance.pop == 2) && Input.GetKeyDown(KeyCode.E) && count.getCount() <6)
                {
                    Debug.Log(count.getCount());
                    FarmerTalking.instance.talking("FARMER MAULDER: FIND MY APPLES");
                    FarmerTalking.instance.ShowText();
                    text.text = $"FIND HIS APPLES";
                }
                else if (count.getCount() >= 7 && Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Task 2");
                    FarmerTalking.instance.talking("FARMER MAULDER: GRAB MY AXE AND CHOP MY TREES");
                    FarmerTalking.instance.ShowText();
                    text.text = $"CHOP HIS BIRCH TREES WITH HIS AXE";
                    
                    axing.axeTask();
                } else if (playerData.instance.pop == 4 && Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Task 4");
                    FarmerTalking.instance.talking("M4U1DER: FIND TR33");
                    FarmerTalking.instance.ShowText();
                    text.text = $"FIND HSI TREE";
                    axing.axeTask();
                }
                
            }
            else
            {
                intText.SetActive(false);
            }
        }
        else
        {
            intText.SetActive(false);
            FarmerTalking.instance.HideText();
        }
    }
    /* void onOrOff()
     {
         on = !on;
     } */
    public bool panelStatus()
    {
        return on;
    }
}
