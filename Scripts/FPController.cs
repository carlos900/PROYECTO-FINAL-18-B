using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class FPController : MonoBehaviour {

    public float speed = 5f;
    private Transform cam;
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private float mouseSensitivity = 250f;
    private float verticalLookRotation;

    public int count;
    public Text countText;
    public Text winText;

    public Text enemyText;
    static int enemyCount;

    private bool gano;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        count = 0;
        enemyCount = 0;
        SetCountText();
        winText.text = "";
        gano = false;
	}
	
	// Update is called once per frame
	void Update () {
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");
        float zMov = Input.GetAxisRaw("Jump");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * yMov;
        Vector3 movUp = transform.up * zMov;
        velocity = (movHorizontal + movVertical + movUp).normalized * speed;

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cam.localEulerAngles = Vector3.left * verticalLookRotation;
        enemyText.text = "Monstruos Eliminados: " + enemyCount.ToString();

        if (count >= 13 && enemyCount >= 5 && !gano)
        {
            gano = true;
            winText.text = "Felicidades Completaste el Nivel!! \nAlumno: Carlos Blanco \ndSimulación por Computadora \n";
            SoundManagerController.PlaySound("win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void FixedUpdate()
    {
        if(velocity != Vector3.zero){
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up")){
            SoundManagerController.PlaySound("ping");
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Pieces"))
        {
            other.gameObject.SetActive(false);
        }
    }

    void SetCountText(){
        countText.text = "Libros Encontrados: " + count.ToString();
    }

    public static void IncrementaEnemyCount(){
        enemyCount++;
    }

}
