using System;

[Serializable]
public class ReloadTimeTowerParameter : TowerParameter
{
    public ReloadTimeTowerParameter()
    {
        type = ParameterTypes.ReloadTime;
    }
}
