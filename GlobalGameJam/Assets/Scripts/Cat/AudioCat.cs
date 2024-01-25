using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioCat
{ 
    public AudioClip walk,jump,grinch;
    public AudioClip JumpOnArmChair, presleep , sleep, cassegueule;
    public AudioClip enervax , fallmug;

    public void PlayAudio(AudioSource source)
    {
        source.Play();
    }
}
