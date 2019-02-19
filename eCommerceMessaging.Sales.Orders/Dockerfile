FROM microsoft/dotnet:sdk AS build-env

WORKDIR /app
COPY eCommerceMessaging.Sales.Orders/  ./eCommerceMessaging.Sales.Orders/
COPY eCommerceMessaging.Sales.Messages/  ./eCommerceMessaging.Sales.Messages/
COPY eCommerceMessaging.Billing.Messages/  ./eCommerceMessaging.Billing.Messages/
COPY eCommerceMessaging.BaseHost/  ./eCommerceMessaging.BaseHost/

WORKDIR /app/eCommerceMessaging.Sales.Orders/
RUN dotnet publish -c Release -o out

FROM build-env AS final
WORKDIR /app/eCommerceMessaging.Sales.Orders
COPY --from=build-env /app/eCommerceMessaging.Sales.Orders/out .
ENTRYPOINT ["dotnet", "eCommerceMessaging.Sales.Orders.dll"]