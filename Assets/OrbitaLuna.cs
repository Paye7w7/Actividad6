using UnityEngine;

public class OrbitaLunar : MonoBehaviour
{
    public Transform tierra; // Referencia a la Tierra
    public float velocidadRotacion = 50f; // Velocidad de rotación de la Luna alrededor de la Tierra
    private bool rotando = false; // Para saber si la Luna está rotando alrededor de la Tierra

    public float velocidadEscala = 0.1f; // Velocidad de cambio de tamaño
    private Vector3 escalaTierra; // Escala de la Tierra
    private Vector3 escalaLuna; // Escala de la Luna

    public float velocidadRotacionTierra = 20f; // Velocidad de rotación de la Tierra sobre su propio eje
    private bool girandoTierra = false; // Control para saber si la Tierra está girando sobre su eje

    void Start()
    {
        // Al comenzar, guarda las escalas iniciales de la Tierra y la Luna
        escalaTierra = tierra.localScale;
        escalaLuna = transform.localScale;
    }

    void Update()
    {
        // Control para alternar entre iniciar y detener la rotación de la Luna
        if (Input.GetKeyDown(KeyCode.R))
        {
            rotando = !rotando; // Alterna entre iniciar y detener la rotación de la Luna
        }

        // Rotación de la Luna alrededor de la Tierra
        if (rotando)
        {
            transform.RotateAround(tierra.position, Vector3.up, velocidadRotacion * Time.deltaTime);
        }

        // Cambio de tamaño con las teclas Q (aumentar) y W (disminuir)
        if (Input.GetKey(KeyCode.Q))
        {
            // Aumenta el tamaño de la Luna y la Tierra
            transform.localScale += Vector3.one * velocidadEscala * Time.deltaTime;
            tierra.localScale += Vector3.one * velocidadEscala * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            // Disminuye el tamaño de la Luna y la Tierra
            transform.localScale -= Vector3.one * velocidadEscala * Time.deltaTime;
            tierra.localScale -= Vector3.one * velocidadEscala * Time.deltaTime;

            // Asegura que el tamaño no se vuelva negativo (opcional)
            if (transform.localScale.x < 0.1f) transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            if (tierra.localScale.x < 0.1f) tierra.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

        // Rotación de la Tierra sobre su propio eje con la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Cambia el estado de la rotación de la Tierra cuando se presiona la tecla E
            girandoTierra = !girandoTierra;
        }

        // Si la Tierra debe girar, rota sobre su propio eje
        if (girandoTierra)
        {
            tierra.Rotate(Vector3.up * velocidadRotacionTierra * Time.deltaTime);
        }
    }
}
