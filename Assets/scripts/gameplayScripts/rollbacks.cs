using UnityEngine;

public class rollbacks : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController cc = other.GetComponent<CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
                other.transform.position += new Vector3(10f, 0, 0);
                cc.enabled = true;
            }
            else
            {
                other.transform.position += new Vector3(10f, 0, 0);
            }

            Destroy(gameObject, 0.1f);
        }
    }
}