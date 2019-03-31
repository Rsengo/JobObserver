FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Services/Technical/EmailNotifications/EmailNotifications.API/EmailNotifications.API.csproj", "src/Services/Technical/EmailNotifications/EmailNotifications.API/"]
COPY ["src/Services/Technical/EmailNotifications/EmailNotifications.Mailer/EmailNotifications.Mailer.csproj", "src/Services/Technical/EmailNotifications/EmailNotifications.Mailer/"]
COPY ["src/BuildingBlocks/AutoMapper/BuildingBlocks.Extensions.AutoMapper/BuildingBlocks.Extensions.AutoMapper.csproj", "src/BuildingBlocks/AutoMapper/BuildingBlocks.Extensions.AutoMapper/"]
COPY ["src/BuildingBlocks/AutoMapper/BuildingBlocks.AutoMapper/BuildingBlocks.AutoMapper.csproj", "src/BuildingBlocks/AutoMapper/BuildingBlocks.AutoMapper/"]
COPY ["src/BuildingBlocks/Assemblies/JobObserver.Extensions.Assembly/BuildingBlocks.Extensions.Assemblies.csproj", "src/BuildingBlocks/Assemblies/JobObserver.Extensions.Assembly/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.Extensions.EventBus.RabbitMQ/BuildingBlocks.Extensions.EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.Extensions.EventBus.RabbitMQ/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.EventBus.RabbitMQ/BuildingBlocks.EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.EventBus.RabbitMQ/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.EventBus/BuildingBlocks.EventBus.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.EventBus/"]
RUN dotnet restore "src/Services/Technical/EmailNotifications/EmailNotifications.API/EmailNotifications.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Technical/EmailNotifications/EmailNotifications.API"
RUN dotnet build "EmailNotifications.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EmailNotifications.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmailNotifications.API.dll"]