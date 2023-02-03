FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UserDemostration/UserDemostration.csproj", "UserDemostration/"]
RUN dotnet restore "UserDemostration/UserDemostration.csproj"
COPY . .
WORKDIR "/src/UserDemostration"
RUN dotnet build "UserDemostration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserDemostration.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserDemostration.dll"]