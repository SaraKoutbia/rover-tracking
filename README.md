# rover-tracking
An ASP.NET MVC application that, given the initial state and trajectory of the rovers on a given plate, computes their final location and orientation.

## Getting Started

### 1st option - Cloning the repo 
From rover-tracking
```
cd .\RoverTrackingMvc\ 
dotnet run
```
Open "https://localhost:5001/" in a browser

### 2nd option - Pulling the docker image and running a container 
Follow the instructions under [this page](https://github.com/SaraKoutbia/rover-tracking/packages/537675 ) 
```
$ docker pull docker.pkg.github.com/sarakoutbia/rover-tracking/rovertrackingmvc:1.0.0
```

## Running the tests
From rover-tracking
```
cd .\RoverTracking.Tests\
test run 
```


### About the tests

The RoverTracking.Tests includes:
#### Repository test 
Runs against three different valid inputs, to verify that the results produced (final positions of the rovers) match the expected outputs.
#### Custom validation attribute test 
Runs against three different invalid inputs, and asserts that the validation fails.
#### Controller test 
Mocks a RoverTrackingController object with an error, and makes sure the ViewData value passed to the view is "ModelError", instead of "Success", when the model is valid.

## Built With

.NET 5.0 

