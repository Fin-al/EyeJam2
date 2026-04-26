using UnityEngine;

public class popUp2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerData.instance.changePop(3);
        }
    }
}
