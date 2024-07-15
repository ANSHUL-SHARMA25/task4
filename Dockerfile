# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything and publish the app
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .


RUN apt-get update && apt-get install -y curl

# Expose the port the app runs on
EXPOSE 8080

# Run the app
ENTRYPOINT ["dotnet", "dockerHealthCheckApi.dll"]
