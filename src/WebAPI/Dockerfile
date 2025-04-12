##build the project and choose environment
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
#create folder for container
WORKDIR /app
#copy project file 
Copy ..
#Resotre packages
RUN dotnet restore
#Build Project (Release Mode)
RUN dotnet publish -c Release -o out
#run 
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
#define the working directory in the project 
WORKDIR /app
#copy files resulted from the build 
COPY --from=build /app/out ./
#Run the project 
ENTRYPOINT ["dotnet", "WebAPI.dll"]
