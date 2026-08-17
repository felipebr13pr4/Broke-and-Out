public class RandomLevelButton : LevelButton
{
    protected override void ChangeRandom() => LevelController.Instance.P_IsRandomMode = true;

}
