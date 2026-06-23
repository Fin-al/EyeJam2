using FMODUnity;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class gameEvents : MonoBehaviour
{
    public EventReference music,ambience,nobirds,creepymusic, outSide,superScary;
    public collectibleCount count;
    public FPSController player;
    private int pop1;
    private bool apples;
    public TMPro.TMP_Text text;
    private FMOD.Studio.EventInstance menuMusicInstance,amb,nob,creep, sideOut,scary;
    public chopping chopCheck;
    public GameObject farmer, act2;
    public OutofBounds OutofBounds;
    Terrain terrain;
    
    private void Awake()
    {
        var texts = new List<string> { "FIND HIM", "THERE IS NOTHING YOU CAN DO", "SURVIVE", "DIE", "YOU ARE NOW ALONE", "I AM FREE, YOU ARE NOT" };
        terrain = Terrain.activeTerrain;
        terrain.treeDistance = 500;
        pop1 = playerData.instance.pop;
        text.text = $"TALK TO FARMER MAULDER";
        apples = true;
        if (pop1 == 1 && OutofBounds.count != 9)
        {
            menuMusicInstance = RuntimeManager.CreateInstance(music);
            menuMusicInstance.start();
            amb = RuntimeManager.CreateInstance(ambience);
            amb.start();
        }
        else if (pop1 == 2 && OutofBounds.count != 9)
        {
            creep = RuntimeManager.CreateInstance(creepymusic);
            creep.start();
            nob = RuntimeManager.CreateInstance(nobirds);
            nob.start();
        }
        else if (pop1 == 4)
        {
            sideOut = RuntimeManager.CreateInstance(outSide);
            sideOut.start();
        }
        else if (pop1 == 5)
        {
            scary = RuntimeManager.CreateInstance(superScary);
            scary.setVolume(0.1f);
            scary.start();
            text.text = texts[Random.Range(0, texts.Count)];
        }
    }
    void Update()
    {
        pop1 = playerData.instance.pop;
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
                    }else if(chopCheck.count == 15)
                    {
                        chopCheck.add();
                        text.text = $"RETURN BACK";
                        VanishForest();
                        OnDestroy();
                    }
                    if (OutofBounds.count == 4)
                    {
                        OnDestroy();
                    }

                    break;
                }
            case 3:
                {
                    crash();
                    Debug.Log("task 4");
                    playerData.instance.changePop(4);
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
    public void OnDestroy()
    {
        menuMusicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        menuMusicInstance.release();
        amb.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        nob.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        nob.release();
        creep.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        creep.release();
        sideOut.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        sideOut.release();
        scary.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        scary.release();
    }
    public void VanishForest()
    {
        act2.SetActive(true);
        farmer.SetActive(false);
        terrain.treeDistance = 0f;
    }
}
