using UnityEngine;

public class OrbitaLunar : MonoBehaviour
{
    public Transform tierra; 
    public float velocidadRotacion = 50f; 
    private bool rotando = false; 

    public float velocidadEscala = 0.1f; 
    private Vector3 escalaTierra; 
    private Vector3 escalaLuna; 

    public float velocidadRotacionTierra = 20f; 
    private bool girandoTierra = false; 

    void Start()
    {
        
        escalaTierra = tierra.localScale;
        escalaLuna = transform.localScale;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            rotando = !rotando; 
        }

       
        if (rotando)
        {
            transform.RotateAround(tierra.position, Vector3.up, velocidadRotacion * Time.deltaTime);
        }

        
        if (Input.GetKey(KeyCode.Q))
        {
           
            transform.localScale += Vector3.one * velocidadEscala * Time.deltaTime;
            tierra.localScale += Vector3.one * velocidadEscala * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            
            transform.localScale -= Vector3.one * velocidadEscala * Time.deltaTime;
            tierra.localScale -= Vector3.one * velocidadEscala * Time.deltaTime;

            
            if (transform.localScale.x < 0.1f) transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            if (tierra.localScale.x < 0.1f) tierra.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            girandoTierra = !girandoTierra;
        }

        
        if (girandoTierra)
        {
            tierra.Rotate(Vector3.up * velocidadRotacionTierra * Time.deltaTime);
        }
    }
}
