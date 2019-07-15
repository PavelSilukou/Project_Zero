public class TowerParameter : LocalizedObject
{
    public TowerParameter()
    {
        CalculatedValue = InitialValue;
    }

    public float InitialValue;
    public float CalculatedValue;
    public ParameterTypes type;

    public void Upgrade(float value)
    {
        CalculatedValue = InitialValue + InitialValue * value;
    }
}
