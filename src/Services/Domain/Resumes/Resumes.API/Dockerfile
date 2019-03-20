FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Services/Domain/Resumes/Resumes.API/Resumes.API.csproj", "src/Services/Domain/Resumes/Resumes.API/"]
COPY ["src/Services/Domain/Resumes/Resumes.Db/Resumes.Db.csproj", "src/Services/Domain/Resumes/Resumes.Db/"]
COPY ["src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.EntityFramework/BuildingBlocks.EntityFramework.csproj", "src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.EntityFramework/"]
COPY ["src/Services/Domain/Resumes/Resumes.Synchronization/Resumes.Synchronization.csproj", "src/Services/Domain/Resumes/Resumes.Synchronization/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.EventBus/BuildingBlocks.EventBus.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.EventBus/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.EventBus.RabbitMQ/BuildingBlocks.EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.EventBus.RabbitMQ/"]
COPY ["src/Services/Domain/Resumes/Resumes.Dto/Resumes.Dto.csproj", "src/Services/Domain/Resumes/Resumes.Dto/"]
COPY ["src/BuildingBlocks/DataTransfer/BuildingBlocks.DataTransfer/BuildingBlocks.DataTransfer.csproj", "src/BuildingBlocks/DataTransfer/BuildingBlocks.DataTransfer/"]
COPY ["src/BuildingBlocks/AutoMapper/BuildingBlocks.AutoMapper/BuildingBlocks.AutoMapper.csproj", "src/BuildingBlocks/AutoMapper/BuildingBlocks.AutoMapper/"]
COPY ["src/BuildingBlocks/Assemblies/JobObserver.Extensions.Assembly/BuildingBlocks.Extensions.Assemblies.csproj", "src/BuildingBlocks/Assemblies/JobObserver.Extensions.Assembly/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.EventBus.Synchronization/BuildingBlocks.EventBus.Synchronization.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.EventBus.Synchronization/"]
COPY ["src/BuildingBlocks/AutoMapper/BuildingBlocks.Extensions.AutoMapper/BuildingBlocks.Extensions.AutoMapper.csproj", "src/BuildingBlocks/AutoMapper/BuildingBlocks.Extensions.AutoMapper/"]
COPY ["src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.Extensions.EntityFramework/BuildingBlocks.Extensions.EntityFramework.csproj", "src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.Extensions.EntityFramework/"]
COPY ["src/BuildingBlocks/EventBus/BuildingBlocks.Extensions.EventBus.RabbitMQ/BuildingBlocks.Extensions.EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/BuildingBlocks.Extensions.EventBus.RabbitMQ/"]
RUN dotnet restore "src/Services/Domain/Resumes/Resumes.API/Resumes.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Domain/Resumes/Resumes.API"
RUN dotnet build "Resumes.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Resumes.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Resumes.API.dll"]