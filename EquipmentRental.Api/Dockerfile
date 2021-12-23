FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EquipmentRental/EquipmentRental.csproj", "EquipmentRental/"]
RUN dotnet restore "EquipmentRental/EquipmentRental.csproj"
COPY . .
WORKDIR "/src/EquipmentRental"
RUN dotnet build "EquipmentRental.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EquipmentRental.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EquipmentRental.dll"]
