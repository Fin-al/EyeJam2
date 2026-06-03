using UnityEngine;

public class rollbacks : MonoBehaviour
{
    public GameObject tree, newLoc;
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
                if (tree != null)
                {
                    tree.transform.position = newLoc.transform.position;
                    Debug.Log("bro");
                }
                 
            }
            else
            {
                other.transform.position += new Vector3(10f, 0, 0);
            }

            Destroy(gameObject, 0.1f);
        }
    }
}