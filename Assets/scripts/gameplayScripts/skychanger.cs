using UnityEngine;

public class skychanger : MonoBehaviour
{
    public float interactionDistance = 1000.0f;
    public Material newSkybox;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject.tag == "eye")
            {

                if (newSkybox != null)
                {
                    RenderSettings.skybox = newSkybox;
                    DynamicGI.UpdateEnvironment();
                }
                  
            }
        }
    }
}