using UnityEngine;

public class cientificomalo : MonoBehaviour
{
    [Header("Configuración Movimiento")]
    public float velocidad = 2f;
    public float distanciaDeteccion = 5f;
    public float distanciaMinima = 2f; // Si el pingüino baja de aquí, el científico retrocede
    public LayerMask capaJugador;

    [Header("Ataque")]
    public GameObject prefabPocion;
    public Transform puntoDisparo;
    public float tiempoEntreAtaques = 1.5f;
    private float cronometroAtaque;

    private Rigidbody2D rb;
    private Animator anim;
    private bool mirandoDerecha = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    void Update() {
        Vector2 dir = mirandoDerecha ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, distanciaDeteccion, capaJugador);
        Debug.DrawRay(transform.position, dir * distanciaDeteccion, Color.red);

        if (hit.collider != null) {
            float distanciaActual = Vector2.Distance(transform.position, hit.transform.position);
            
            // LÓGICA INTELIGENTE:
            if (distanciaActual < distanciaMinima) {
                // Retroceder si está muy cerca
                Retroceder();
            } else {
                // Quedarse quieto y atacar si está a buena distancia
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }
            
            Atacar(distanciaActual);
        } else {
            Patrullar();
        }
    }

    void Retroceder() {
        // Se mueve en dirección contraria a donde mira
        float direccionRetroceso = mirandoDerecha ? -1 : 1;
        rb.linearVelocity = new Vector2(direccionRetroceso * (velocidad * 0.8f), rb.linearVelocity.y);
        anim.SetBool("estoyAtacando", true); // Sigue en pose de ataque aunque retroceda
    }

    void Atacar(float distancia) {
        anim.SetBool("estoyAtacando", true);
        cronometroAtaque += Time.deltaTime;

        if (cronometroAtaque >= tiempoEntreAtaques) {
            DispararDinamico(distancia);
            cronometroAtaque = 0;
        }
    }

    void DispararDinamico(float distanciaAlObjetivo) {
    if (prefabPocion != null) {
        // 1. CALCULAMOS LA POSICIÓN EN TIEMPO REAL
        // En lugar de un objeto hijo, usamos la posición del científico + un pequeño avance
        float avanceX = mirandoDerecha ? 0.7f : -0.7f; 
        Vector3 spawnPos = new Vector3(transform.position.x + avanceX, transform.position.y + 0.8f, 0f);

        // 2. CREAMOS LA POCIÓN DESDE EL PREFAB DE ASSETS
        GameObject obj = Instantiate(prefabPocion, spawnPos, Quaternion.identity);
        
        // 3. LE DAMOS FUERZA SEGÚN LA DISTANCIA
        Rigidbody2D rbP = obj.GetComponent<Rigidbody2D>();
        if (rbP != null) {
            rbP.linearVelocity = Vector2.zero;
            // Fuerza proporcional: a más distancia, más fuerte el tiro
            float fuerzaX = mirandoDerecha ? (distanciaAlObjetivo * 1.6f) : (-distanciaAlObjetivo * 1.6f);
            float fuerzaY = 4.5f; // Un arco un poco más alto para que no sea tan recto
            
            rbP.AddForce(new Vector2(fuerzaX, fuerzaY), ForceMode2D.Impulse);
        }
    }
}

    void Patrullar() {
        anim.SetBool("estoyAtacando", false);
        rb.linearVelocity = new Vector2((mirandoDerecha ? 1 : -1) * velocidad, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!collision.gameObject.CompareTag("Player")) {
            Girar();
        }
    }

    void Girar() {
        mirandoDerecha = !mirandoDerecha;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}