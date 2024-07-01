using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject target;
    public float zombieSpeed = 1.5f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.gameObject.transform);
        // Trnslate는  (p = p0 + v*t) 값이 들어간 함수이다.
        transform.Translate(Vector3.forward * Time.deltaTime * zombieSpeed);
    }
}
