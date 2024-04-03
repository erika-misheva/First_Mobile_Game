using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))] // se pishuva nad klasata (ako ovaa skripta se stavi na objekt sto nema rigid bodi, ovaa liija kod mu dodava rigid body)
public class BirdController : MonoBehaviour
{

     private Rigidbody2D rb;
     [SerializeField] private float jumpSpeed;
    //dozvoluva varijablata da si ostane private samo da moze da ja modificirame od inspectorot
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetJumpInput())
        {
            Debug.Log("The Charachter should jump");
            Jump();
        }
    }

    private bool GetJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
    }
} 
