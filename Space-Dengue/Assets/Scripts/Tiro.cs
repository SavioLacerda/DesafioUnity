using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    int dano = 1,a;
    public string Dengue1, Dengue2, Dengue3;
    private Renderer visionGetting;
    Scoreponto ponto = new Scoreponto();

    

    void Awake()
    {
        visionGetting = GetComponent<Renderer>();

    }

    void Update()
    {
        if (!visionGetting.Visivel(Camera.main)) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == Dengue1 || collision.gameObject.tag == Dengue2 || collision.gameObject.tag == Dengue3)
        {
            Saude vida = collision.gameObject.GetComponent<Saude>();
            vida.Dano(dano);
            a=ponto.AddScore(1);
        }

        if (collision.gameObject.tag == Dengue1 || collision.gameObject.tag == Dengue2 || collision.gameObject.tag == Dengue3)
        {
            Destroy(gameObject);            
        }

        
    }

}
