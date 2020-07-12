FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["CoreApi.csproj", "./"]
RUN dotnet restore "./CoreApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CoreApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CoreApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CoreApi.dll"]


# $ docker build -t corepiangular .

# $ docker run -d -p 5080:80 --name CoreApi corepiangular