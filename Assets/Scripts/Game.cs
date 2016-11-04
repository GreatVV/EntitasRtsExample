using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

public class Game : MonoBehaviour
{
    public Systems Systems;


    public LevelDescription LevelDescription;

    void Awake()
    {
        Assert.IsNotNull(LevelDescription);
        Pools.sharedInstance.SetAllPools();
        Pools.sharedInstance.pool.SetLevelDescription(LevelDescription);
    }

    void Start()
    {
        Systems = CreateSystems(Pools.sharedInstance);
        Systems.Initialize();
    }

    void Update()
    {
        Systems.Execute();
    }
   

    private Systems CreateSystems(Pools pools)
    {
        return new Feature("Game")
            
            .Add(pools.pool.CreateSystem(new InitSystem(), pools))
            .Add(pools.pool.CreateSystem(new ControlSystems(), pools))
            .Add(pools.pool.CreateSystem(new SpawnSystem(), pools))
            .Add(pools.pool.CreateSystem(new DestroySystem(), pools))
            ;
    }
}