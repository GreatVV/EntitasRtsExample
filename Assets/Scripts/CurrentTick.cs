using Entitas;
using Entitas.CodeGenerator;

[SingleEntity]
public class CurrentTick : IComponent
{
    public long Current;
}