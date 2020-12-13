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

The RoverTracking.Tests includes a simple test that runs against three different inputs, to verify that the results produced match the expected outputs.



## Built With

.NET 5.0 

