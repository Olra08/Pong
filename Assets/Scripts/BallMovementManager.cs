using System;
using UnityEngine;

public class GoalScoredData : EventArgs
{
    public string jugador;
}

// Observado
public class BallMovementManager : MonoBehaviour
{
    public Vector3 initialSpeed;
    public AudioClip goalSound;
    public AudioClip paddleCollisionSound;
    public AudioClip cpuSound;
    public AudioClip p2Sound;
    public AudioClip wallCollisionSound;
    public GameObject paddle1;
    public GameObject paddle2;

    private Vector3 speed;

    private event EventHandler mGoalScored;
    private bool mIsMoving = true;
    private AudioSource mAudioSource;
    
    private void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (mIsMoving)
        {
            transform.position += speed * Time.deltaTime;
        }
        PlayerSounds();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            mAudioSource.clip = paddleCollisionSound;
            mAudioSource.Play();
            if (paddle1.transform.rotation.z != 0 || paddle2.transform.rotation.z != 0)
            {
                speed = new Vector3(
                -speed.x,
                UnityEngine.Random.Range(-44f, 44f),
                0f
                );
            }
            else
            {
                speed = new Vector3(
                -speed.x,
                UnityEngine.Random.Range(-25f, 25f),
                0f
                );
            }

        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            mAudioSource.clip = wallCollisionSound;
            mAudioSource.Play();
            speed = new Vector3(
                speed.x,
                -speed.y,
                0f
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Goal
        mAudioSource.clip = goalSound;
        mAudioSource.Play();
        mIsMoving = false;
        GoalScoredData data = new GoalScoredData();
        if (collision.gameObject.name == "LeftWall")
        {
            //Goal del Paddle 2
            data.jugador = "Paddle2";
            mGoalScored?.Invoke(this, data);
        }
        else
        {
            //Goal del Paddle 1
            data.jugador = "Paddle1";
            mGoalScored?.Invoke(this, data);
        }
        
    }

    public void StartGame()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        speed = initialSpeed;
        mIsMoving = true;
    }

    public void AddGoalScoreDelegate(EventHandler eventHandler)
    {
        mGoalScored += eventHandler;
    }

    public void PlayerSounds()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            mAudioSource.clip = cpuSound;
            mAudioSource.Play();
        }
        else if (Input.GetKeyUp(KeyCode.RightControl))
        {
            mAudioSource.clip = p2Sound;
            mAudioSource.Play();
        }
    }
}
