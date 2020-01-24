# CELL_Food Distribution System

## Overall
This script discribes a system to distribute all food sources to all animal populations in a single level. It is meant to be attech to a
script holder in each level.

## How it works
This system will get all the food sources and animal popluations in a level by its tag. For each food source it will try to feed
all populations that eat that food.

* Note: this can be a optimization problem since animal only eats certain type of foods. Approach: sort
* Note: we want to make sure that the system's behavior is easy for player to observes changes.

## Detail

### Input
* List<AnimalController>


### Output
* food for indivdual in each species

### How to get vars need:
* dominance rating - store in Animal class, total dominance can be get by `PopulationDominance` in `AnimalPopluatoion.cs`

### Function structure
class FoodDistributionSystem
{
    func getAllAnimalPoplulation();
    func getAllFoodSource();
    func distributFood();

    update()
    {
        getAllAnimalPoplulation();
        getAllFoodSource();
        distributFood();
    }
}


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

