using System.Collections;
using System.Collections.Generic;

public static class StaticData
{
    public static readonly string[] Scenes = { "BarIntro", "AnimationIntro", "BarAfterIntro", "Level1Intro", "Level1", "Level2Intro", "Level2", "LastScene" };

    public class Layer
    {
        public const string Player = "Player";
        public const string Environment = "Environment";
        public const string ObstacleEnvironment = "ObstacleEnvironment";
        public const string Wall = "Wall";
        public const string Obstacle = "Obstacle";
        public const string EndingGround = "EndingGround";
        public const string ObstacleWall = "ObstacleWall";
    }
}
