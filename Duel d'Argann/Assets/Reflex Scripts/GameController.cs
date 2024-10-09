using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{

    [SerializeField] SpriteRenderer whiteRect;
    [SerializeField] Text countdownText;
    public GameObject cube;

    private ReflexGameInput _reflexGameInput;

    private Renderer cubeRenderer;

    private bool gamePlay;
    private bool waitTime;

    [SerializeField] GameObject WinText;
    [SerializeField] GameObject LoseText;
    private Text winTextComponent;
    private Text loseTextComponent;
    private string loseTextCheck;

    private Text player1TextComponent;
    private Text player2TextComponent;

    [SerializeField] Text player1;
    [SerializeField] Text player2;


    PlayerInput playerInput;
    InputAction player1Action;
    InputAction player2Action;



    [SerializeField] TimerScript timerScript;
    bool coroutine = true;

    // Start is called before the first frame update
    void Start()
    {
        WinText.SetActive(false);
        LoseText.SetActive(false);

        winTextComponent = WinText.GetComponent<Text>();
        loseTextComponent = LoseText.GetComponent<Text>();

        player1TextComponent = player1.GetComponent<Text>();
        player2TextComponent = player2.GetComponent<Text>();
        gamePlay = true;
        waitTime = false;

        playerInput = GetComponent<PlayerInput>();
        player1Action = playerInput.actions.FindAction("Player1Action");
        player2Action = playerInput.actions.FindAction("Player2Action");

        loseTextComponent.text = "";


        cubeRenderer = cube.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        loseTextCheck = loseTextComponent.text;
        if (timerScript.countdownFinish && gamePlay)
        {
            if (coroutine)
            {
                StartCoroutine(Wait());
                coroutine = false;
            }

            if (player1Action.WasPressedThisFrame() && cubeRenderer.material.color == Color.green)
            {
                Win("Player 1 Win");
                
            }

            else if (player2Action.WasPressedThisFrame() && cubeRenderer.material.color == Color.green)
            {
                Win("Player 2 Win");
            }

        }
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
    }

    private void Win(string textPlayerWin)
    {
        gamePlay = false;
        WinText.SetActive(true);
        winTextComponent.text += textPlayerWin;
    }

    private void Lose(string texPlayerLoose)
    {
        if (texPlayerLoose == "Player 1 is too fast")
        {
            player1Action = playerInput.actions.FindAction("LoseAction");
            player1TextComponent.color = Color.red;
            KeyWait("player1");


        }
        else
        {
            player2Action = playerInput.actions.FindAction("LoseAction");
            player2TextComponent.color = Color.red;
            KeyWait("player2");

        }
        LoseText.SetActive(true);
        if (string.IsNullOrWhiteSpace(loseTextCheck))
        {
            loseTextComponent.text = texPlayerLoose;
        }
        else
        {
            loseTextComponent.text += " " + texPlayerLoose;
        }
        
    }

    IEnumerator Wait()
    {
        countdownText.text = "Wait...";
        waitTime = true;
        yield return new WaitForSeconds(Random.Range(1, 10));
        waitTime = false;
        countdownText.text = "GO!";
        cubeRenderer.material.color = Color.green;
        
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
