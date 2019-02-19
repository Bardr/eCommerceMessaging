FROM microsoft/dotnet:sdk AS build-env

WORKDIR /app
COPY eCommerceMessaging.Shipping.ArrangeShippings/  ./eCommerceMessaging.Shipping.ArrangeShippings/
COPY eCommerceMessaging.Sales.Messages/  ./eCommerceMessaging.Sales.Messages/
COPY eCommerceMessaging.Billing.Messages/  ./eCommerceMessaging.Billing.Messages/
COPY eCommerceMessaging.Shipping.Messages/  ./eCommerceMessaging.Shipping.Messages/
COPY eCommerceMessaging.BaseHost/  ./eCommerceMessaging.BaseHost/

WORKDIR /app/eCommerceMessaging.Shipping.ArrangeShippings/
RUN dotnet publish -c Release -o out

FROM build-env AS final
WORKDIR /app/eCommerceMessaging.Shipping.ArrangeShippings
COPY --from=build-env /app/eCommerceMessaging.Shipping.ArrangeShippings/out .
ENTRYPOINT ["dotnet", "eCommerceMessaging.Shipping.ArrangeShippings.dll"]