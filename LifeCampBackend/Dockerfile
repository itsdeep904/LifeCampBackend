# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LifeCampBackend/LifeCampBackend.csproj", "LifeCampBackend/"]
RUN dotnet restore "./LifeCampBackend/LifeCampBackend.csproj"
COPY . .
WORKDIR "/src/LifeCampBackend"
RUN dotnet build "./LifeCampBackend.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LifeCampBackend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Set environment variable for the connection string
ENV ConnectionStrings__LifeCampDbContextConnection="Server=sql.bsite.net\MSSQL2016;Database=dblifecamp2025_;User Id=dblifecamp2025_;Password=Mandeep@12;TrustServerCertificate=True;"
# Set environment variables for JWT configuration
ENV Jwt__Issuer="https://localhost:44387/"
ENV Jwt__Audience="https://localhost:44387/"
ENV Jwt__SecretKey="LifeCampWebsiteByDeep_secretkey_B58PQ"

#Ensure the appsetting.json is included (if needed for local files)
COPY ["LifeCampBackend/appsettings.json", "/app/appsettings.json"]

ENTRYPOINT ["dotnet", "LifeCampBackend.dll"]
