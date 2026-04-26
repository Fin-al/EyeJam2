using UnityEngine;

public class playerData : MonoBehaviour
{
    public static playerData instance;
    public int pop;
    void Awake()
    {
       
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        pop = PlayerPrefs.GetInt("SavedPops", 1);
        Debug.Log("Total Pops is : " + pop);
    }
    public void changePop(int amount)
    {
        
        pop = amount;
 
        PlayerPrefs.SetInt("SavedPops", pop);
        PlayerPrefs.Save();

        Debug.Log("Total Pops is now: " + pop);
    }
}
