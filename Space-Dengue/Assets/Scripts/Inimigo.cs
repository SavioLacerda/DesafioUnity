using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    private bool podeSerDestruido = false;
    private Collider2D collsionGetting;
    private Renderer visionGetting;
    ScoreMosquito mosquito = new ScoreMosquito();
    

    void Start()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    void Awake()
    {
        collsionGetting = GetComponent<Collider2D>();
        visionGetting = GetComponent<Renderer>();
    }

    void Update()
    {

        if (visionGetting.Visivel(Camera.main))
        {
            podeSerDestruido = true;
            collsionGetting.enabled = true;
        }

        if (!visionGetting.Visivel(Camera.main))
        {
            if (podeSerDestruido)
            {
                Destroy(gameObject);
                mosquito.AddScoreMosquito(1);
            }

        }
    }
}