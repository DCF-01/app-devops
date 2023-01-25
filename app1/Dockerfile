FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

WORKDIR /app

COPY /app1 .
RUN dotnet restore ./app1.csproj
RUN dotnet build ./app1.csproj
