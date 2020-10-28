using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scriptPC : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rbd;
    private Animator anim;
    private AudioSource som;
    public float velocidade = 5;
    public float pulo = 250;
    private bool chao = true;
    private bool direita = true;
    public LayerMask mascara;
    public LayerMask mascara_chef;
    public int cont;

    void Start()
    {
        som = GetComponent<AudioSource>();
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        chao = true;
        anim.SetBool("pulo", false);
        som.Stop();
        transform.parent = collision.transform;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        chao = false;
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x == 0)
        {
            anim.SetBool("parado", true);
        }
        else
        {
            anim.SetBool("parado", false);

        }


        if (direita && x < 0 || !direita && x > 0) {
            direita = !direita;
            transform.Rotate(new Vector2(0, 180));
        }


        float velY;
        if (chao)
            velY = 0;
        else
            velY = rbd.velocity.y;

        rbd.velocity = new Vector2(x * velocidade, velY);

        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            som.Play();
            chao = false;
            anim.SetBool("pulo", true);
            rbd.AddForce(new Vector2(0, pulo));
        }

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, -transform.up, 0.7f, mascara);
        if (hit.collider != null)
            Destroy(hit.collider.gameObject);

        RaycastHit2D hit_2;
        hit_2 = Physics2D.Raycast(transform.position, -transform.up, 0.7f, mascara_chef);
        if (hit_2.collider != null)
        {
            cont++;
            rbd.AddForce(new Vector2(-3, pulo));
        }
        if (cont == 5)
        { 
            Destroy(hit_2.collider.gameObject);
            SceneManager.LoadScene(2);
        }
    }
}
