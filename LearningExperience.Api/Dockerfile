#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LearningExperience.Api/LearningExperience.Api.csproj", "LearningExperience.Api/"]
COPY ["LearningExperience.Models/LearningExperience.Models.csproj", "LearningExperience.Models/"]
COPY ["LearningExperience.Repository/LearningExperience.Repository.csproj", "LearningExperience.Repository/"]
COPY ["LearningExperience.Ioc/LearningExperience.Ioc.csproj", "LearningExperience.Ioc/"]
COPY ["LearningExperience.Services/LearningExperience.Services.csproj", "LearningExperience.Services/"]
RUN dotnet restore "LearningExperience.Api/LearningExperience.Api.csproj"
WORKDIR "/src/LearningExperience.Api"
RUN dotnet build "LearningExperience.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningExperience.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from= publish / app / publish.
ENTRYPOINT["dotnet", "LearningExperience.Api.dll"] 
