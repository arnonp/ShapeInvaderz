using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public static string
         MainMenuScene = "MainMenu",
         InstructionsSceneName = "Instructions",
         CreditsSceneName = "Credits",
         ShapeInvaders1Scene = "ShapeInvaders1";

    public static float
        Depth = 20.0f,
        MinPlayerTimeToPlace = 1.0f,
        MaxPlayerTimeToPlace = 2.0f,
        minPlayerX = -30.0f,
        maxPlayerX = 30.0f,
        minPlayerY = -15.0f,
        maxPlayerY = 15.0f,
        minEnemyX = -25.0f,
        maxEnemyX = 25.0f,
        minEnemyY = 0.0f,
        maxEnemyY = 10.0f,
        BatchHorizontalSpeed = 2.0f,
        ChildDestroyCoroutineDelay = 0.1f,
        CannonShootingPower = 0.2f,
        BulletLifeTime = 4.0f,
        BulletDamage = 10.0f,
        PlayerHorizontalForce = 5.0f,
        PlayerVerticalForce = 5.0f,
        PlayerHealth = 2.0f,
        PlayerSnapBackMultiplier = 5.0f,
        EnemyBulletDamage = 1.0f,
        EnemyCubeHealth = 40.0f,
        EnemyCubeShootingPower = 4.0f,
        EnemyBulletLifeTime = 10.0f,
        EnemyShootThreshold = 0.5f,
        EnemyTimeBetweenActions = 1.5f,
        EnemySpinPower = 10.0f,
        EnemyOriginPositionRandomMax = 20.0f,
        SceneLoadDelay = 2f,
        ExplosionForce = 10f,
        FireRate=0.1f;



}