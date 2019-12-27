using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHelper : MonoBehaviour
{
    public int Gold = 50;
    public int MaxHealth = 100;
    public int Health = 100;

    GameHelper _gameHelper;
    // Start is called before the first frame update
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();

        _gameHelper.HealthSlider.maxValue = MaxHealth;
        _gameHelper.HealthSlider.value = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GetHit(int damage)
    {
        int health = Health - damage;

        if(health <= 0)
        {
            _gameHelper.TakeGold(Gold);
            Destroy(gameObject);

        }
        Health = health;

        _gameHelper.HealthSlider.value = Health;
    }
}
