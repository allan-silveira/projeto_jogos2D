using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptInimigo : MonoBehaviour
{
    public float velocidade = 2;
    private Rigidbody2D rbd;
    public LayerMask mascara;
    public LayerMask mascara_pc;
    public float distancia = 0.7f;
    private AudioSource som;
    // Start is called before the first frame update
    void Start()
    {
        som = GetComponent<AudioSource>();
        rbd = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rbd.velocity = new Vector2(velocidade, 0);

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, transform.right, distancia, mascara);
        if(hit.collider != null)
        {
            velocidade = velocidade * -1;
            rbd.velocity = new Vector2(velocidade, 0);
            transform.Rotate(new Vector2(0, 180));
        }
        RaycastHit2D hit_pc;
        hit_pc = Physics2D.Raycast(transform.position, transform.right, distancia, mascara_pc);
        if (hit_pc.collider != null)
        {
            som.Play();
            Destroy(hit_pc.collider.gameObject);
            SceneManager.LoadScene(0);
        }
        RaycastHit2D hit2;
        hit = Physics2D.Raycast(transform.position, transform.up, 0.9f, mascara);
        if (hit.collider != null)
            som.Play();
    }
}
