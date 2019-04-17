FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Services/Domain/BrandedTemplates/BrandedTemplates.API/BrandedTemplates.API.csproj", "src/Services/Domain/BrandedTemplates/BrandedTemplates.API/"]
COPY ["src/BuildingBlocks/AutoMapper/BuildingBlocks.Extensions.AutoMapper/BuildingBlocks.Extensions.AutoMapper.csproj", "src/BuildingBlocks/AutoMapper/BuildingBlocks.Extensions.AutoMapper/"]
COPY ["src/BuildingBlocks/AutoMapper/BuildingBlocks.AutoMapper/BuildingBlocks.AutoMapper.csproj", "src/BuildingBlocks/AutoMapper/BuildingBlocks.AutoMapper/"]
COPY ["src/BuildingBlocks/Assemblies/JobObserver.Extensions.Assembly/BuildingBlocks.Extensions.Assemblies.csproj", "src/BuildingBlocks/Assemblies/JobObserver.Extensions.Assembly/"]
COPY ["src/Services/Domain/BrandedTemplates/BrandedTemplates.Db/BrandedTemplates.Db.csproj", "src/Services/Domain/BrandedTemplates/BrandedTemplates.Db/"]
COPY ["src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.EntityFramework/BuildingBlocks.EntityFramework.csproj", "src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.EntityFramework/"]
COPY ["src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.Extensions.EntityFramework/BuildingBlocks.Extensions.EntityFramework.csproj", "src/BuildingBlocks/Database/EntityFramework/BuildingBlocks.Extensions.EntityFramework/"]
COPY ["src/Services/Domain/BrandedTemplates/BrandedTemplates.Db.Dto/BrandedTemplates.Db.Dto.csproj", "src/Services/Domain/BrandedTemplates/BrandedTemplates.Db.Dto/"]
COPY ["src/BuildingBlocks/DataTransfer/BuildingBlocks.DataTransfer/BuildingBlocks.DataTransfer.csproj", "src/BuildingBlocks/DataTransfer/BuildingBlocks.DataTransfer/"]
RUN dotnet restore "src/Services/Domain/BrandedTemplates/BrandedTemplates.API/BrandedTemplates.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Domain/BrandedTemplates/BrandedTemplates.API"
RUN dotnet build "BrandedTemplates.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BrandedTemplates.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BrandedTemplates.API.dll"]