using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameManager _gameManager;
    private AudioManager _audioManager;

    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        _audioManager.Play(Sounds.GOAL);
        sbyte nextDirection = 0;
        byte[] scoreBoard = _gameManager.ScoreBoard;

        if (gameObject.name == "Left")
        {
            Debug.Log("Izquierda recibe gol. Derecha marca gol");
            scoreBoard[1] += 1;
            nextDirection = 1;
        }
        else
        {
            Debug.Log("Derecha recibe gol. Izquierda marca gol");
            scoreBoard[0] += 1;
            nextDirection = -1;
        }
        _gameManager.ScoreBoard = scoreBoard;
        _gameManager.ResetBallPosition(nextDirection);
        if (!_gameManager.FinishMatch)
        {
            _gameManager.ChangeScoreBoard();
        }
    }
}
