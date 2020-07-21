FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

# copy csproj and restore as distinct layers
COPY *.sln .
COPY MVCCoreStarterKit/*.csproj ./MVCCoreStarterKit/
RUN dotnet restore

# copy everything else and build app
COPY MVCCoreStarterKit/. ./MVCCoreStarterKit/
WORKDIR /MVCCoreStarterKit
RUN dotnet publish -f netcoreapp2.2 -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
ENV IZENDA_DB="" \
    MVC_DB=""

WORKDIR /app
COPY --from=build /MVCCoreStarterKit/out ./

COPY ./startup.sh ./startup.sh
RUN chmod +x ./startup.sh

ENTRYPOINT ./startup.sh "$MVC_DB" "$IZENDA_DB"