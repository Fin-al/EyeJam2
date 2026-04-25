using UnityEngine;
using FMODUnity;

public class WheatSound : MonoBehaviour
{
    public void PlayWheatSound(EventReference sound)
    {
        if (!sound.IsNull)
        {
            RuntimeManager.PlayOneShotAttached(sound, this.gameObject);
        }
    }
}