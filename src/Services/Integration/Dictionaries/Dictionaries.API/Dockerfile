FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Services/Integration/Dictionaries/Dictionaries.API/Dictionaries.API.csproj", "src/Services/Integration/Dictionaries/Dictionaries.API/"]
COPY ["src/BuildingBlocks/AutoMapper/BuildingBlocks.Extensions.AutoMapper/BuildingBlocks.Extensions.AutoMapper.csproj", "src/BuildingBlocks/AutoMapper/BuildingBlocks.Extensions.AutoMapper/"]
COPY ["src/BuildingBlocks/AutoMapper/BuildingBlocks.AutoMapper/BuildingBlocks.AutoMapper.csproj", "src/BuildingBlocks/AutoMapper/BuildingBlocks.AutoMapper/"]
COPY ["src/BuildingBlocks/Assemblies/JobObserver.Extensions.Assembly/BuildingBlocks.Extensions.Assemblies.csproj", "src/BuildingBlocks/Assemblies/JobObserver.Extensions.Assembly/"]
COPY ["src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.Extensions.EntityFramework/BuildingBlocks.Extensions.EntityFramework.csproj", "src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.Extensions.EntityFramework/"]
COPY ["src/Services/Integration/Dictionaries/Dictionaries.Db.Dto/Dictionaries.Db.Dto.csproj", "src/Services/Integration/Dictionaries/Dictionaries.Db.Dto/"]
COPY ["src/BuildingBlocks/DataTransfer/BuildingBlocks.DataTransfer/BuildingBlocks.DataTransfer.csproj", "src/BuildingBlocks/DataTransfer/BuildingBlocks.DataTransfer/"]
COPY ["src/Services/Integration/Dictionaries/Dictionaries.Db/Dictionaries.Db.csproj", "src/Services/Integration/Dictionaries/Dictionaries.Db/"]
COPY ["src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.EntityFramework/BuildingBlocks.EntityFramework.csproj", "src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.EntityFramework/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.Extensions.EventBus.RabbitMQ/BuildingBlocks.Extensions.EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.Extensions.EventBus.RabbitMQ/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.EventBus.RabbitMQ/BuildingBlocks.EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.EventBus.RabbitMQ/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.EventBus/BuildingBlocks.EventBus.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.EventBus/"]
COPY ["src/Services/Integration/Dictionaries/Dictionaries.Db.Synchronization/Dictionaries.Db.Synchronization.csproj", "src/Services/Integration/Dictionaries/Dictionaries.Db.Synchronization/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.EventBus.Synchronization/BuildingBlocks.EventBus.Synchronization.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.EventBus.Synchronization/"]
RUN dotnet restore "src/Services/Integration/Dictionaries/Dictionaries.API/Dictionaries.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Integration/Dictionaries/Dictionaries.API"
RUN dotnet build "Dictionaries.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Dictionaries.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Dictionaries.API.dll"]