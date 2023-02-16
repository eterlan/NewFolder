using UnityEngine;

[CreateAssetMenu(fileName = "DmgConfigs", menuName = "Define/DmgConfigs")]
public class DmgConfigs : ScriptableObject
{
    public DmgConfig[] configs;
}

public class DmgConfig
{
    public int     id;
    public string  vfxName;
    public DmgType type;
    public int     total;
    public int     interval;
    public int     dmgValue;
}

public enum DmgType
{
    Bullet,
    Fire
}

[Game]
public class 
