using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestt : MonoBehaviour
{
    public int MaxHealth;
    public int CorrentHealth;

    public healtBar healtBar;

    // Start is called before the first frame update
    void Start()
    {
        CorrentHealth = MaxHealth;
        healtBar.setMaxhealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(20);

        }
        
    }

    void takeDamage(int damage)
    {
        CorrentHealth -= damage;
        healtBar.SetHealth(CorrentHealth);
    }
}
