using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player player;
    [SerializeField] private LevelConfigSO levelConfigSO;
    [SerializeField] private MeteorSpawner meteorSpawner;
    [SerializeField] private ItemSpawner itemSpawner;
    [SerializeField] private CoinSpawner coinSpawner;
    [SerializeField] private DiamondSpawner diamondSpawner;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private LazerSpawner lazerSpawner;
    private int curDifficultyIndex = 0;
    private int meteorHitCount = 0;

    private bool hasLoggedDeath = false;

    private void Start()
    {
        InitObstacleSpanwer();
    }

    private void Update()
    {
        if (Player.Instance.GetIsDeath())
        {
            if (!hasLoggedDeath)
            {
                meteorSpawner.StopSpawing();
                itemSpawner.StopSpawing();
                coinSpawner.StopSpawing();
                diamondSpawner.StopSpawing();
                enemySpawner.StopSpawing();
                hasLoggedDeath = true;
            }
            return;
        }

        Background.Instance.LoopingBackground();
    }

    private void InitObstacleSpanwer()
    {
        //Meteors Spawner
        meteorSpawner.Initialize();
        meteorSpawner.SetSpeed(levelConfigSO.datas[curDifficultyIndex].gameSpeed);
        meteorSpawner.StartSpawing();

        //Items Spawner
        itemSpawner.Initialize();
        itemSpawner.SetSpeed(5);
        itemSpawner.StartSpawing();

        //Coins Spawner
        coinSpawner.Initialize();
        coinSpawner.SetSpeed(2);
        coinSpawner.StartSpawing();

        //Diamonds Spawner
        diamondSpawner.Initialize();
        diamondSpawner.SetSpeed(2);
        diamondSpawner.StartSpawing();

        //Enemies Spawner
        enemySpawner.Initialize();
        enemySpawner.SetSpeed(-5);
        enemySpawner.StartSpawing();

        //Lazers of enemy spawner
        lazerSpawner.Initialize();

    }

    public void IncreaseMeteorHitCount()
    {
        meteorHitCount++;
        if (meteorHitCount >= levelConfigSO.datas[curDifficultyIndex].numOfMeteor)
        {
            curDifficultyIndex++;
            if (curDifficultyIndex >= levelConfigSO.datas.Count)
            {
                curDifficultyIndex = levelConfigSO.datas.Count;
            }
            meteorHitCount = 0;
            meteorSpawner.SetSpeed(levelConfigSO.datas[curDifficultyIndex].gameSpeed);
        }
        Debug.Log($"Difficulty : {curDifficultyIndex + 1} - Meteor Hit: {meteorHitCount}");
    }
}
