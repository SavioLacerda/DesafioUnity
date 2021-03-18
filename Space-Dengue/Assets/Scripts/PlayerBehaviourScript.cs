using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour {

    public Vector2 velocidade = new Vector2(35,0);
    private Vector2 move;
    public string Dengue;
    private int dano = 1, recorde;
    Scoreponto consulta= new Scoreponto();
    public TextMesh potuaçaomax;
    private void Start()
    {
        Time.timeScale = 1;
        Camera.main.GetComponent<AudioSource>().UnPause();
    }

    void Update () {


        // float entradaX = Input.GetAxis("Horizontal");
        float entradaX = Input.acceleration.x;
        move = new Vector2(entradaX * velocidade.x, 0 * velocidade.y);

        recorde = consulta.AddScore(2);
        if (recorde > PlayerPrefs.GetInt("record1"))
        {
            PlayerPrefs.SetInt("record1", recorde);
        }
        potuaçaomax.text = "Recorde:" + PlayerPrefs.GetInt("record1").ToString();
        if (recorde > 20)
        {
            transform.parent.gameObject.AddComponent<MudançadeFase>();
        }


        if (Input.GetButton("Fire1"))
        {
            Lançamento2 missil = GetComponent<Lançamento2>();
            if(missil!= null)
            {
                missil.ataque();
                Sons.Instance.FazertiroSOM();
            }
        }
        var distanciaz = (transform.position - Camera.main.transform.position).z;
        var bordadireita = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanciaz)).x;
        var bordaesquerda = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanciaz)).x;
        var bordacima = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanciaz)).y;
        var bordabaixo = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanciaz)).y;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bordaesquerda, bordadireita), Mathf.Clamp(transform.position.y, bordabaixo, bordacima), transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Dengue)
        {
            Saude vida = collision.gameObject.GetComponent<Saude>();
            vida.Dano(dano);            
        }

        
        if (collision.gameObject.tag == Dengue)
        {
            
            Destroy(gameObject);
        }

    }
    void OnDestroy()
    {
        transform.parent.gameObject.AddComponent<GameOver>();
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = move;
    }
}