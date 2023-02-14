using System;
using Entitas.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerConverter : MonoBehaviour
{
    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        var e         = contexts.game.CreateEntity();
        e.isTagPlayer = true;
        var pos = Vector2.zero;
        e.AddPosition(pos, pos);
        e.AddDirection(Random.Range(0, 360));
            
        var config = contexts.config.moverConfig.value;
        e.AddMoveSpeed(config.moveSpeed);
        e.AddSprite(config.sprite);
        e.AddHealth(config.hp, config.hp);
        gameObject.Link(e);
        // e.AddView(gameObject);
        // gameObject.Link(e);
    }

    private void Update()
    {
        // Debug.Log("VARss");
    }
}
