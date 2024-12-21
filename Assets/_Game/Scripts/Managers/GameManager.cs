using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    [SerializeField] private LevelConfigSO levelConfigSO;
    [SerializeField] private MeteorSpawner meteorSpawner;
    [SerializeField] private ItemSpawner itemSpawner;
    [SerializeField] private CoinSpawner coinSpawner;
    [SerializeField] private DiamondSpawner diamondSpawner;
    [SerializeField] private EnemySpawner enemySpawner;

    private int curDifficultyIndex = 0;
    private int meteorHitCount = 0;

    private void Start()
    {
        //Meteors
        InitMeteorSpawner();

        //Items
        InitItemSpawner();

        //Coins
        InitCoinSpawner();

        //Diamonds
        InitDiamondSpawner();

        //Enemies
        InitEnemySpawner();

        //Lazer of enemy
    }

    void InitMeteorSpawner()
    {
        meteorSpawner.Initialize();
        meteorSpawner.SetSpeed(levelConfigSO.datas[curDifficultyIndex].gameSpeed);
        meteorSpawner.StartSpawnMeteor();
    }

    void InitItemSpawner()
    {
        itemSpawner.Initialize();
        itemSpawner.SetSpeed(5);
        itemSpawner.StartSpawnItem();
    }

    void InitCoinSpawner()
    {
        coinSpawner.Initialize();
        coinSpawner.SetSpeed(2);
        coinSpawner.StartSpawnCoin();
    }

    void InitDiamondSpawner()
    {
        diamondSpawner.Initialize();
        diamondSpawner.SetSpeed(2);
        diamondSpawner.StartSpawnDiamond();
    }

    void InitEnemySpawner()
    {
        enemySpawner.Initialize();
        enemySpawner.SetSpeed(-5);
        enemySpawner.StartSpawnEnemy();
    }

    public void IncreaseMeteorHitCount()
    {
        meteorHitCount++;
        if (meteorHitCount >= levelConfigSO.datas[curDifficultyIndex].numOfMeteor)
        {
            curDifficultyIndex++;
            if (curDifficultyIndex>= levelConfigSO.datas.Count)
            {
                curDifficultyIndex = levelConfigSO.datas.Count;
            }
            meteorHitCount = 0;
            meteorSpawner.SetSpeed(levelConfigSO.datas[curDifficultyIndex].gameSpeed);
        }
        Debug.Log($"Difficulty : {curDifficultyIndex+1} - Meteor Hit: {meteorHitCount}");
    }
}
