using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameMaster : MonoBehaviour 
{
    public HealthBar healthBar;
    public HealthSystem healthSystem;

    private void Start()
    {
        //healthSystem = new HealthSystem(100);

        
    }    

    public void TakeDamage()
    {
        healthSystem.Damage(10);
    }
}
