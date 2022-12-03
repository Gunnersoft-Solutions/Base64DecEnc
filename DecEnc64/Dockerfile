#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DecEnc64/DecEnc64.csproj", "DecEnc64/"]
RUN dotnet restore "DecEnc64/DecEnc64.csproj"
COPY . .
WORKDIR "/src/DecEnc64"
RUN dotnet build "DecEnc64.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DecEnc64.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DecEnc64.dll"]