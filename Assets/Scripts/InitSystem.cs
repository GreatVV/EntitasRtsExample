using Entitas;

public class InitSystem : IInitializeSystem, ISetPool
{
    private Pool _pool;

    public void Initialize()
    {
        var levelDescription = _pool.levelDescription.LevelDescription;
        for (int i = 0; i < 2; i++)
        {
            InitForPlayer(i, levelDescription.Players[i]);
        }
        _pool.SetCurrentPlayer(0);
    }

    private void InitForPlayer(int i, PlayerDescription playerDescription)
    {
        _pool.CreateEntity().AddPlayer(i);
        foreach (var gameObject in playerDescription.Buildings)
        {
            var playerInitable = gameObject.GetComponent<IPlayerInitable>();
            if (playerInitable != null)
            {
                playerInitable.Init(_pool, i);
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}