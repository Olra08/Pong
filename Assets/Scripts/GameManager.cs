using System;
using UnityEngine;
using UnityEngine.UI;

// Observador
public class GameManager : MonoBehaviour
{
    public GameObject paddle1;
    public GameObject paddle2;
    public GameObject ball;
    public Text tituloUI;
    public Text mensajeUI;
    public Text score1UI;
    public Text score2UI;

    private bool mRunning = false;

    private BallMovementManager mBallMovementManager;

    private int mScoreJugador1 = 0;
    private int mScoreJugador2 = 0;

    private void Start()
    {
        mBallMovementManager = ball.GetComponent<BallMovementManager>();
        mBallMovementManager.AddGoalScoreDelegate(OnGoalScoredDelegate);
    }

    private void Update()
    {
        if (!mRunning && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
        /*
        if (mRunning && Input.GetKeyDown(KeyCode.LeftControl))
        {
            tituloUI.text = "Entr¨® Jugador 2";
            mensajeUI.text = "Presione espacio para continuar";
            mScoreJugador1 = 0;
            mScoreJugador2 = 0;
            score1UI.text = mScoreJugador1.ToString();
            score2UI.text = mScoreJugador2.ToString();
            tituloUI.gameObject.SetActive(true);
            mensajeUI.gameObject.SetActive(true);
            score1UI.gameObject.SetActive(true);
            score2UI.gameObject.SetActive(true);
            mRunning = false;
        }*/
    }

    private void StartGame()
    {
        ball.SetActive(true);
        mBallMovementManager.StartGame();
        tituloUI.gameObject.SetActive(false);
        mensajeUI.gameObject.SetActive(false);
        score1UI.gameObject.SetActive(false);
        score2UI.gameObject.SetActive(false);
        mRunning = true;
    }

    public void OnGoalScoredDelegate(object sender, EventArgs e)
    {
        GoalScoredData data = e as GoalScoredData;
        if (data.jugador == "Paddle1")
        {
            mScoreJugador1++;
        }
        else
        {
            mScoreJugador2++;
        }
        
        tituloUI.text = "GOL!";
        mensajeUI.text = "Presione espacio para continuar";
        score1UI.text = mScoreJugador1.ToString();
        score2UI.text = mScoreJugador2.ToString();
        tituloUI.gameObject.SetActive(true);
        mensajeUI.gameObject.SetActive(true);
        score1UI.gameObject.SetActive(true);
        score2UI.gameObject.SetActive(true);
        mRunning = false;
    }
    /*
    public void AItoPlayer2()
    {
        if (mRunning && Input.GetKeyDown(KeyCode.LeftControl))
        {
            tituloUI.text = "Entr¨® Jugador 2";
            mensajeUI.text = "Presione espacio para continuar";
            mScoreJugador1 = 0;
            mScoreJugador2 = 0;
            score1UI.text = mScoreJugador1.ToString();
            score2UI.text = mScoreJugador2.ToString();
            tituloUI.gameObject.SetActive(true);
            mensajeUI.gameObject.SetActive(true);
            score1UI.gameObject.SetActive(true);
            score2UI.gameObject.SetActive(true);
            mRunning = false;
        }
    }*/
}
