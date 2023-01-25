FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

WORKDIR /app

COPY /app2 .
RUN dotnet restore ./app2.csproj
RUN dotnet build ./app2.csproj
