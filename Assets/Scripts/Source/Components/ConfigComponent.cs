using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[CreateAssetMenu(fileName = "MoverConfig", menuName = "GameConfig/MoverConfig")]
[Unique, Config]
public class MoverConfig : ScriptableObject
{
    public Sprite sprite;
    public int hp        = 100;
    public int mp        = 100;
    public int moveSpeed = 5;
}
