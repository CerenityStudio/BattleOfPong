using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("CPU Setting")]
    public float speed;
    public float delayMove;

    private bool isMoveAI;
    private float randomPos;
    private bool isSingleTake;
    private bool isUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.instance.isSinglePlayer)
        {
            // ! = invert == false
            if (!isMoveAI && !isSingleTake)
            {
                Debug.Log("Terpanggil");

                StartCoroutine("DelayAIMove");
                isSingleTake = true;
            }

            if (isMoveAI)
            {
                MoveAI();
            }
        }
    }

    private IEnumerator DelayAIMove()
    {
        yield return new WaitForSeconds(delayMove);     // Menunggu waktu dari delayMove yang kita setting
        randomPos = Random.Range(-1f, 1f);

        if(transform.position.y < randomPos)
        {
            isUp = true;
        }
        else
        {
            isUp = false;
        }

        isSingleTake = false;
        isMoveAI = true;
    }

    private void MoveAI()
    {
        // ! = invert == false
        if (!isUp)  // Raket kearah bawah
        {
            rb.velocity = new Vector2(0, -1) * speed;   // Velocity = Acc -> Vector2 X=0, Y=-1
            if(transform.position.y <= randomPos)       // Posisi raket apakah sudah sampai di posisi random
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }

        if (isUp)
        {
            rb.velocity = new Vector2(0, 1) * speed;
            if(transform.position.y >= randomPos)
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }
    }
}
