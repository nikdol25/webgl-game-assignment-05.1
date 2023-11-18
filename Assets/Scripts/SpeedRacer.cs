using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedRacer : MonoBehaviour
{
    public string carMaker;
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";
    public int carWeight = 1609;
    public int yearMade = 2009;
    public float maxAcceleration = 0.98f;
    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;
    public TextMeshProUGUI textUI;
    public class Fuel
    {
        public int fuelLevel;
        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
    }
    public Fuel carFuel = new Fuel(100);

    void Start()
    {
        print("The Car Model is " + carModel + ". The car's manufacturer is " + carMaker + ". " + carModel + " has a " + engineType + " engine. ");
        CheckWeight();
        if (yearMade <= 2009)
        {
            print("This car was made in " + yearMade + ".");
            int carAge = CalculateAge(yearMade);
            print("The age of this car is " + carAge + " years.");
        }
        else
        {
            print("This car was introduced in the 2010's.");
            print("This car's maximum acceleration is " + maxAcceleration);
        }
        print(CheckCharacteristics());
    }
    void CheckWeight()
    {
        if (carWeight < 1500)
        {
            print("This " + carModel + " car's weight is less than 1500.");
        }
        else
        {
            print("This " + carModel + " car's weight is more than 1500.");
        }
    }
    int CalculateAge(int yearMade)
    {
        return 2023 - yearMade;
    }
    string CheckCharacteristics()
    {
        if (isCarTypeSedan)
        {
            return "The Car Type is a Sidan.";
        }
        else if (hasFrontEngine)
        {
            return "The Car Type is not a Sidan, but " + carModel + " has a Front Engine.";
        }
        else
        {
            return "The Car Type is neither a Sidan nor does have a Front Engine.";
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ConsumeFuel();
            CheckFuelLevel();
        }
    }
    public void ConsumeFuel()
    {
        carFuel.fuelLevel = carFuel.fuelLevel - 10;
    }
    public void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                textUI.text += "The fuel level is nearing two-thirds.";
                //print("The fuel level is nearing two-thirds.");
                break;
            case 50:
                textUI.text += "The fuel level is at half amount.";
                // print("The fuel level is at half amount.");
                break;
            case 10:
                textUI.text += "Warning! The fuel level is critically low!";
                //print("Warning! The fuel level is critically low!");
                break;
            default:
                textUI.text += "Nothing to report.";
                //print("Nothing to report.");
                break;
        }
    }
}