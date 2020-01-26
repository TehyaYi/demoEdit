# CELL Game System Overview

## Systems

* game manager - `ObservationModeObservationModeController`:GameObject
    - holds food distribution script, animal controller and growth/decline system

* food distribution - `FoodDistributionScript.cs`: script
    - updates the animal's need (food source)

* growth/decline - `GrowthDeclineScript.cs`: script
    - calls the food ditribution script



