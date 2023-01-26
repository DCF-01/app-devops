FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

WORKDIR /app

COPY /app1 .
RUN dotnet publish ./app1.csproj -o /srv

WORKDIR /srv
CMD [ "dotnet", "app1.dll" ]