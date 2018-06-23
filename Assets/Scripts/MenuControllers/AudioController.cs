using UnityEngine.Audio;
using UnityEngine;

public class AudioController : MonoBehaviour {
   
	public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
