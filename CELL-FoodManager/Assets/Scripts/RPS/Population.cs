using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class Population : MonoBehaviour
{
    [SerializeField] private int id;
    public List<TileBase> accessibleTerrain; //tiles that the pop can move through

    //TODO should be handled by other systems instead, just for testing
    public List<FoodSource.FoodTypes> foodtypes; //types of food that the animal can eat

    //TODO to be removed, for testing (i.e. can this animal eat this food?)
    public FoodSource food;


    private Dictionary<FoodSource.FoodTypes, float> needs = new Dictionary<FoodSource.FoodTypes, float>();

    public List<TesterNeed> foodNeeds;
    public int PopulationSize;
    public int PopulationDominace;
    public Text text;

    //Deprecated due to RPM
    //private Area area; //area <-> accessMap, where the pop can go
    public ReservePartitionManager RPM;


    public void updateNeed(FoodSource.FoodTypes type, float value)
    {
        this.needs[type] = value;
        Debug.Log("id: " + this.id + " -> " + value*this.PopulationSize);
    }

    public bool IsEdible(FoodSource foodsource)
    {
        foreach(FoodSource.FoodTypes type in this.foodtypes)
        {
            if(type == foodsource.getType())
            {
                return true;
            }
        }

        return false;
    }

    private void Start()
    {
        //RPM = ReservePartitionManager.ins;

        //RPM.AddPopulation(this);
        ////Testing
        //print(RPM.CanAccess(this, food.transform.position));

        
    }

    /* Deprecated
    public Area GetArea() {
        return area;
    }

    public List<Vector3Int> GetMap()
    {
        return area.GetMap();
    }
    */

    //for visual testing, move towards food if accessible
    private void Update()
    {
        //if (RPM.CanAccess(this, food.transform.position)) {
        //    //transform.Translate((food.transform.position - transform.position) * 0.01f);
        //}

        //text = this.gameObject.GetComponent<Text>();
        //text.transform.position = this.gameObject.transform.position;
        //text.text = "Foo";
    }

    /// <summary>
    /// Set the ID of a population for Reserve Partitioning purposes.
    /// Should never be called by a class other than the Reserve Partitioning Manager!
    /// </summary>
    public void setID(int newID) {
        id = newID;
    }

    public int getID() {
        return id;
    }



}
