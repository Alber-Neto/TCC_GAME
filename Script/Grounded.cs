using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collisor)
    {
        if(collisor.gameObject.layer == 8){
            player.pulando = false;
        }
    }

    void OnCollisionExit2D(Collision2D collisor)
    {
        if(collisor.gameObject.layer == 8){
            player.pulando = true;
        }
    }
}
