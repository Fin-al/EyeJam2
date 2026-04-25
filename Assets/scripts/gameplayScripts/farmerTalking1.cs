//using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmerTalkin1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float interactionDistance = 5.0f;

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
                if((playerData.instance.pop == 1 || playerData.instance.pop == 2) && Input.GetKeyDown(KeyCode.E) && count.getCount() <7)
                {
                    FarmerTalking.instance.talking("FARMER MAULDER: FIND MY APPLES");
                    FarmerTalking.instance.ShowText();
                    text.text = $"FIND HIS APPLES";
                }
                else if (count.getCount() >= 7 && Input.GetKeyDown(KeyCode.E))
                {
                    
                    FarmerTalking.instance.talking("FARMER MAULDER: THANKS! NOW CHOP MY BIRCH TREES.");
                    FarmerTalking.instance.ShowText();
                    text.text = $"CHOP HIS BIRCH TREES";
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
