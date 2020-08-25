Running Locally
1. Use ```dotnet build``` to build
2. Use ```dotnet run``` to run
3. Use ```dotnet test``` to test


Running in Docker
1. Ensure that Docker is installed and running on your local machine
2. Publish the app using ```dotnet publish -c Release```
3. Build the docker image with ```docker build -t rover-image -f Dockerfile .```
4. Create a container using ```docker create --name mars-rover rover-image``` or to build a container and run it immediately, ```docker run -it rover-image```
