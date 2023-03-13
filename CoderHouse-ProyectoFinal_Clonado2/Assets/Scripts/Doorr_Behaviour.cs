using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorr_Behaviour : MonoBehaviour
{

    public GameObject puerta_Oficina_Cerrada;
    public GameObject puerta_Oficina_Abierta;
    public GameObject puerta_Comedor1_Cerrada;
    public GameObject puerta_Comedor1_Abierta;
    public GameObject puerta_Comedor2_Cerrada;
    public GameObject puerta_Comedor2_Abierta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Abrir_Puertas_Y_Cerrar_Puertas()
    {
        puerta_Oficina_Cerrada.SetActive(false);
        puerta_Oficina_Abierta.SetActive(true);
        puerta_Comedor1_Abierta.SetActive(true);
        puerta_Comedor1_Cerrada.SetActive(false);
        puerta_Comedor2_Abierta.SetActive(true);
        puerta_Comedor2_Cerrada.SetActive(false);
    }
}
