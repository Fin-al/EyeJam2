using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    public bool touching = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Out") && !touching)
        {
            FarmerTalking.instance.talking("PLAYER: I SHOULD GO BACK.");
            FarmerTalking.instance.ShowText();
            Debug.Log("Hit wall");
            touching = true;
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
