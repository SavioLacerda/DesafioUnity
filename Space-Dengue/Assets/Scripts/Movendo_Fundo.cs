using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Movendo_Fundo : MonoBehaviour {

    public float speed=1;
    private Material matAtual;
    private float Offset;

      void Start()
    {
        matAtual =  GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            Offset = Offset + 0.001f;
            matAtual.SetTextureOffset("_MainTex", new Vector2(0, Offset * speed));
        }
    }

    
}
