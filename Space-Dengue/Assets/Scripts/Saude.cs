using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saude : MonoBehaviour {

    public int saude = 1;
    
  
    public void Dano(int dano)
    {
        saude = saude - 1;
        
        if (saude <= 0)
        {
            Destroy(gameObject);
            
        }
    }
		
	}

