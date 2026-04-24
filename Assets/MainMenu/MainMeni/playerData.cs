using UnityEngine;

public class playerData : MonoBehaviour
{
    public static playerData instance;
    public int pop;
    void Awake()
    {
        instance = this;
        pop = 1;
    }
    public void changePop(int newpop)
    {
        pop = newpop;
    }
}
