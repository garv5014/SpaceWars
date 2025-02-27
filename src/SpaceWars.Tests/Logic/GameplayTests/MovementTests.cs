﻿namespace SpaceWars.Tests.Logic.GameplayTests;

public class MovementTests
{
    [Theory]
    [InlineData(0, 0, 1, "Straight up")]
    [InlineData(22, 0, 1, "Up ")]
    [InlineData(23, 1, 1, "Up right")]
    [InlineData(24, 1, 1, "Up right")]
    [InlineData(66, 1, 1, "Up right")]
    [InlineData(67, 1, 1, "Up right")]
    [InlineData(68, 1, 0, "Right")]
    [InlineData(111, 1, 0, "Right")]
    [InlineData(112, 1, 0, "Right")]
    [InlineData(113, 1, -1, "Down Right")]
    [InlineData(157, 1, -1, "Down Right")]
    [InlineData(158, 0, -1, "Down")]
    [InlineData(202, 0, -1, "Down")]
    [InlineData(203, -1, -1, "Down Left")]
    [InlineData(247, -1, -1, "Down Left")]
    [InlineData(248, -1, 0, "Left")]
    [InlineData(292, -1, 0, "Left")]
    [InlineData(293, -1, 1, "Up Left")]
    [InlineData(337, -1, 1, "Up Left")]
    [InlineData(338, 0, 1, "Up")]
    [InlineData(359, 0, 1, "Up")]
    public void ShipMovesForwardAt1xLocationIsUpdatedAccordingly(int heading, int newX, int newY, string because)
    {
        //Arrange
        (var game, _) = GameTestHelpers.CreateGame();
        var result = game.Join("Player 1");
        game.EnqueueAction(result.Token, new MoveForwardAction(heading));

        //Act
        game.Tick();

        //Assert
        var actualPlayer = game.GetPlayerByToken(result.Token);
        var actualLocation = actualPlayer.Ship.Location;
        var expectedLocation = new Location(newX, newY);
        actualLocation.Should().Be(expectedLocation, because);
    }
}
