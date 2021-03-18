using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovInimigo2 : MonoBehaviour {

    private Vector2 velocidade = new Vector2(1, 0);
    private Vector2 move;
    private Transform espaçonave_posicao;
    private float Duracao = 1.5f;
    private bool troca_sinal  = true;
    float Deslocamento;

    void Start()
    {
        InvokeRepeating("Aleatorio", Duracao, Duracao);
        InvokeRepeating("Gerar_filhos", Duracao, Duracao);
        espaçonave_posicao = GameObject.FindGameObjectWithTag("Espaconave").transform;

    }

    private void Gerar_filhos()
    {
        
            Lançamento missil = GetComponent<Lançamento>();
            if (missil != null)
            {
                missil.ataque();
            }
        
    }

    private void Aleatorio()
    {
        if (espaçonave_posicao != null) { 
        move = new Vector2(espaçonave_posicao.position.x * velocidade.x, 0 * velocidade.y);
        Deslocamento = espaçonave_posicao.position.x;
        if (troca_sinal)
        {
            GetComponent<Rigidbody2D>().velocity = move * (-0.5f);
            troca_sinal = false;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = move * (0.5f);
            troca_sinal = true;
        }

        }
    }


    void Update()
    {
        var distanciaz = (transform.position - Camera.main.transform.position).z;
        var bordadireita = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanciaz)).x;
        var bordaesquerda = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanciaz)).x;
        var bordacima = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanciaz)).y;
        var bordabaixo = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanciaz)).y;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bordaesquerda, bordadireita), Mathf.Clamp(transform.position.y, bordabaixo, bordacima), transform.position.z);
    }

}
