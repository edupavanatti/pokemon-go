using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arremessarBola : MonoBehaviour
{
    bool arremessando = false;
    float distancia = 0f;
    public float velocidade = 10f;
    public float velocidadeArremesso = 4f;
    public float velocidadeBola = 4f;

    void OnMouseDown()
    {
        distancia = Vector3.Distance(transform.position, Camera.main.transform.position);
        arremessando = true;
    }

    public void OnMouseUp()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().velocity += this.transform.forward * velocidadeArremesso;
        this.GetComponent<Rigidbody>().velocity += this.transform.up * velocidadeBola;
        arremessando = false;
    }

    void Update()
    {
        if(arremessando)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distancia);
            transform.position = Vector3.Lerp(this.transform.position, rayPoint, velocidade * Time.deltaTime);
        }
    }
}
