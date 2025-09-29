using _Game.Scripts.OtherObjects;

public class MoneyObject : PickUpItem
{
    
    protected override void PickUpLogic()
    {
        var scoreHolder = GetComponent<ScoreHolder>();
        
        scoreHolder.GetScore();
        base.PickUpLogic();
    }
}
