using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public int vida,energia;
    public float jumpf;
    public bool pulando;
    private Rigidbody2D rig;
    private SpriteRenderer sprite;
    public Transform mira;
    public float velocidade_projetil;
    public GameObject DisparoPrefab;
    // Start is called before the first frame update
    public AudioSource jump_sound; 

    
    void Start()
    {
        rig=GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        jump_sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Disparar();
    }

    void Move(){
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * speed;
        if (horizontal >0){
            sprite.flipX = false;
        }else if(horizontal < 0){
            sprite.flipX = true;
        }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump") && !pulando){ 
            jump_sound.Play();
            rig.AddForce(new Vector2(0f,jumpf),ForceMode2D.Impulse);

        }
    }
    void Disparar(){
        if(Input.GetButtonDown("Fire1") && energia>0){
            GameObject Disparo = Instantiate(DisparoPrefab,mira.position,transform.rotation);

            if (sprite.flipX == false){
             Disparo.GetComponent<SpriteRenderer>().flipX=false;
             Disparo.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidade_projetil,0);
            }else if(sprite.flipX == true){
                Disparo.GetComponent<SpriteRenderer>().flipX=true;
                Disparo.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidade_projetil,0);
            }
           
            energia=energia-1;

        }
    }
    }

