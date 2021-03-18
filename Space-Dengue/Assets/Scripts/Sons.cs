using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sons : MonoBehaviour {
    public static Sons Instance;
    public AudioClip tiroSom;
   
    private void Awake()
    {
        Instance = this;
    }
    public void MakeSound(AudioClip original)
    {
        AudioSource.PlayClipAtPoint(original,transform.position);
    }

    public void FazertiroSOM()
    {
        MakeSound(tiroSom);
    }

	
}
