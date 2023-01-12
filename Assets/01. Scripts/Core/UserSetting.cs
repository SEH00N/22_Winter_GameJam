
public class UserSetting : Data
{
    public bool isMute = false;
    public int bestScore = 0;

    public override void Generate()
    {
        isMute = false;
        bestScore = 0;
    }

    public override bool IsNull() => false;

    public override void Save()
    {
        
    }
}
