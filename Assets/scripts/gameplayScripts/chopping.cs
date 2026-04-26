using FMODUnity;
using UnityEngine;

public class chopping : MonoBehaviour
{
    public float interactionDistance = 5.0f;
    public axe axing;
    public GameObject intText;
    public EventReference axe;
    public tree tre;
    public int count;
 //   private FMOD.Studio.EventInstance sound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject.tag == "birch"&& axing.isAxe)
            {
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    RuntimeManager.PlayOneShot(axe,gameObject.transform.position);
                    tre = hit.collider.GetComponent<tree>();
                    tre.chop();
                    count++;
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
    private void OnDestroy()
    {
      //  sound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
       // sound.release();
    }
}
