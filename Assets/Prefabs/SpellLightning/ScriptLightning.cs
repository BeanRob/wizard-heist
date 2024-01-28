using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public GameObject proj;
    public bool collected;
    public Renderer visual;

    // Start is called before the first frame update
    void Start()
    {
        collected = false;
        visual = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //On left click:
        if (Input.GetMouseButtonDown(0) && collected) {
            //Find the cursor
            Vector3 mouse = Input.mousePosition;
            Debug.Log(mouse);
            GameObject bolt = Instantiate(proj, Camera.main.ScreenToWorldPoint(mouse) + Vector3.up * 500 + Vector3.forward, Quaternion.identity);
            StartCoroutine(KillBolt(bolt));
        }        
    }

    IEnumerator KillBolt(GameObject bolt) {
        yield return new WaitForSeconds((float) 0.5);
        Destroy(bolt);
    }

    public void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player")) {
            visual.enabled = false;
            collected = true;
        }
    }
}
