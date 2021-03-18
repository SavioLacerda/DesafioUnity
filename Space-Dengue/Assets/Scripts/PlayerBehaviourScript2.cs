using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript2 : MonoBehaviour {

    private Vector2 velocidade = new Vector2(15, 0);
    private Vector2 move;
    public string Dengue1, Dengue2, Dengue3;
    private int dano = 1, recorde;
    Scoreponto consulta = new Scoreponto();
    public TextMesh potuaçaomax;



    void Update()
    {
        Time.timeScale = 1;
        Camera.main.GetComponent<AudioSource>().UnPause();

        //float entradaX = Input.GetAxis("Horizontal");
        //float entradaY = Input.GetAxis("Vertical");
        float entradaX = Input.acceleration.x;
        // float entradaY = Input.acceleration.y;
        move = new Vector2(entradaX * velocidade.x, 0 * velocidade.y);
        recorde = consulta.AddScore(2);
        if (recorde > PlayerPrefs.GetInt("record1"))
        {
            PlayerPrefs.SetInt("record1", recorde);
        }
        potuaçaomax.text = "Recorde:" + PlayerPrefs.GetInt("record1").ToString();



        if (Input.GetButton("Fire1"))
        {
            Lançamento missil = GetComponent<Lançamento>();
            if (missil != null)
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
        if (collision.gameObject.tag == Dengue1 || collision.gameObject.tag == Dengue2 || collision.gameObject.tag == Dengue3)
        {
            Saude vida = collision.gameObject.GetComponent<Saude>();
            vida.Dano(dano);


        }


        if (collision.gameObject.tag == Dengue1 || collision.gameObject.tag == Dengue2 || collision.gameObject.tag == Dengue3)
        {

            Destroy(gameObject);
        }

    }
    void OnDestroy()
    {
        transform.parent.gameObject.AddComponent<GameOver2>();
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = move;
    }
}
