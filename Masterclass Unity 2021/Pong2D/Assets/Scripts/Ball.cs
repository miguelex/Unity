using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float _speed = 30f;

    private TrailRenderer _trailRenderer;
    private Rigidbody2D _rigidbody2D;
    private GameManager _gameManager;
    private AudioManager _audioManager;
    private sbyte _nextDirection;

    // Start is called before the first frame update
    void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _audioManager = FindObjectOfType<AudioManager>();
        _gameManager = FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Launch()
    {
        // Habilitar rastro de la pelota
        _trailRenderer.emitting = true;
        _trailRenderer.time = 0.2f;

        if (!_gameManager.StartGamePlay)
        {
            Debug.Log("Empezando la partida por primera vez");
            _gameManager.StartGamePlay = true;
            _gameManager.FinishMatch = false;
            _gameManager.ChangeScoreBoard();

            // Determinar la direccion inicial de manera aleatoria
            float randomValue = Random.Range(0f, 1f);

            // Especificar la direccion
            _nextDirection = (sbyte)((randomValue <= 0.5f) ? 1 : -1);
        }
        _rigidbody2D.velocity =
            new Vector2 (_nextDirection, 0) * _speed;
    }

    public void Reset(sbyte nextDirection)
    {
        // Paramos la pelota completamente
        _rigidbody2D.velocity = Vector2.zero;
        //Deshabilitat rastro de la pelota
        _trailRenderer.emitting = false;
        _trailRenderer.time = 0f;

        // Mover pelota al punto central
        _rigidbody2D.transform.position = new Vector2(0, 0);

        // Especificamos la direccion
        _nextDirection = nextDirection;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _audioManager.Play(Sounds.RACKET);
        /*
         collision: Informacion del elemento cone le que colisiona.
         Por ejjemplo la raqueta, pared,...
         collision.gameObject = Elelemnto con el que chocamos
         collision.gameObject.tag = Tag del elelemnto con el que cochamos
         colission.gameObject.name = NOmbre del elemento con el que chocamos
         Para la pelota hacemos uso del gameObject
         */

        if(collision.gameObject.tag == "Racket")
        {
            // Obtenemos el valor del facotr de impacto vertical
            float y = HitVerticalFactor(gameObject.transform.position.y,
            collision.gameObject.transform.position.y,
            collision.collider.bounds.size.y);

            // Obtener la direccion horizontal dependiendo en que raqueta impacte
            float x = (collision.gameObject.name == "Left") ? 1 : -1;

            Vector2 direction = new Vector2(x, y).normalized;

            _rigidbody2D.velocity = direction * _speed;
        }
        else
        {
            Debug.Log("Choca en otro lado");
        }

        if (collision.gameObject.tag == "Wall")
        {
            _audioManager.Play(Sounds.WALL);
        }
 
    }

    float HitVerticalFactor(float ballPosition, float racketPosition, float racketHeight)
    {
        return (ballPosition - racketPosition) / racketHeight;
    }
}
