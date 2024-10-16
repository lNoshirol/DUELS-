using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] Text countdownText;
    [SerializeField] GameObject countdown;
    public GameObject cube;
    [SerializeField] Sprite loseSprite;
    [SerializeField] GameObject winPic;

    private ReflexGameInput _reflexGameInput;

    private Renderer cubeRenderer;
    private MeshRenderer cubeMeshRenderer;

    private bool gamePlay;
    private bool waitTime;
    private bool cubeHide;

    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    [SerializeField] GameObject restartText;

    private Text winTextComponent;
    private Text loseTextComponent;
    private string loseTextCheck;
    private SpriteRenderer winPicSprite;

    private Text player1TextComponent;
    private Text player2TextComponent;

    string currentSceneName;
    float menuSceneName;

    [SerializeField] Text player1; 
    [SerializeField] Text player2;

    [SerializeField] Image spaceKeyImage;
    [SerializeField] Image enterKeyImage;
    [SerializeField] Sprite spaceKeyLoseSprite;
    [SerializeField] Sprite enterKeyLoseSprite;

    PlayerInput playerInput;
    InputAction player1Action;
    InputAction player2Action;
    InputAction restartAction;
    InputAction menuAction;

    [SerializeField] TimerScript timerScript;
    bool coroutine = true;

    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        loseText.SetActive(false);
        restartText.SetActive(false);

        currentSceneName = SceneManager.GetActiveScene().name;

        winTextComponent = winText.GetComponent<Text>();
        loseTextComponent = loseText.GetComponent<Text>();

        player1TextComponent = player1.GetComponent<Text>();
        player2TextComponent = player2.GetComponent<Text>();

        winPicSprite = winPic.GetComponent<SpriteRenderer>();

        gamePlay = true;
        waitTime = false;

        playerInput = GetComponent<PlayerInput>();
        player1Action = playerInput.actions.FindAction("Player1Action");
        player2Action = playerInput.actions.FindAction("Player2Action");

        restartAction = playerInput.actions.FindAction("RestartAction");
        menuAction = playerInput.actions.FindAction("MenuAction");

        loseTextComponent.text = "";


        cubeRenderer = cube.GetComponent<Renderer>();
        cubeMeshRenderer = cube.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        loseTextCheck = loseTextComponent.text;
        if (menuAction.WasPressedThisFrame())
            SceneManager.LoadScene("SampleScene");

        if (timerScript.countdownFinish && gamePlay)
        {
            if (coroutine)
            {
                StartCoroutine(Wait());
                coroutine = false;
            }
            
            if (player1Action.WasPressedThisFrame() && cubeHide)
            {
                Win("Player 1 Win");
                
            }

            else if (player2Action.WasPressedThisFrame() && cubeHide)
            {
                Win("Player 2 Win");
            }
        }

        else if (restartAction.WasPressedThisFrame() && cubeHide)
            SceneManager.LoadScene(currentSceneName);
        // Check if player is too fast
        if(waitTime)
        {
            if (player1Action.WasPressedThisFrame())
            {
                Lose("Player 1 is too fast");
            }
            else if (player2Action.WasPressedThisFrame())
            {
                Lose("Player 2 is too fast");
            }
        }
        // Everyone lost
        if (player1TextComponent.color == Color.red & player2TextComponent.color == Color.red)
        {
            winText.SetActive(true);
            winTextComponent.color = Color.red;
            winTextComponent.text = "Everyone lost";
            restartText.SetActive(true);
            countdown.SetActive(false);
            if (restartAction.WasPressedThisFrame())
            {
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }

    private void Win(string textPlayerWin)
    {
        gamePlay = false;
        winText.SetActive(true);
        winTextComponent.text = textPlayerWin;
        winTextComponent.color = Color.green;
        restartText.SetActive(true);
    }

    private void Lose(string texPlayerLoose)
    {
        if (texPlayerLoose == "Player 1 is too fast")
        {
            player1Action = playerInput.actions.FindAction("LoseAction");
            player1TextComponent.color = Color.red;
            spaceKeyImage.sprite = spaceKeyLoseSprite;
            KeyWait("player1");
        }
        else
        {
            player2Action = playerInput.actions.FindAction("LoseAction");
            player2TextComponent.color = Color.red;
            enterKeyImage.sprite = enterKeyLoseSprite;
            KeyWait("player2");
        }
        loseText.SetActive(true);
        // Check if loseText is empty
        if (string.IsNullOrWhiteSpace(loseTextCheck))
            loseTextComponent.text = texPlayerLoose;
        else
            loseTextComponent.text += " " + texPlayerLoose;
    }

    IEnumerator Wait()
    {
        countdownText.text = "Wait...";
        waitTime = true;
        yield return new WaitForSeconds(Random.Range(1, 10));
        waitTime = false;
        countdownText.text = "GO!";
        cube.SetActive(false);
        cubeHide = true;
    }

    IEnumerator KeyWait(string player)
    {
        yield return new WaitForSeconds(5);
        if(player == "player1")
        {
            player1Action = playerInput.actions.FindAction("Player1Action");
            player1TextComponent.color = Color.white;
        }
        else
        {
            player2Action = playerInput.actions.FindAction("Player2Action");
            player2TextComponent.color = Color.white;
        }
    }
}
