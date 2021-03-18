using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfession 
{

    public string ProfessionName = "Profession";

    public string AbilityName = "Ability";
    public string AbilityDescription = "Does an Action";

    public int Strength     = 10; // Health = Health Regen
    public int Dexerity     = 10; //Movement Speed
    public int Constitution = 10; //Stamina = Stamina Regen
    public int Wisdom       = 10; //Mana Pool + Mana Regen
    public int Intelligence = 10; //Spell Casting Stats
    public int Charisma     = 10; //Personality
}


