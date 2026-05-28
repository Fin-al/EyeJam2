using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    private bool touching = false;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Out") && !touching)
        {
            FarmerTalking.instance.talking("PLAYER: I SHOULD GO BACK.");
            FarmerTalking.instance.ShowText();
            Debug.Log("Hit wall");
            touching = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Out"))
        {
            touching = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Out") && touching)
        {
            FarmerTalking.instance.HideText();
            touching = false;

        }
    }
}
