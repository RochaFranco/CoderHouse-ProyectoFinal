using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastPlayerr : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerToCollide;
    [SerializeField] private PlayerBehaviour Player;
    [SerializeField] private GameObject llave_Oficina;
    [SerializeField] private GameObject llave_Salida;
    [SerializeField] private GameObject llave_Almacen;
    [SerializeField] private GameObject llave_Secreta;
    [SerializeField] private Doorr_Behaviour controladorDePuertas;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemySleep;
    [SerializeField] private GameObject candado_naranja;
    [SerializeField] private GameObject candado_rojo;
    [SerializeField] private GameObject candado_azul;
    [SerializeField] private GameObject candado_verde;
    [SerializeField] private Text texto;
    [SerializeField] private AudioSource key_Sound;
    [SerializeField] private AudioSource lock_Sound;
    [SerializeField] private GameObject final;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }

    public void Raycast()
    {
        RaycastHit hit;
        //Ray ray;

        Debug.DrawRay(transform.position,transform.forward * maxDistance,Color.white);

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerToCollide))
        {

            if (hit.transform.name != "Llave_Almacen" && hit.transform.name != "Llave_Salida" && hit.transform.name != "Llave_Oficina" && hit.transform.name != "Llave_Habitacion_Secreta" && hit.transform.name != "Candado_Verde" && hit.transform.name != "Candado_Rojo" && hit.transform.name != "Candado_Azul" && hit.transform.name != "Candado_Naranja" && hit.transform.name != "Nota_2")
            {
                StartCoroutine(timer());
            }

            if (hit.transform.name == "Llave_Almacen")
            {
                texto.text = "Presiona E para agarrar llave azul";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    key_Sound.Play();
                    texto.text = "Agarraste llave azul";
                    StartCoroutine(timer());
                    Player.llave_Almacen = true;
                    Destroy(llave_Almacen);
                }
                

            }

            if (hit.transform.name == "Nota_1")
            {
                texto.text = "Para escapar de la clinica tenes que buscar las llaves para poder abrir la puerta. Los letreros de ''exit'' te guian a la salida.";
            }

            if (hit.transform.name == "Nota_2")
            {
                texto.text = "La llave naranja se encuentra en donde duerme el enemigo. La llave Azul se encuentra donde se cocina. La llave verde esta oculta en un lugar donde no se puede ver. * Las luces te pueden ayudar a encontrar las llaves.*";
            }

            if (hit.transform.name == "Llave_Salida")
            {
                texto.text = "Presiona E para agarrar llave Roja";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    key_Sound.Play();
                    texto.text = "Agarraste llave Roja";  
                    Player.llave_Saluda = true;
                    Destroy(llave_Salida);
                    controladorDePuertas.Abrir_Puertas_Y_Cerrar_Puertas();
                    enemy.SetActive(true);
                    enemySleep.SetActive(false);
                }
            }

            if (hit.transform.name == "Llave_Oficina")
            {
                texto.text = "Presiona E para agarrar llave naranja";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    key_Sound.Play();
                    texto.text = "Agarraste llave naranja";
                    Player.llave_Oficina = true;
                    Destroy(llave_Oficina);
                }
            }

            if (hit.transform.name == "Llave_Habitacion_Secreta")
            {
                texto.text = "Presiona E para agarrar llave verde";

                if (hit.transform.name != "Llave_Habitacion_Secreta")
                {
                    texto.text = "";
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    key_Sound.Play();
                    texto.text = "Agarraste llave verde";  
                    Player.llave_Secreta = true;
                    Destroy(llave_Secreta);
                    StartCoroutine(timer());
                }

            }

            if (hit.transform.name == "Candado_Rojo")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Player.llave_Saluda == true)
                    {
                        lock_Sound.Play();
                        Destroy(candado_rojo);
                    }
                    else if(Player.llave_Saluda != true)
                    {
                        texto.text = "Se necesita la llave roja!";
                        
                    }
                }
            }

            if (hit.transform.name == "Candado_Azul")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Player.llave_Almacen == true)
                    {
                        lock_Sound.Play();
                        Destroy(candado_azul);
                    }
                    else if (Player.llave_Almacen != true)
                    {
                        texto.text = "Se necesita la llave azul!";
                    }
                }
            }

            if (hit.transform.name == "Candado_Naranja")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Player.llave_Oficina == true)
                    {
                        lock_Sound.Play();
                        Destroy(candado_naranja);
                    }
                    else if (Player.llave_Oficina != true)
                    {
                        texto.text = "Se necesita la llave naranja!";
                    }
                }
            }

            if (hit.transform.name == "Candado_Verde")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Player.llave_Secreta == true)
                    {
                        lock_Sound.Play();
                        Destroy(candado_verde);
                    }
                    else if (Player.llave_Secreta != true)
                    {
                        texto.text = "Se necesita la llave verde!";
                    }
                }
            }

            if (candado_azul == null && candado_naranja == null && candado_rojo == null && candado_verde == null)
            {
                final.SetActive(true);
            }

        }

    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1);
        texto.text = "";
    }

}
