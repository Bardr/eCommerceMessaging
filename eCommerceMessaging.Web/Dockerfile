FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

COPY eCommerceMessaging.sln ./
COPY eCommerceMessaging.Web/*.csproj  ./eCommerceMessaging.Web/
COPY eCommerceMessaging.Sales.Messages/*.csproj  ./eCommerceMessaging.Sales.Messages/

RUN dotnet restore eCommerceMessaging.Sales.Messages/eCommerceMessaging.Sales.Messages.csproj
RUN dotnet restore eCommerceMessaging.Web/eCommerceMessaging.Web.csproj
COPY . .

WORKDIR /app/eCommerceMessaging.Sales.Messages
RUN dotnet build

WORKDIR /app/eCommerceMessaging.Web
RUN dotnet build

RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime AS final
WORKDIR /app/eCommerceMessaging.Web
COPY --from=build-env /app/eCommerceMessaging.Web/out .
ENTRYPOINT ["dotnet", "eCommerceMessaging.Web.dll"]