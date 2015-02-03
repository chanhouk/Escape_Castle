using UnityEngine;
using System.Collections;

public class GridFallPlatform : MonoBehaviour {
    bool drop = false;
    float tgtY = -20;
    float velY = 0;
    float dropTime = 1;
    bool hasDropped = false;
    float angleMax = 5;
    GameObject playerOn = null;

    // Use this for initialization
    void Start() {
        float startMess = 3;
        Vector3 eulers = transform.eulerAngles;
        eulers.x = Random.Range(-startMess, startMess);
        eulers.z = Random.Range(-startMess, startMess);
        transform.eulerAngles = eulers;
    }

    // Update is called once per frame
    void Update() {
        if (drop) {
            //fall
            Vector3 pos = transform.position;
            pos.y = Mathf.SmoothDamp(pos.y, tgtY, ref velY, 0.5f);
            transform.position = pos;
        }
        else {
            //restruct rotation
            Vector3 eulers = transform.eulerAngles;
            if (eulers.x > 180 && eulers.x < 360 - angleMax)
                eulers.x = 360 - angleMax;
            if (eulers.x < 180 && eulers.x > angleMax)
                eulers.x = angleMax;
            if (eulers.z > 180 && eulers.z < 360 - angleMax)
                eulers.z = 360 - angleMax;
            if (eulers.z < 180 && eulers.z > angleMax)
                eulers.z = angleMax;
            transform.eulerAngles = eulers;
        }

        //kill when hits ground
        if (transform.position.y <= tgtY + 1) {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionStay(Collision col) {
        if (!hasDropped && col.transform.tag == "Player") {
            transform.renderer.material.color = new Color(0.8f,0.8f,0.8f);
            Invoke("dropBro", dropTime);
            hasDropped = true;
            playerOn = col.gameObject;
        }
    }

    void OnCollisionExit(Collision c) {
        if (c.transform.tag == "Player") {
            playerOn = null;
        }
    }

    void dropBro() {
        drop = true;
        //random spin
        Vector3 torque;
        torque.x = Random.Range(-200, 200);
        torque.y = Random.Range(-200, 200);
        torque.z = Random.Range(-200, 200);
        constantForce.torque = torque;

        //pull player
        if (playerOn != null) {
            //playerOn.rigidbody.AddForce(Vector3.down * 500);
            //playerOn.transform.parent = transform;
            //playerOn.transform.localScale = new Vector3(0.55f, 3.66f, 0.55f);
        }
    }
}
