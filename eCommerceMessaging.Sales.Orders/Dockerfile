FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

COPY eCommerceMessaging.Sales.Orders/*.csproj  ./eCommerceMessaging.Sales.Orders/
COPY eCommerceMessaging.Sales.Messages/*.csproj  ./eCommerceMessaging.Sales.Messages/
COPY eCommerceMessaging.BaseHost/*.csproj  ./eCommerceMessaging.BaseHost/

COPY . .

RUN dotnet publish -c Release -o out

FROM build-env AS final
WORKDIR /app/eCommerceMessaging.Sales.Orders
COPY --from=build-env /app/eCommerceMessaging.Sales.Orders/out .
ENTRYPOINT ["dotnet", "eCommerceMessaging.Sales.Orders.dll"]