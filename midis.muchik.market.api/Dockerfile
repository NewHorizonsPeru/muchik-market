#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["midis.muchik.market.api/midis.muchik.market.api.csproj", "midis.muchik.market.api/"]
COPY ["midis.muchik.market.application/midis.muchik.market.application.csproj", "midis.muchik.market.application/"]
COPY ["midis.muchik.market.domain/midis.muchik.market.domain.csproj", "midis.muchik.market.domain/"]
COPY ["midis.muchik.market.infrastructure/midis.muchik.market.infrastructure.csproj", "midis.muchik.market.infrastructure/"]
RUN dotnet restore "midis.muchik.market.api/midis.muchik.market.api.csproj"
COPY . .
WORKDIR "/src/midis.muchik.market.api"
RUN dotnet build "midis.muchik.market.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "midis.muchik.market.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "midis.muchik.market.api.dll"]