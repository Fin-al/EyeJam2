using UnityEngine;

public class axePickup : MonoBehaviour
{
    public float interactionDistance = 5.0f;
    public axe axing;
    public GameObject intText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject.tag == "axe" && axing.isAxe)
            {


                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    axing.pickUp();
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
            
        }
    }
}
