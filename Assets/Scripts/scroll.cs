using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public GameObject spell;

    public void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player")) {
            col.gameObject.GetComponent<Player>().AddSpell(spell);
            Destroy(this.gameObject);
        }
    }
}