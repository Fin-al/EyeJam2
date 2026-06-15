using UnityEngine;

public class farmerLooking : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target != null && playerData.instance.pop !=1)
        {
             
            transform.LookAt(target);

        }
    }
}


