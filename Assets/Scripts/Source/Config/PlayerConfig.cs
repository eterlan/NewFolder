using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "GameConfig/PlayerConfig")]
[Unique, Config]
public class PlayerConfig : ScriptableObject
{
    public Sprite sprite;
    public int    hp        = 100;
    public int    mp        = 100;
    public int    moveSpeed = 8;
}