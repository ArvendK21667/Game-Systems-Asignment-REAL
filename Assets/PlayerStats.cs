using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]

public struct Stats
{
    //string StatName;
    public int defaultStat;
    public int pooledStat;


    //    public int totalStat
    //    {
    //        get
    //        {
    //            return defaultStat + pooledStat;
    //        }
    //
    //    }
}


public class PlayerStats : MonoBehaviour
{

    [SerializeField] private PlayerProfession[] playerProfessions;

    private PlayerProfession _profession;
    public PlayerProfession Profession
    {
        get { return _profession; }
        set
        {

            _profession = value;
            Strength.defaultStat = _profession.Strength;
            Dexerity.defaultStat = _profession.Dexerity;
            Constitution.defaultStat = _profession.Constitution;
            Wisdom.defaultStat = _profession.Wisdom;
            Intelligence.defaultStat = _profession.Intelligence;
            Charisma.defaultStat = _profession.Charisma;
            UpdateStats();


        }
    }


    public enum BaseStats { Strength, Dexerity, Constitution, Wisdom, Intelligence, Charisma };

    public int level;
    public int pointpool = 15;

    [Header("Stats")]
    public Stats Strength;     // Health = Health Regen
    public Stats Dexerity;     //Movement Speed
    public Stats Constitution; //Stamina = Stamina Regen
    public Stats Wisdom;       //Mana Pool + Mana Regen
    public Stats Intelligence; //Spell Casting Stats
    public Stats Charisma;     //Personality

    [Header("Health")]
    public float Maxhealth; // Class Base Healthg + (Strength * level * 0.5f);
    public float currentHealth;
    public float healthRegen;

    [Header("Movement")]
    public float movementSpeed;
    public float sprintSpeed;
    public float crouchSpeed;
    public float jump;
    public float maxStamina;
    public float currentStamina;
    public float staminaRegen;

    [Header("Mana")]
    public float maxMana;
    public float currentMana;
    public float manaRegen;

    public Stats EnumToStats(BaseStats baseStats)
    {
        switch (baseStats)
        {
            case BaseStats.Strength:
                return Strength;
            case BaseStats.Dexerity:
                return Dexerity;
            case BaseStats.Constitution:
                return Constitution;
            case BaseStats.Wisdom:
                return Wisdom;
            case BaseStats.Intelligence:
                return Intelligence;
            case BaseStats.Charisma:
                return Charisma;

        }
        return new Stats();
    }

    private void UpdateStats()
    {

    }
    public bool ChangeStats(BaseStats baseStats, int amount)
    {
        Stats stats = EnumToStats(baseStats);

        if (amount > 0 && pointpool - amount < 0)
        {
            return false;
        }
        if (amount < 0 && stats.pooledStat + amount < 0)
        {
            return false;
        }

        switch (baseStats)
        {
            case BaseStats.Strength:
                if (amount < 0 && Strength.pooledStat + amount < 0)
                {
                    return false;
                }
                Strength.pooledStat += amount;
                pointpool -= amount;
                return true;

            case BaseStats.Dexerity:
                if (amount < 0 && Dexerity.pooledStat + amount < 0)
                {
                    return false;
                }
                Dexerity.pooledStat += amount;
                pointpool -= amount;
                return true;

            case BaseStats.Constitution:
                if (amount < 0 && Constitution.pooledStat + amount < 0)
                {
                    return false;
                }
                Constitution.pooledStat += amount;
                pointpool -= amount;
                return true;

            case BaseStats.Wisdom:
                if (amount < 0 && Wisdom.pooledStat + amount < 0)
                {
                    return false;
                }
                Wisdom.pooledStat += amount;
                pointpool -= amount;
                return true;

            case BaseStats.Intelligence:
                if (amount < 0 && Intelligence.pooledStat + amount < 0)
                {
                    return false;
                }
                Intelligence.pooledStat += amount;
                pointpool -= amount;
                return true;

            case BaseStats.Charisma:
                if (amount < 0 && Charisma.pooledStat + amount < 0)
                {
                    return false;
                }
                Charisma.pooledStat += amount;
                pointpool -= amount;
                return true;
        }
        return false;
    }

    private void OnGUI()
    {
        StatsOnGUI();
        ProfessionOnGUI();
    }

    Vector2 scrollPosition;
    private void ProfessionOnGUI()
    {
        float currentY = Screen.height * 0.6f;

        GUI.Box(new Rect(Screen.width - 170, currentY, 155, 80), "Profession");

        currentY += 20;
        scrollPosition = GUI.BeginScrollView(new Rect(Screen.width - 170, currentY, 155, 50)
                            , scrollPosition
                            , new Rect(0, 0, 100, 30 * playerProfessions.Length));

        currentY = 0;

        foreach (PlayerProfession profession in playerProfessions)
        {
            if (GUI.Button(new Rect(20, currentY, 100, 20), profession.ProfessionName))
            {
                Profession = profession;
            }
            currentY += 30;
        }


        GUI.EndScrollView();

        if (_profession != null)
        {
            GUI.Box(new Rect(Screen.width - 170, Screen.height - 110, 155, 80), "Profession");
            GUI.Label(new Rect(Screen.width - 140, Screen.height -  120 + 30, 100, 20), _profession.ProfessionName);
            GUI.Label(new Rect(Screen.width - 140, Screen.height - 120 + 45, 100, 20), _profession.AbilityName);
            GUI.Label(new Rect(Screen.width - 140, Screen.height - 120 + 60, 100, 20), _profession.AbilityDescription);
        }
    }
private void StatsOnGUI()
    {
        float currentY = 40;
        GUI.Box(new Rect(Screen.width - 170, 10, 155, 210), "Stats : " + pointpool);

        foreach (BaseStats baseStats in Enum.GetValues(typeof(BaseStats)))
        {
            Stats stats = EnumToStats(baseStats);

            if (GUI.Button(new Rect(Screen.width - 165, currentY, 20, 20), "-"))
            {
                ChangeStats(baseStats, -1);
            }
            GUI.Label(new Rect(Screen.width - 140, currentY, 100, 20), baseStats.ToString() + " :" + (stats.defaultStat + stats.pooledStat));
            if (GUI.Button(new Rect(Screen.width - 40, currentY, 20, 20), "+"))
            {
                ChangeStats(baseStats, 1);
            }
            currentY += 30;
        }




    }

}
