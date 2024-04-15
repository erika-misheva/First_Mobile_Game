
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(Rigidbody2D))] // se pishuva nad klasata (ako ovaa skripta se stavi na objekt sto nema rigid bodi, ovaa liija kod mu dodava rigid body)
public class BirdController : MonoBehaviour
{

     private Rigidbody2D rb;
     [SerializeField] private float jumpSpeed;

    public UnityEvent OnHit;
    public UnityEvent OnPoint;
    public UnityEvent OnJump;

    private int currentPoints;
    private int highScorePoints;



    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private TextMeshProUGUI currentPointsText; 
    [SerializeField] private TextMeshProUGUI highscoreText;
    //dozvoluva varijablata da si ostane private samo da moze da ja modificirame od inspectorot
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Time.timeScale = 1;

        currentPoints = 0;

        highScorePoints = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetJumpInput())
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        Time.timeScale = 0; // gi pauzira site fiziki vo igrata

        if (gameOverScreen)
        {
            gameOverScreen.SetActive(true);
        }  
        OnHit?.Invoke();     
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentPoints++;

        currentPointsText.text = currentPoints.ToString();

        OnPoint?.Invoke();

        if(highScorePoints <= currentPoints)
        {
             PlayerPrefs.SetInt("Highscore", currentPoints);
            highScorePoints = currentPoints;
        }
        highscoreText.text = highScorePoints.ToString();

    }

    private bool GetJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Jump()
    {
        Vector2 jumpDirection = new Vector2(0, 1);
        Vector2 jumpVector = jumpDirection * jumpSpeed;

        rb.velocity = Vector2.zero;


        rb.AddForce(jumpVector, ForceMode2D.Impulse);

        OnJump?.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
} 

