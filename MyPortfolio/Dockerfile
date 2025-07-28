# Use official .NET 8 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the app and publish
COPY . ./
RUN dotnet publish -c Release -o out

# Use runtime-only image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

# Render uses port 10000
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# Start the app
ENTRYPOINT ["dotnet", "MyPortfolio.dll"]  
