using UnityEngine;

public class sensoring : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target != null)
        {

            transform.LookAt(target);

        }
    }
}
