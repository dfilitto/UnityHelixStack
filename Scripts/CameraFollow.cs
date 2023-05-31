using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //Player
    private Vector3 offset; //distância entre o player e a câmenra
    public float smoothSpeed = 0.04f;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        //criando uma nova coordenada entre o ponta A e o ponto B
        Vector3 newposition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        transform.position = newposition;
    }
}
