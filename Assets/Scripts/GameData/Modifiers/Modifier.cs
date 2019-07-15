public class Modifier : LocalizedObject
{
    public Modifier(float value)
    {
        Value = value;
    }

    public float Value { get; protected set; }
    public ModifierType Type { get; protected set; }
}
