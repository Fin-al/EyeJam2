using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FINALCRASH : MonoBehaviour
{
    public OutofBounds boolCheck;
    public EventReference cras, cosa;
    private FMOD.Studio.EventInstance c, thing;
    private bool crashing;
    public GameObject crash, farm, sacryFarm;
    public GameObject black;

    private void Awake()
    {
        black.SetActive(false);
        c = RuntimeManager.CreateInstance(cras); 
    }

    private void Update()
    {
        if (boolCheck.final)
        {
        
            farm.SetActive(false);
            sacryFarm.SetActive(true);
            boolCheck.changeFinal();
            black.SetActive(true);
            thing.start();
           
        }

        if (crashing)
        {
            crashing = false;
            Invoke("crashes", 1f); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("crash") && !crashing)
        {
            crashing = true;
        }
    }

    private void crashes()
    {
        c.start(); 
        crash.SetActive(true);
        Invoke("QuitGame", 5f);
    }

    private void QuitGame()
    {
        playerData.instance.changePop(1);
        Application.Quit();
        black.SetActive(false);
        
    }

    private void OnDestroy()
    {
        c.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        c.release();

        thing.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        thing.release();
    }
}
