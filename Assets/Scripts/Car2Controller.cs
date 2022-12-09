using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2Controller : MonoBehaviour
{
    Vector3 transformUp;

    Rigidbody2D rig;

    public float speed;

    public float rotateAngle;

    public GameObject gameController;

    private float rotate;
    private int[] score = { 0, 0 };
    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        rotate = rig.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transformUp = transform.up;
        transformUp.Normalize();
        if (Input.GetKey(KeyCode.W))
            rig.velocity = -1 * transformUp * speed;
        else if (Input.GetKey(KeyCode.S))
            rig.velocity = transformUp * speed;
        else
            rig.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            rotate += rotateAngle;
            rig.MoveRotation(rotate);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotate -= rotateAngle;
            rig.MoveRotation(rotate);
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
            gameController.GetComponent<GameController>().DisplayScore(score[0], 1);
        }
        if (score[1] == 4)
        {
            gameController.GetComponent<GameController>().EndGame(1);
        }
    }
}
