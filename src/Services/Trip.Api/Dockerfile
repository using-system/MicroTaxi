FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Services/Trip.Api/Trip.Api.csproj", "src/Services/Trip.Api/"]
RUN dotnet restore "src/Services/Trip.Api/Trip.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Trip.Api"
RUN dotnet build "Trip.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Trip.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Trip.Api.dll"]