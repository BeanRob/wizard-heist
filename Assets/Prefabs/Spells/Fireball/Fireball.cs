using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell
{
    public GameObject proj;
    public bool onCoolDown;

    // Lightning spell's cast function
    public override void Cast()
    {
        //On left click:
        if (Input.GetMouseButtonDown(0) && !onCoolDown) {
            //Find the cursor
            Vector3 mouse = Input.mousePosition;
            Debug.Log(mouse);
            GameObject bolt = Instantiate(proj, Camera.main.ScreenToWorldPoint(mouse) + Vector3.forward, Quaternion.identity);
            StartCoroutine(KillBolt(bolt));
            StartCoroutine(Cooldown((float) 2));
        }        
    }

    IEnumerator KillBolt(GameObject bolt) {
        yield return new WaitForSeconds((float) 0.5);
        Destroy(bolt);
    }

    IEnumerator Cooldown(float time) {
        onCoolDown = true;
        yield return new WaitForSeconds((float) time);
        onCoolDown = false;
    }
}