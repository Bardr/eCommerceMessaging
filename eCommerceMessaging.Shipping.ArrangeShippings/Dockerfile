FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

COPY eCommerceMessaging.Shipping.ArrangeShippings/*.csproj  ./eCommerceMessaging.Shipping.ArrangeShippings/
COPY eCommerceMessaging.Sales.Messages/*.csproj  ./eCommerceMessaging.Sales.Messages/
COPY eCommerceMessaging.Billing.Messages/*.csproj  ./eCommerceMessaging.Billing.Messages/
COPY eCommerceMessaging.Shipping.Messages/*.csproj  ./eCommerceMessaging.Shipping.Messages/
COPY eCommerceMessaging.BaseHost/*.csproj  ./eCommerceMessaging.BaseHost/

COPY . .

RUN dotnet publish -c Release -o out

FROM build-env AS final
WORKDIR /app/eCommerceMessaging.Shipping.ArrangeShippings
COPY --from=build-env /app/eCommerceMessaging.Shipping.ArrangeShippings/out .
ENTRYPOINT ["dotnet", "eCommerceMessaging.Shipping.ArrangeShippings.dll"]