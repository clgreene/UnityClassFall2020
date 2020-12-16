using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveDescriptions : MonoBehaviour
{

    public GameObject descriptions;

    public bool view;

    public Text moveOne;
    public Text moveTwo;
    public Text moveThree;

    public Inventory inv;

    // Start is called before the first frame update
    void Start()
    {
        moveOne.text = "You don't have a hellspawn with moves yet.";
        moveTwo.text = "";
        moveThree.text = "";
        descriptions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inv.units.Count > 0)
        {
            if (inv.units[0].GetComponent<Unit>().unitName == "Hellhound")
            {
                moveOne.text = "Bite: Hellspawn bites it's opponent for some serious damage!";
                moveTwo.text = "Lick Wounds: Hellspawn takes a moment to lick it's wounds, healing damamge.";
                moveThree.text = "Growl: Hellspawn Growls, intimidating it's opponent but weakening itself slightly.";
            }
            if (inv.units[0].GetComponent<Unit>().unitName == "Ghoul")
            {
                moveOne.text = "Possess: Hellspawn possess' it's foe, dealing damage and taking a small amount of damage as well!";
                moveTwo.text = "Haunt: Hellspawn haunts it's foe, dealing a small amount of damage for the next three turns.";
                moveThree.text = "Regrowth: Hellspawn heals dramatically.";
            }
            if (inv.units[0].GetComponent<Unit>().unitName == "Imp")
            {
                moveOne.text = "Suck Blood: Hellspawn sucks it's foes blood, dealing damamge and gaining some health back.";
                moveTwo.text = "Haunt: Hellspawn haunts it's foe, dealing a small amount of damage for the next three turns.";
                moveThree.text = "Regrowth: Hellspawn heals dramatically.";
            }
        }
    }

    public void viewMoves()
    {
        view = !view;
        descriptions.SetActive(view);


    }

}
