using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    [SerializeField]
    Camera mainCam;

    float shakeAmount = 0;
    float countDown;
    float halfOfCountDown;

    void Awake()
    {
        if (mainCam == null)
            mainCam = Camera.main;
    }

    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        countDown = length;
        halfOfCountDown = countDown / 2;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void DoShake()
    {   
        if (shakeAmount > 0)
        {
            //Debug.Log(countDown);
            
            if (countDown <= 0)
                countDown = 0;
            else
                countDown -= 0.06f;

            Vector3 camPos = mainCam.transform.position;
            Vector3 initPos = mainCam.transform.position;

            //multiplied by countDown to slow the shake movement down to no movement
            float offsetX = (Random.value * shakeAmount * 2 - shakeAmount)*countDown;
            float offsetY = (Random.value * shakeAmount * 2 - shakeAmount)*countDown;
            camPos.x += offsetX;
            camPos.y += offsetY;

            /*
            if (countDown == 0)
            {
                
                mainCam.transform.localPosition = Vector3.zero;
            }
            else
            {

                //Debug.Log("x: " + camPos.x + " y: " + camPos.y);

                //this part makes sure this will restrict the camera shaking to stay above the ground
                //in this case, if the the shake magnitude in the y-direction is 
                //shit i forgot
                if (camPos.y + offsetY >= 1.0f)
                    mainCam.transform.position = camPos;
                else
                    mainCam.transform.position = new Vector3(mainCam.transform.position.x, 2f, mainCam.transform.position.z);
            }
            */

            if (camPos.y + offsetY >= 1.0f)
                mainCam.transform.position = camPos;
            else
                mainCam.transform.position = new Vector3(mainCam.transform.position.x, 2f, mainCam.transform.position.z);

            //mainCam.transform.position = (camPos + Random.insideUnitSphere * countDown) * 1 + camPos*0;
            //Debug.Log(mainCam.transform.position);
        }


    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}
