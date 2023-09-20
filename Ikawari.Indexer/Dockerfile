#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 9910
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ikawari.Indexer/Ikawari.Indexer.csproj", "Ikawari.Indexer/"]
COPY ["Blockcore.Indexer.Core/Blockcore.Indexer.Core.csproj", "Blockcore.Indexer.Core/"]
RUN dotnet restore "Ikawari.Indexer/Ikawari.Indexer.csproj"
COPY . .
WORKDIR "/src/Ikawari.Indexer"
RUN dotnet build "Ikawari.Indexer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ikawari.Indexer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ikawari.Indexer.dll"]