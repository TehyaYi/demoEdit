# CELL_Food Distribution System

## Overall
This script discribes a system to distribute all food sources to all animal populations in a single level. It is meant to be attech to a script holder in each level.

## How it works
This distrubution function `UpdateFoodNeeds` will be given an food source type and do that following:

* Realistic method
    1. Locate all food sources with the given type, `foodSources`.
    2. For each food source, `foodSource`, get all the animal that has access to it, `animalPopulations`.
    3. For all the animal populations, `animalPopulations`, remove the populations that does not consume `foodSource`, to get a new list `animalsPopulationsThatCanConsumeFoodSource`.
    4. Compute the competition rating for each `foodSource`.
    5. Sort the food sources from `foodSource` based on the competition rating in increading order.
    6. Distribute each food source from `foodSources` starting with food source with low competition rating to high.

* Naive method
    Step 1,2,3 is the same as realistic method. Jump to step 6 and distribute in any order.

### Notes: 
* Note: this can be a optimization problem since animal only eats certain type of foods. Approach: 
* Note: we want to make sure that the system's behavior is easy for player to observes changes.

## Objective(s)
* clean up existing `FoodDistributionScript.cs` and create new `FoodDistributionSystem.cs`
* break functionality into different functions
* create update() which updates the need (still keep `UpdateFoodNeeds`)
* try to reduce time complexity
* verify current algo use optimal distribution (which assumsion that animal will not get full)

## Detail

### Formulas:
* Population dominance = species dominance • population size
* Group food = (population dominance / total dominance) • food source production
* Individual food = group food / population size


### How to get vars need: 
* dominance rating - store in Animal class, total dominance can be get by `PopulationDominance` in `AnimalPopluatoion.cs`
* food sources - call `FoodSourceTileMapScript.getFoodSources()`.

### Pseudocode

```C#
class FoodDistributionSystem
{
    func getAllAnimalPoplulation();
    func getAllFoodSource();
    func UpdateFoodNeeds();

    update()
    {
        getAllAnimalPoplulation();
        getAllFoodSource();
        UpdateFoodNeeds();
    }
}
```


## Notes

INPUTS:
Species, population, dominance rating
If they can access it and if they want to eat the food in question
The different food sources, and the food output of that source (given from the food-environment system)

Does each species reach a max of how much they eat of each plant? 
Is there a way for a species to over-eat and kill the plant??

Can they access it?
Consider:
	-reach
	-fear of predators factor
	-fences
The user puts down fences to separate areas, so accessibility could be difficult to calculate.

If we are given the pertinent animals in the area, this should be easy to calculate.

We still need to look at the code already in place!

What language/document should this code be in?

