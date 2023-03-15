using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject Screamer;
    [SerializeField] private GameObject screamerCamera;
    public bool llave_Oficina = false;
    public bool llave_Saluda = false;
    public bool llave_Almacen = false;
    public bool llave_Secreta = false;
    public float x, y;
    private Animator anim;
    private Rigidbody rb;


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        y = Input.GetAxisRaw("Horizontal");
        x = Input.GetAxisRaw("Vertical");

            Vector3 direction = (transform.forward * x + transform.right * y).normalized;

            rb.velocity = direction * movementSpeed;


        anim.SetFloat("varX",y);
        anim.SetFloat("varY",x);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            mainCamera.SetActive(false);
            Screamer.SetActive(true);
            screamerCamera.SetActive(true);
            StartCoroutine(timer()); ;
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(3);
    }

}
