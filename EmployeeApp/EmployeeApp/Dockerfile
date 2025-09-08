# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["EmployeeApp.csproj", "./"]
RUN dotnet restore "./EmployeeApp.csproj"

# Copy the rest of the source code
COPY . .
RUN dotnet build "./EmployeeApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EmployeeApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app

# Add this line to ensure the app listens on port 80 inside the container
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development


COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeApp.dll"]
