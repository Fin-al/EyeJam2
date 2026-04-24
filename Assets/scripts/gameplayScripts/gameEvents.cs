using UnityEngine;

public class gameEvents : MonoBehaviour
{
    public collectibleCount count;
    public FPSController player;
    private int pop1;
    private void Awake()
    {
        pop1 = playerData.instance.pop;
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
                        
                        playerData.instance.pop = 2;
                    }
                    break;
                }
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
