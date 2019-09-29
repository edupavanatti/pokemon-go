using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checarBola : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pokemon")
        {
            StartCoroutine("capturarPokemon", other.gameObject);
        }
    }

    IEnumerator capturarPokemon(GameObject Pokemon)
    {
        transform.Translate(Vector3.up * 1, Space.World);
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(Pokemon.gameObject);
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("Player").transform.LookAt(this.transform);
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Camera>().fieldOfView = 10f;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
