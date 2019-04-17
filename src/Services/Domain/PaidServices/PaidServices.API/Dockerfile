FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Services/Domain/PaidServices/PaidServices.API/PaidServices.API.csproj", "src/Services/Domain/PaidServices/PaidServices.API/"]
COPY ["src/BuildingBlocks/AutoMapper/BuildingBlocks.Extensions.AutoMapper/BuildingBlocks.Extensions.AutoMapper.csproj", "src/BuildingBlocks/AutoMapper/BuildingBlocks.Extensions.AutoMapper/"]
COPY ["src/BuildingBlocks/AutoMapper/BuildingBlocks.AutoMapper/BuildingBlocks.AutoMapper.csproj", "src/BuildingBlocks/AutoMapper/BuildingBlocks.AutoMapper/"]
COPY ["src/BuildingBlocks/Assemblies/JobObserver.Extensions.Assembly/BuildingBlocks.Extensions.Assemblies.csproj", "src/BuildingBlocks/Assemblies/JobObserver.Extensions.Assembly/"]
COPY ["src/Services/Domain/Notifications/Notifications.API/Notifications.API.csproj", "src/Services/Domain/Notifications/Notifications.API/"]
COPY ["src/Services/Domain/PaidServices/PaidServices.Db.Dto/PaidServices.Db.Dto.csproj", "src/Services/Domain/PaidServices/PaidServices.Db.Dto/"]
COPY ["src/BuildingBlocks/DataTransfer/BuildingBlocks.DataTransfer/BuildingBlocks.DataTransfer.csproj", "src/BuildingBlocks/DataTransfer/BuildingBlocks.DataTransfer/"]
COPY ["src/Services/Domain/PaidServices/PaidServices.Db/PaidServices.Db.csproj", "src/Services/Domain/PaidServices/PaidServices.Db/"]
COPY ["src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.EntityFramework/BuildingBlocks.EntityFramework.csproj", "src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.EntityFramework/"]
COPY ["src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.Extensions.EntityFramework/BuildingBlocks.Extensions.EntityFramework.csproj", "src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.Extensions.EntityFramework/"]
RUN dotnet restore "src/Services/Domain/PaidServices/PaidServices.API/PaidServices.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Domain/PaidServices/PaidServices.API"
RUN dotnet build "PaidServices.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PaidServices.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaidServices.API.dll"]