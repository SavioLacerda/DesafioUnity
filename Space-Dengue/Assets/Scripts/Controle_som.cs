using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle_som : MonoBehaviour {

    float volume;

    public void VOLUME(float volume_original)
    {
        volume = volume_original;
        AudioListener.volume = volume;
    }
 
}
