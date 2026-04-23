using UnityEngine;

public class gameEvents : MonoBehaviour
{
    public collectibleCount count;
    public FPSController player;
    private bool pop;
    private void Awake()
    {
        pop = false;
    }
    void Update()
    {
        if(count.getCount() == 7 && !pop)
        {
            crash();
        }
    }
    void crash()
    {
        player.enabled = false;
        PopUp.instance.ShowPopup();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        pop = true;
    }
}
