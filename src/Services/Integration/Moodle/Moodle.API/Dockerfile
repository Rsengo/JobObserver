FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Services/Integration/Moodle/Moodle.API/Moodle.API.csproj", "src/Services/Integration/Moodle/Moodle.API/"]
COPY ["src/Services/Integration/Moodle/Moodle.Integration/Moodle.Integration.csproj", "src/Services/Integration/Moodle/Moodle.Integration/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.Extensions.EventBus.RabbitMQ/BuildingBlocks.Extensions.EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.Extensions.EventBus.RabbitMQ/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.EventBus.RabbitMQ/BuildingBlocks.EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.EventBus.RabbitMQ/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.EventBus/BuildingBlocks.EventBus.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.EventBus/"]
COPY ["src/Services/Integration/Moodle/Moodle.Extensions.Integration/Moodle.Extensions.Integration.csproj", "src/Services/Integration/Moodle/Moodle.Extensions.Integration/"]
RUN dotnet restore "src/Services/Integration/Moodle/Moodle.API/Moodle.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Integration/Moodle/Moodle.API"
RUN dotnet build "Moodle.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Moodle.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Moodle.API.dll"]