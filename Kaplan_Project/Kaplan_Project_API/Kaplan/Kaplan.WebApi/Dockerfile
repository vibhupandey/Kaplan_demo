#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1709 AS build
WORKDIR /src
COPY ["Kaplan/Kaplan.WebApi/Kaplan.WebApi.csproj", "Kaplan/Kaplan.WebApi/"]
COPY ["Kaplan/Kaplan.Infrastructure/Kaplan.Infrastructure.csproj", "Kaplan/Kaplan.Infrastructure/"]
COPY ["Kaplan/Kaplan.DataAccess.Service/Kaplan.DataAccess.Service.csproj", "Kaplan/Kaplan.DataAccess.Service/"]
COPY ["Kaplan/Kaplan.DataAccess.Contracts/Kaplan.DataAccess.Contracts.csproj", "Kaplan/Kaplan.DataAccess.Contracts/"]
COPY ["Kaplan/Kaplan.Business.Service/Kaplan.Business.Service.csproj", "Kaplan/Kaplan.Business.Service/"]
COPY ["Kaplan/Kaplan.Business.Contracts/Kaplan.Business.Contracts.csproj", "Kaplan/Kaplan.Business.Contracts/"]
RUN dotnet restore "Kaplan/Kaplan.WebApi/Kaplan.WebApi.csproj"
COPY . .
WORKDIR "/src/Kaplan/Kaplan.WebApi"
RUN dotnet build "Kaplan.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Kaplan.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Kaplan.WebApi.dll"]
