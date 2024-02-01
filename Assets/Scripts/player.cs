using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Declare movement keys
    public const string up    = "w";       
    public const string left  = "a";
    public const string down  = "s";
    public const string right = "d";

    private List<GameObject> spells;
    private GameObject equipped;

    //Multiplier for movespeed
    public const float movespeed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movement defaults to zero vector
        Vector2 direction = Vector2.zero;
        //If the key is currently pressed:
        if (Input.GetKey(left)) {
            //Add the left vector
            direction += Vector2.left;
        }
        if (Input.GetKey(right)) {
            direction += Vector2.right;
        }
        if (Input.GetKey(up)) {
            direction += Vector2.up;
        }
        if (Input.GetKey(down)) {
            direction += Vector2.down;
        }
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * movespeed;

        //On left click, cast the equipped spell
        if (Input.GetMouseButtonDown(0)) {
            equipped.GetComponent<Spell>().Cast();
        }        
    }

    private void OnCollisionEnter2D(Collision2D col) {
    }

    public void AddSpell(GameObject spell) {
        Debug.Log(spell);
        GameObject instance = Instantiate(spell, Vector3.zero, Quaternion.identity);
        equipped = instance;
        //spells.Add(Instantiate(spell));
        //if (spells.Count == 1) {
        //    equipped = spell;
        //}
    }
}