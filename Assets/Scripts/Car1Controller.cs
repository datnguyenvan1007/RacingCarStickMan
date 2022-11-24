using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car1Controller : MonoBehaviour
{
    Vector3 transformUp;

    Rigidbody2D rig;

    public float speed;

    public float rotateAngle;

    public GameObject gameController;

    private int[] score = { 0, 0 };
    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transformUp = transform.up;
        transformUp.Normalize();
        if (Input.GetKey(KeyCode.UpArrow))
            rig.velocity = -1 * transformUp * speed;
        else if (Input.GetKey(KeyCode.DownArrow))
            rig.velocity = transformUp * speed;
        else
            rig.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rig.rotation += rotateAngle;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rig.rotation -= rotateAngle;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            speed /= 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            speed *= 2;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            speed /= 3;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            speed *= 3;
        }
        if (collision.gameObject.CompareTag("tempLine") && score[0] == (score[1] - 1))
        {
            score[0]++;
        }
        if (collision.gameObject.CompareTag("StartLine") && score[0] == score[1])
        {
            score[1]++;
        }
        if (score[0] < score[1])
        {
            gameController.GetComponent<GameController>().DisplayScore(score[0], 0);
        }
        if (score[1] == 4)
        {
            gameController.GetComponent<GameController>().DisplayEndGame(0);
        }
    }
}
