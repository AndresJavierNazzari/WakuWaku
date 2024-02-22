FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/WakuWakuAPI.Application/*.csproj /src/WakuWakuAPI.Application/
COPY src/WakuWakuAPI.Domain/*.csproj /src/WakuWakuAPI.Domain/
COPY src/WakuWakuAPI.Infraestructure/*.csproj /src/WakuWakuAPI.Infraestructure/
COPY src/WakuWakuAPI.Presentation/*.csproj /src/WakuWakuAPI.Presentation/

COPY src/tests/WakuWakuAPI.Presentation.Tests/*.csproj /src/tests/WakuWakuAPI.Presentation.Tests/

RUN dotnet restore src/WakuWakuAPI.Presentation/WakuWakuAPI.Presentation.csproj

# copy everything else and build app

COPY src/WakuWakuAPI.Application/. /src/WakuWakuAPI.Application/
COPY src/WakuWakuAPI.Domain/. /src/WakuWakuAPI.Domain/
COPY src/WakuWakuAPI.Infraestructure/. /src/WakuWakuAPI.Infraestructure/
COPY src/WakuWakuAPI.Presentation/. /src/WakuWakuAPI.Presentation/

COPY src/tests/WakuWakuAPI.Presentation.Tests/. /src/tests/WakuWakuAPI.Presentation.Tests/

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:8.0 AS runtime
WORKDIR /app

ENTRYPOINT ["dotnet", "WakuWakuAPI.Presentation.dll"]
