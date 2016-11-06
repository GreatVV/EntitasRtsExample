using System.Collections;
using System.Collections.Generic;
using Entitas;

public class Unit : IComponent
{
}

public class Health : IComponent
{
    public float Value;
}

public class Regeneration : IComponent
{
    public float Value;
}

public class Player : IComponent
{
    public int Id;
}

public class Building : IComponent
{
    
}

public class Sword : IComponent
{
    
}

public class Axe : IComponent
{
    
}

public class Damage : IComponent
{
    public float Value;
}