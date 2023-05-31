using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float bounceForce = 6f;
    private AudioManager audioManager;
    //adicionar audio ao jogo!!!!!

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioManager = GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>();
        //não esquecer do audio!!!!
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.gameOver) return;
        if (GameManager.levelCompleted) return;
        //faz a bola quicar
        rigidbody.velocity = new Vector3(rigidbody.velocity.x,bounceForce,rigidbody.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
        //Debug.Log(materialName);
        //Não esquecer de colocar som em tudo!!!!!!
        if (materialName == "MaterialSafe (Instance)")
        {
            //item verde
            //Debug.Log("Estou salvo!!!!!!");
            if (GameManager.isGameStarted) audioManager.Play("bounce");
        } else if(materialName == "MaterialUnSafe (Instance)")
        {
            //item vermelho
            //Debug.Log("Game Over!!!!!!");
            audioManager.Play("gameover");
            GameManager.gameOver = true;
        }else if(materialName == "MaterialLastRing (Instance)")
        {
            //Debug.Log("You Win!!!!!!");
            audioManager.Play("winlevel");
            GameManager.levelCompleted = true;
        }
    }
}
