# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TheMindSpire/TheMindSpire.csproj", "TheMindSpire/"]
RUN dotnet restore "TheMindSpire/TheMindSpire.csproj"
COPY TheMindSpire/ TheMindSpire/
WORKDIR "/src/TheMindSpire"
RUN dotnet build "TheMindSpire.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "TheMindSpire.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheMindSpire.dll"]
