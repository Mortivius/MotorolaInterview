FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY dates.txt bin/Release/netcoreapp3.1/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "MarsRover.dll"]