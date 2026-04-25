using FMODUnity;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class gameEvents : MonoBehaviour
{
    public EventReference ambience;
    public collectibleCount count;
    public FPSController player;
    private int pop1;
    private bool apples;
    public TMPro.TMP_Text text;
    private void Awake()
    {
        RuntimeManager.PlayOneShot(ambience);
        pop1 = playerData.instance.pop;
        text.text = $"TALK TO FARMER MAULDER";
        apples = true;
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
        
    }
}
