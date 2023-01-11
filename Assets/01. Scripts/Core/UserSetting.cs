
public class UserSetting : Data
{
    public bool isMute = false;
    public int maxScore = 0;

    public override void Generate()
    {
        isMute = false;
        maxScore = 0;
    }

    public override bool IsNull() => false;

    public override void Save()
    {
        
    }
}
