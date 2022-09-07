#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Netto.Public.API/Netto.Public.API.csproj", "Netto.Public.API/"] \
&& ["Netto.Public.Domain/Netto.Public.Domain.csproj", "Netto.Public.Domain/"] \
&& ["Netto.Public.DataContext/Netto.Public.DataContext.csproj", "Netto.Public.DataContext/"] \
&& ["Netto.Public.Application/Netto.Public.Application.csproj", "Netto.Public.Application/"] \
&& ["Netto.Public.Core/Netto.Public.Core.csproj", "Netto.Public.Core/"]
RUN dotnet restore "Netto.Public.API/Netto.Public.API.csproj"
COPY . .
WORKDIR "/src/Netto.Public.API"
RUN dotnet build "Netto.Public.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Netto.Public.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Netto.Public.API.dll"]