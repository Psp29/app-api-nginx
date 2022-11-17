#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
#WORKDIR /src
#COPY ["assignment1.csproj", "."]
#RUN dotnet restore "./assignment1.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "assignment1.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "assignment1.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "assignment1.dll"]

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