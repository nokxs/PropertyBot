#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/PropertyBot.Service/PropertyBot.Service.csproj", "PropertyBot.Service/"]
RUN dotnet restore "PropertyBot.Service/PropertyBot.Service.csproj"
COPY /src .
WORKDIR "/src/PropertyBot.Service"
RUN dotnet build "PropertyBot.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PropertyBot.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PropertyBot.Service.dll"]