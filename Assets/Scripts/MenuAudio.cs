using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour {
    public List<AudioClip> audioClips;
    public void play(int audioNumber){
        GetComponent<AudioSource>().PlayOneShot(audioClips[audioNumber]);
    }
}
