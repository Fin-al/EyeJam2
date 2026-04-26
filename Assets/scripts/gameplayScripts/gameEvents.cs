using FMODUnity;
using UnityEditor;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class gameEvents : MonoBehaviour
{
    public EventReference music,ambience,nobirds;
    public collectibleCount count;
    public FPSController player;
    private int pop1;
    private bool apples;
    public TMPro.TMP_Text text;
    private FMOD.Studio.EventInstance menuMusicInstance,amb,nob;
    private void Awake()
    { 
        
        pop1 = playerData.instance.pop;
        text.text = $"TALK TO FARMER MAULDER";
        apples = true;
        if (pop1 == 1)
        {
            menuMusicInstance = RuntimeManager.CreateInstance(music);
            menuMusicInstance.start();
            amb = RuntimeManager.CreateInstance(ambience);
            amb.start();
        }
        else if (pop1 == 2) {
            nob = RuntimeManager.CreateInstance(nobirds);
            nob.start();
        }
    }
    void Update()
    {
        switch (pop1)
        {
            case 1:
                {
                    
                    if (count.getCount() == 7)
                    {
                        crash();
                        
                        playerData.instance.changePop(2);
                    }
                    break;
                }
            case 2:
                {
                    
                    if (count.getCount() == 7 && apples)
                    {
                        apples = false;
                        text.text = $"RETURN THE APPLES TO FARMER MAULDER";
                    }
                     
                    break;
                }
            default: {  break; }
        }
    }
    void crash()
    {
        player.enabled = false;
        PopUp.instance.ShowPopup();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        OnDestroy();
    }
    private void OnDestroy()
    {
        menuMusicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        menuMusicInstance.release();
        amb.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        nob.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        nob.release();
    }
}
