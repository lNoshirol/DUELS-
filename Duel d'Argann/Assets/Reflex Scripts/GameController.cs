using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class GameController : MonoBehaviour
{

    [SerializeField] SpriteRenderer whiteRect;
    [SerializeField] Text countdownText;
    public GameObject cube;

    private ReflexGameInput _reflexGameInput;

    private Renderer cubeRenderer;

    private bool gamePlay;

    [SerializeField] GameObject WinText;
    private Text textComponent;


    PlayerInput playerInput;
    InputAction player1Action;
    InputAction player2Action;



    [SerializeField] TimerScript timerScript;
    bool coroutine = true;

    // Start is called before the first frame update
    void Start()
    {
        WinText.SetActive(false);

        textComponent = WinText.GetComponent<Text>();
        gamePlay = true;

        playerInput = GetComponent<PlayerInput>();
        player1Action = playerInput.actions.FindAction("Player1Action");
        player2Action = playerInput.actions.FindAction("Player2Action");

        Debug.Log(player1Action);

        cubeRenderer = cube.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void Win(string textPlayerWin)
    {
        gamePlay = false;
        WinText.SetActive(true);
        textComponent.text = textPlayerWin;
    }

    IEnumerator Wait()
    {
        countdownText.text = "Wait...";
        yield return new WaitForSeconds(Random.Range(1, 10));
        countdownText.text = "GO!";
        cubeRenderer.material.color = Color.green;
        
    }
}
