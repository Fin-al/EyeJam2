using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    public bool touching = false;
    private int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Out") && !touching)
        {
            count++;
            switch (count) {  
                     
                case 1 or 2:
                    {
                        FarmerTalking.instance.talking("PLAYER: I SHOULD GO BACK.");
                        FarmerTalking.instance.ShowText();
                        Debug.Log(count);
                        touching = true;
                        break;
                    }
               
                case 3 or 4 or 5 or 6 or 7:
                    {
                        FarmerTalking.instance.talking("PLAYER: I REALLY NEED TO GO BACK.");
                        FarmerTalking.instance.ShowText();
                        Debug.Log("Hit wall");
                        touching = true;
                        break;
                    }
                case 9:
                    {
                        FarmerTalking.instance.talking("MAULDER: GO BACK!");
                        FarmerTalking.instance.ShowText();
                         
                        touching = true;
                        break;
                    }
                    default:
                    {
                        FarmerTalking.instance.talking("PLAYER: YOU HEARD HIM!");
                        FarmerTalking.instance.ShowText();
                        touching = true;
                        break;
                    }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Out") && touching)
        {
            FarmerTalking.instance.HideText();
            touching = false;
        }
    }
}
