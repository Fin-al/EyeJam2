using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FINALCRASH : MonoBehaviour
{
    public OutofBounds boolCheck;
    public EventReference cras;
    private FMOD.Studio.EventInstance c;
    private bool crashing;
    public GameObject crash,farm, sacryFarm;

    private void Awake()
    {
         
    }
    private void Update()
    {
        if (boolCheck.final)
        {
            farm.SetActive(false);
            sacryFarm.SetActive(true);
            boolCheck.changeFinal();
        }
        if (crashing)
        {
            Invoke("crashes",1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("crash"))
        {
            crashing = true;
        }
    }
    private void crashes()
    {
        crashing = false;
        c = RuntimeManager.CreateInstance(cras);
        c.start();

    }
    private void QuitGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    private void OnDestroy()
    {
        c.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        c.release();
    }
}
