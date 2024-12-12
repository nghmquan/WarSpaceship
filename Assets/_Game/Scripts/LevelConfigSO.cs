using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfigSO", menuName = "ScriptableObjects/LevelConfigSO")]
public class LevelConfigSO : ScriptableObject
{
    public List<LevelConfigData> datas;
}

[System.Serializable]
public class LevelConfigData
{
    public int numOfMeteor;
    public float gameSpeed;
}
