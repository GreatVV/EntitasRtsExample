using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

public class Game : MonoBehaviour
{
    public Systems Systems;


    public LevelDescription LevelDescription;

    void Awake()
    {
        Application.targetFrameRate = 60;
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
            
            .Add(pools.pool.CreateSystem(new TickSystem(), pools))
            .Add(pools.pool.CreateSystem(new InitSystem(), pools))
            .Add(pools.pool.CreateSystem(new SyncPosition(), pools))
            .Add(pools.pool.CreateSystem(new UnitSelectSystem(), pools))
            .Add(pools.pool.CreateSystem(new ControlSystems(), pools))
            .Add(pools.pool.CreateSystem(new SpawnOnClickSystem(), pools))
            .Add(pools.pool.CreateSystem(new SpawnUnitInBuildingSystem(), pools))
            .Add(pools.pool.CreateSystem(new UnitAISystem(), pools))
            .Add(pools.pool.CreateSystem(new BuildingAiSystem(), pools))
            .Add(pools.pool.CreateSystem(new DamageSystem(), pools))
            .Add(pools.pool.CreateSystem(new DeathSystem(), pools))
            .Add(pools.pool.CreateSystem(new SpawnDamageParticleSystem(), pools))
            .Add(pools.pool.CreateSystem(new DestroySystem(), pools))
            ;
    }
}