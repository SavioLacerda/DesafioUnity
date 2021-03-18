using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCampo : MonoBehaviour {

    private Vector2 velocidade = new Vector2(15, 0);
    private Vector2 move;
    public string Dengue1, Dengue2;
    public int dano = 1;
    private bool Ativo=false;
    public Transform Campo;
    private float duracao1 = 7.0f;
    private float duracao2 = 7.0f;
    private Transform espaçonave_posicao;
    private bool posicaoJogador = false;
    private bool destruir = false;

    void Start()
    {
        InvokeRepeating("Destruir", duracao2, duracao2);
        InvokeRepeating("Aleatorio", duracao1, duracao1);
        
        espaçonave_posicao = GameObject.FindGameObjectWithTag("Espaconave").transform;

    }

    private void Aleatorio()
    {
        Vector2 posicaoAleatoria;

        if (espaçonave_posicao != null)
        {

            posicaoAleatoria = new Vector2(espaçonave_posicao.position.x, espaçonave_posicao.position.y);
            var posicaoInimigo = Instantiate(Campo) as Transform;
            posicaoInimigo.position = posicaoAleatoria;
            destruir = true;
            Ativo = true;
        }
    }

    private void Destruir()
    {
        if (destruir)
        {
            Destroy(gameObject);
            destruir = false;
        }        
    }


    void Update()
    {

        if (Ativo)
        {
            float entradaX = Input.GetAxis("Horizontal");
            //float entradaY = Input.GetAxis("Vertical");
            //float entradaX = Input.acceleration.x;
            // float entradaY = Input.acceleration.y;
            move = new Vector2(entradaX * velocidade.x, 0 * velocidade.y);


            var distanciaz = (transform.position - Camera.main.transform.position).z;
            var bordadireita = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanciaz)).x;
            var bordaesquerda = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanciaz)).x;
            var bordacima = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanciaz)).y;
            var bordabaixo = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanciaz)).y;

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bordaesquerda, bordadireita), Mathf.Clamp(transform.position.y, bordabaixo, bordacima), transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Ativo)
        {
            if (collision.gameObject.tag == Dengue1 || collision.gameObject.tag == Dengue2)
            {
                Saude vida = collision.gameObject.GetComponent<Saude>();
                vida.Dano(dano);
            }


            if (collision.gameObject.tag == Dengue1 || collision.gameObject.tag == Dengue2)
            {
                Destroy(gameObject);
            }
        }
    }
   
    void FixedUpdate()
    {
        if (Ativo)
        {
            GetComponent<Rigidbody2D>().velocity = move;
    } }
}

