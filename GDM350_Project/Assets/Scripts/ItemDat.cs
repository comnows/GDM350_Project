public class ItemDat
{
    public string name;
    float time = 0f;
    float force = 1f;

    public ItemDat (float newTime, float newForce)
    {
        Time = newTime;
        Force = newForce;
    }

    public float Time { get => time; set => time = value; }
    public float Force { get => force; set => force = value; }
}
