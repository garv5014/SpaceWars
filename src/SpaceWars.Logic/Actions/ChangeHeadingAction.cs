﻿namespace SpaceWars.Logic.Actions;

public class ChangeHeadingAction : GamePlayAction
{
    public int NewHeading { get; set; }
    public override int Priority => 1;
    public override ActionResult Execute(Player player, GameMap _)
    {
        throw new NotImplementedException();
    }
}
