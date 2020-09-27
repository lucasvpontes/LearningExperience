FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LearningExperience.Api.csproj", "LearningExperience.Api/"]
COPY ["LearningExperience.Api/LearningExperience.Api.csproj", "LearningExperience.Api/"]
RUN dotnet restore "LearningExperience.Api/LearningExperience.Api.csproj"
COPY . .
WORKDIR "/src/LearningExperience"
WORKDIR "/src/LearningExperience.Api"
RUN dotnet build "LearningExperience.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/LearningExperience.Api/LearningExperience.Api.csproj" -c Release -o /app/publish
RUN dotnet publish "LearningExperience.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app