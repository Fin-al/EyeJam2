using UnityEngine;

public class fallOfBounds : MonoBehaviour
{
    public GameObject location;
    private void OnTriggerExit(Collider other)
    {
        

        CharacterController cc = other.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
            other.transform.position = location.transform.position;
            cc.enabled = true;
        }
    }
}
