using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinLauncher : MonoBehaviour
{

    [SerializeField]
    private GameObject pinObject;
    private Pin currPin;
    // Start is called before the first frame update
    void Start()
    {
        PreparePin();
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance == null)
        {
            Debug.LogError("GameManager.instance가 null입니다! ");
            return;
        }

        if (Input.GetMouseButtonDown(0) && currPin != null && !GameManager.instance.isGameOver)
        {
            currPin.Launch();
            currPin = null;
            Invoke("PreparePin", 0.2f);
        }
        else if (GameManager.instance.isGameOver)
        {
            if (currPin != null)
            {
                Destroy(currPin.gameObject);
                currPin = null;
            }

        }
        // goal이 0일 때 currPin이 존재한다면 오브젝트 파괴
    }

    void PreparePin() {
        if (!GameManager.instance.isGameOver){
            GameObject pin = Instantiate(pinObject, transform.position, Quaternion.identity);
            currPin = pin.GetComponent<Pin>();
        }
    }
}
