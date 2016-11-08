using Entitas;

public class TickSystem : IExecuteSystem, IInitializeSystem, ISetPool
{
    private Pool _pool;

    public void Execute()
    {
        _pool.ReplaceCurrentTick(_pool.currentTick.Current + 1);
    }

    public void Initialize()
    {
        _pool.ReplaceCurrentTick(0);
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}