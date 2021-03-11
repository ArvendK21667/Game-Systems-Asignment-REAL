using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CustomisationSet : MonoBehaviour
{

    // Start is called before the first frame update
    public float currentY;
    public enum BodyParts { Skin, Eyes, Mouth, Hair, Clothes, Armour };

    [Header("Texture List")]
    public List<Texture2D> skinTextures = new List<Texture2D>();
    public List<Texture2D> eyesTextures = new List<Texture2D>();
    public List<Texture2D> mouthTextures = new List<Texture2D>();
    public List<Texture2D> hairTextures = new List<Texture2D>();
    public List<Texture2D> clothesTextures = new List<Texture2D>();
    public List<Texture2D> armourTextures = new List<Texture2D>();

    private int currentTextureIndex = 0;

    [Header("character renderer")]
    public Renderer characterRenderer;

    private void Start()
    {
        GrabTextures();

        foreach(BodyParts part in Enum.GetValues(typeof(BodyParts)))
        {
            setTexture(part, 0);

        }

    }

    void GrabTextures()
    {



        foreach (BodyParts part in Enum.GetValues(typeof(BodyParts)))
        {
            Texture2D tempTexture;
            int textureCount = 0;

            do
            {
                tempTexture = (Texture2D)Resources.Load("Warrior Babe/Warrior Babe/Character / " + part + "_" + textureCount); //as Texture2D
                if (tempTexture != null) 
                {
                    switch (part)
                    {
                        case BodyParts.Skin:
                            skinTextures.Add(tempTexture);
                            break;
                        case BodyParts.Eyes:
                            eyesTextures.Add(tempTexture);
                            break;
                        case BodyParts.Mouth:
                            mouthTextures.Add(tempTexture);
                            break;
                        case BodyParts.Hair:
                            hairTextures.Add(tempTexture);
                            break;
                        case BodyParts.Clothes:
                            clothesTextures.Add(tempTexture);
                            break;
                        case BodyParts.Armour:
                            armourTextures.Add(tempTexture);
                            break;


                    }


                }

                textureCount++;

                //  skinTextures.Add(tempTexture);
            } while (tempTexture != null);




        

        }

    }
    void setTexture(BodyParts bodyParts, int direction)
    {
        List<Texture2D> textures;
        switch (bodyParts)
        {
            case BodyParts.Skin:
                textures = skinTextures;
                break;
            case BodyParts.Eyes:
                textures = eyesTextures; 
                break;
            case BodyParts.Mouth:
              textures = mouthTextures;
                break;
            case BodyParts.Hair:
                textures = hairTextures;
                break;
            case BodyParts.Clothes:
                textures = clothesTextures;
                break;
            case BodyParts.Armour:
                textures = armourTextures;
                break;
            default:
                return;
                

        }

        int partsIndex = (int)bodyParts;
        partsIndex++;//add one to skip the default material
        int partsCount = textures.Count;



        //current texture
        currentTextureIndex += direction;
        if (currentTextureIndex < 0)
        {
            currentTextureIndex = partsCount - 1; // go to the end
        }
        else if (currentTextureIndex > partsCount - 1)
        {
            currentTextureIndex = 0; // go to the start

        }

        //current texture
        //skinTextures[currentTextureIndex]
        Material[] mats = characterRenderer.materials;
        mats[partsIndex].mainTexture = textures[currentTextureIndex];
        characterRenderer.materials = mats;

    }

    private void OnGUI()
    {


        CustomiseOnGUI();


    }

    private void CustomiseOnGUI()
    {
        float currentY = 40;
        GUI.Box(new Rect(10, 10, 110, 210), "visuals");
        foreach (BodyParts part in Enum.GetValues(typeof(BodyParts)))
        {

            if (GUI.Button(new Rect(20, currentY, 20, 20), "<"))
            {
                Debug.Log("left");
                setTexture(part, -1);
            }

            GUI.Label(new Rect(45, currentY, 60, 20), part.ToString());


            if (GUI.Button(new Rect(90, currentY, 20, 20), ">"))
            {
                Debug.Log("right");
                setTexture(part, 1);
            }
            currentY += 30;
        }


    }

}
