# Delegados y Eventos.

 -Autor: Gabriel Melián Hernández.

Descripción de la Práctica: 

-Crear un escenario básico para la escena del proyecto para la evaluación final.
-Agregar dos tipos de GameObject de los que haya varias instancias en la escena.
-Implementar un controlador de escena usando el patrón delegado que gestione las siguientes acciones:
  Si el jugador choca con un objeto de tipo A se incrementa su poder.
  Si el jugador choca con objetos de tipo B, todos los de ese tipo sufrirán alguna transformación o algún cambio en su apariencia y decrementarán el poder del jugador.
-Incorporar un elemento que sirva para encender o apagar un foco utilizando el teclado.

----------------------------------------------

Para la realización de esta práctica utilizaremos como personaje controlabre una esfera que se moverá con movimiento físico (tiene rigidbody).

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * 1f, ForceMode.Impulse);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * 1f, ForceMode.Impulse);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * 1f, ForceMode.Impulse);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * 1f, ForceMode.Impulse);
            
        }
        
Luego vamos a poner 4 instancias de dos tipos de objetos diferentes que activarán un evento diferente en su colisión, en este caso esos objetos serán Cilindros y Cubos. Comenzando por los Cilindros tendrán implementados en sí mismos un script para llamar a su evento (Incrementará un contador de Score, cada vez que se colisione con la Esfera principal):

    public class EventoCilindro : MonoBehaviour
    {
    public delegate void _OnIncreasePower(GameObject go);
    public static event _OnIncreasePower OnIncreasePower;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Esfera")
        {
            if (OnIncreasePower != null)
            {
                OnIncreasePower(gameObject);
            }
        }
    }
    }
    
La implementación de este evento se realizará en el objeto vacío GameController que llevará a cabo el control de todos los eventos de la escena.

    void OnEnable()
    {
        EventoCubo.OnChangeColor += ChangeColor;
        EventoCilindro.OnIncreasePower += IncreasePower;
        EventoFoco.OnLightOrNot += LightOrNot;
    }

    void OnDisable()
    {
        EventoCubo.OnChangeColor -= ChangeColor;
        EventoCilindro.OnIncreasePower -= IncreasePower;
        EventoFoco.OnLightOrNot += LightOrNot;
    }
  
Implementación del evento de los Cilindros:

    void IncreasePower(GameObject go)
    {
        score += 10;
        
    }
    
Por otra parte con los cubos haremos un proceso similar para llevar a cabo el control de su evento que en este caso será incrementar su tamaño y cambiar su color con cada colisión con la esfera. Añadiremos a cada uno de ellos el script de evento.

    public class EventoCubo : MonoBehaviour
    {
    public delegate void _OnChangeColor(GameObject go);
    public static event _OnChangeColor OnChangeColor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Esfera")
        {
            if(OnChangeColor != null)
            {
                OnChangeColor(gameObject);
            }
        }
    }
    }
    
Y en el GameController:

    void ChangeColor(GameObject go)
    {
        Cubo = GameObject.FindGameObjectsWithTag("Cubo");
        x += 0.5f;
        y += 0.5f;
        z += 0.5f;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Cubo").Length; i++)
        {
            Cubo[i].transform.localScale = new Vector3(x, y, z);
            var number = UnityEngine.Random.Range(0, 3);
            Cubo[i].GetComponent<Renderer>().material.color = colors[number];
        }
        score -= 1;
    }
    
Por último añadiremos un foco que controlaremos también por evento y que se apagará o encenderá dependiendo de la tecla que pulsemos en el teclado(con la L encenderemos le foco y con la N lo apagaremos).

    public class EventoFoco : MonoBehaviour
    {
 
    public delegate void _OnLightOrNot(GameObject go);
    public static event _OnLightOrNot OnLightOrNot;

    private void LightOrNot()
    {
            if (OnLightOrNot != null)
            {
                OnLightOrNot(gameObject);
            }
    }
    }
    
y en el GameController:

    void LightOrNot(GameObject go)
    {

        if (Input.GetKey(KeyCode.L))
        {
            Foco.SetActive(true);
            Debug.Log("Encendemos");
        }
        if (Input.GetKey(KeyCode.N))
        {
            Foco.SetActive(false);
            Debug.Log("Apagamos");
        }


    }
