using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHelper : MonoBehaviour
{
    // Start is called before the first frame update
    GameHelper _gameHelper;
    PlayerHelper _playerHelper;
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
    
        _playerHelper = GameObject.FindObjectOfType<PlayerHelper>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() 
    {

        GetComponent<HealthHelper>().GetHit(_gameHelper.PlayerDamage);
        if(_gameHelper.EndGame)
            return;
            
        _playerHelper.Attack();
    }
}
