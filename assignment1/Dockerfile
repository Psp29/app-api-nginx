#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet tool install --global dotnet-ef --version 3.1
ENV PATH $PATH:/root/.dotnet/tools

RUN dotnet ef database update

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
COPY --from=build /app/Users.db .
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "assignment1.dll"]