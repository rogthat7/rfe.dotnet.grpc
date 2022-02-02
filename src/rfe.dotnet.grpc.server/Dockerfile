#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/rfe.dotnet.grpc.server/rfe.dotnet.grpc.server.csproj", "src/rfe.dotnet.grpc.server/"]
RUN dotnet restore "src/rfe.dotnet.grpc.server/rfe.dotnet.grpc.server.csproj"
COPY . .
WORKDIR "/src/src/rfe.dotnet.grpc.server"
RUN dotnet build "rfe.dotnet.grpc.server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "rfe.dotnet.grpc.server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "rfe.dotnet.grpc.server.dll"]