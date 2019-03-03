FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Services/Passenger.Api/Passenger.Api.csproj", "src/Services/Passenger.Api/"]
RUN dotnet restore "src/Services/Passenger.Api/Passenger.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Passenger.Api"
RUN dotnet build "Passenger.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Passenger.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Passenger.Api.dll"]