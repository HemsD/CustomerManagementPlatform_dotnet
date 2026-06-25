# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

#copies our project
COPY . .    

#Downloads NuGet packages
RUN dotnet restore 

#Compiles project
RUN dotnet publish -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Lowes.CustomerManagement.dll"]
