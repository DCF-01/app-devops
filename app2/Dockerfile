FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

WORKDIR /app

COPY /app2 .
RUN dotnet publish ./app2.csproj -o /srv

WORKDIR /srv
CMD [ "dotnet", "app2.dll" ]