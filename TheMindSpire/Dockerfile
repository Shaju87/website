# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TheMindSpire.csproj", "./"]
RUN dotnet restore "TheMindSpire.csproj"
COPY . .
RUN dotnet build "TheMindSpire.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "TheMindSpire.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "TheMindSpire.dll"]
