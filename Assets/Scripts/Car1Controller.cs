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

    private float rotate;
    private int[] score = { 0, 0 };

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        rotate = rig.rotation;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
            rotate += rotateAngle;
            rig.MoveRotation(rotate);
        }
        if (Input.GetKey(KeyCode.RightArrow))
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
        if (collision.gameObject.CompareTag("StartLine"))
        {
            anim.SetBool("IsCross", true);
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
            anim.SetBool("IsCross", false);
        }
        if (score[0] < score[1])
        {
            gameController.GetComponent<GameController>().DisplayScore(score[0], 0);
        }
        if (score[1] == 4)
        {
            gameController.GetComponent<GameController>().EndGame(0);
        }
        if (collision.gameObject.CompareTag("StartLine"))
        {
            anim.SetBool("IsCross", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
