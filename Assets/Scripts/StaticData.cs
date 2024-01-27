using System.Collections;
using System.Collections.Generic;

public static class StaticData
{
    public static readonly string[] Scenes = { "BarIntro", "AnimationIntro", "Level1Intro", "TestLevel" };

    public class Layer
    {
        public const string Player = "Player";
        public const string Environment = "Environment";
        public const string ObstacleEnvironment = "ObstacleEnvironment";
        public const string Wall = "Wall";
        public const string Obstacle = "Obstacle";
    }
}
