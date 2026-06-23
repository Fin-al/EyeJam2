using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    public bool touching = false, final = false;
    public int count = 0;
    public GameObject farmer;
    private Vector3 pos;
    public gameEvents gevent;
    private void Awake()
    {
        pos = farmer.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Out") && !touching)
        {
            count++;
            switch (count) {  
                     
                case 1:
                    {
                        FarmerTalking.instance.talking("PLAYER: I SHOULD GO BACK.");
                        FarmerTalking.instance.ShowText();
                        Debug.Log(count);
                        touching = true;
                        break;
                    }
               
                case 2:
                    {
                        FarmerTalking.instance.talking("PLAYER: I REALLY NEED TO GO BACK.");
                        FarmerTalking.instance.ShowText();
                        Debug.Log("Hit wall");
                        touching = true;
                        break;
                    }
                case 3:
                    {
                        FarmerTalking.instance.talking("PLAYER: HE WILL GET MAD.");
                        FarmerTalking.instance.ShowText();
                        Debug.Log("Hit wall");
                        touching = true;
                        break;
                    }
                case 4:
                    {
                        FarmerTalking.instance.talking("MAULDER: GO BACK");
                        FarmerTalking.instance.ShowText();
                        farmer.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10f);
                        touching = true;
                        break;
                    }
                case 5:
                    {
                        FarmerTalking.instance.talking("PLAYER: YOU HEARD HIM!");
                        FarmerTalking.instance.ShowText();
                        touching = true;
                        break;
                    }
                    default:
                    {
                        FarmerTalking.instance.talking("PLAYER: TIME TO GO BACK.");
                        FarmerTalking.instance.ShowText();
                        touching = true;
                        break;
                    }
            }
        } else if(other.gameObject.CompareTag("newOut")&& !touching)
        {
            FarmerTalking.instance.talking("COME BACK");
            FarmerTalking.instance.ShowText();
            touching = true;
            final = true;
            gevent.OnDestroy();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.CompareTag("Out")|| other.gameObject.CompareTag("newOut")) && touching )
        {
            FarmerTalking.instance.HideText();
            touching = false;
            farmer.transform.position = pos;
            //farmer.transform.rotation = Quaternion.Euler(90f, 0f, 90f);
        }
    }
    public void changeFinal()
    {
        final = false;
    }
}
