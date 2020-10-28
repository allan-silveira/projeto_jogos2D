using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlataforma : MonoBehaviour
{
    private float cont = 0;
    public float velocidade = 3;
    private Vector2 posInicial;
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cont += velocidade * Time.deltaTime;

        float posX = Mathf.Cos(cont);
        float posY = Mathf.Sin(cont);

        Vector2 posAtual = new Vector2(posX, posY);

        transform.position = posInicial + posAtual;

        if (cont >= 2 * Mathf.PI)
            cont = 2 * Mathf.PI - cont;
    }
}
