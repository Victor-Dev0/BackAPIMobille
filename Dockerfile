#build
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

#Aspnet
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 5080
COPY --from=build /app/out ./

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:5001;http://+:5080;
ENTRYPOINT [ "dotnet", "BackAPI.dll", "--environment=Development" ]