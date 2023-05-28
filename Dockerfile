FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["d_Videogame_Store.csproj", "./"]
RUN dotnet restore "./d_Videogame_Store.csproj"
COPY . .
RUN dotnet build "d_Videogame_Store.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "d_Videogame_Store.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "d_Videogame_Store.dll"]