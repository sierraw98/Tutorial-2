using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour {
    private Rigidbody2D rb2d;
    private Animator anim;
    public LayerMask isGround;
    public Transform hitbox;
    private bool Hitbox;
    public float hitboxHeight;
    public float hitboxWidth;
    public int numberofCoins;
    public GameObject coin;

    //audio
    private AudioSource source;
    public AudioClip coinClip;
    private float volLowRange= 0.5f;
    private float volHighRange = 1.0f;
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Hitbox = Physics2D.OverlapBox(hitbox.position, new Vector2(hitboxWidth, hitboxHeight), 0, isGround);
        if (Hitbox == true)
        {
            numberofCoins= numberofCoins -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            numberofCoins = numberofCoins - 1;
            Instantiate(coin);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinClip);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(hitbox.position, new Vector3(hitboxWidth, hitboxHeight, 1));
    }
}
