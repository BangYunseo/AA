using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private bool isPinned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPinned == false){
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        isPinned = true;
        if(other.gameObject.tag == "Target"){
            transform.SetParent(other.gameObject.transform);
        }
    }
    // Pin이 Target에 충돌했을 경우 원에 붙어있는 채로 유지
}
