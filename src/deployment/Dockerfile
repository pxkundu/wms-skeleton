# Use an official .NET runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image for build operations
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/backend/backend.csproj", "Backend/"]
RUN dotnet restore "Backend/backend.csproj"
COPY . .
WORKDIR "/src/Backend"
RUN dotnet build "backend.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "backend.csproj" -c Release -o /app/publish

# Build the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend.dll"]
