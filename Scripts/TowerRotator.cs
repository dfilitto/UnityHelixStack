using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerRotator : MonoBehaviour
{
    public float rotationSpeed = 150f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver) return;
        if (GameManager.levelCompleted) return;
        if (!GameManager.isGameStarted) return;

        //programar para funcionar no mobile
        if (Input.GetAxis("Horizontal") != 0)
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Rotate(0, -horizontal * rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float deltax = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(0, -deltax * rotationSpeed * Time.deltaTime, 0);

        }
    }
}
