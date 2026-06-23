using UnityEngine;

public class FINALCRASH : MonoBehaviour
{
    public OutofBounds boolCheck;
    public GameObject farm, sacryFarm;

    private void Update()
    {
        if (boolCheck.final)
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(""))
        {

        }
    }
}
