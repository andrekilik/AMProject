using System.Collections.Generic;
using UnityEngine;

public class ConfigurationScript : MonoBehaviour {

    public static float shoalTriggerPosition = -7, shoalAwakeXPosition = -10.3f, baseMovement = 1, baseSpeed = 7
        , minSpawnYPosition = -3.3f, maxSpawnYPosition = 3.3f, victimSpeed = 2, DangerYPos = 1.7f, BixaoYStartPos = 20f
        , difficultyUp = 15, EnterBossFight = 90, DangerTime = 80;
    public static int score, bulletLimit = 3, victimsCollected;
    public static List<string> charList = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    #region Player
    public static float playerBaseSpeed = 10;
    public static float playerSpeed = 10;
    public static float baseJumpForce = 300;
    public static float jumpForce = 300;
    public static float baseJumpBoost = 40;
    public static float jumpBoost = 40;
    public static float dashForce = 5000;
	public static float speedBulletR = 15;
    public static float speedBulletL = speedBulletR * -1;
    #endregion

    #region Coin
    public static int regularCoinValue = 20;
    public static int superCoinValue = 100;
    #endregion

    #region Shoal
    public static float shoalMovementSpeed = 3;
    public static float shoalDelayTime = 0.8f;
    #endregion

    #region Victim
    public static float victimTopTopPosition = 4, victimTopBottomPosition = 0.3f, victimBottomTopPosition = -0.3f,
        victimBottomBottomPosition = -3.5f;
    public static int victimBaseValue = 100;
    #endregion

    #region SpawnTimers
    public static float enemySpawnTime = 2;
    public static float coinSpawnTime = 8;
    public static float victimSpawnTime = 10;
    public static float dropZoneSpawnTime = 30;
    #endregion

    #region MonstersValue
    public static int baiacuValue = 30;
    public static int bombValue = 10;
    public static int octopusValue = 30;
    #endregion

    #region Boss
    public static int bossHitValue = 30;
    public static int bossDeathValue = 10000;
    #endregion
}
