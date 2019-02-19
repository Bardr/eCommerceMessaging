FROM microsoft/dotnet:sdk AS build-env

WORKDIR /app
COPY eCommerceMessaging.Billing.Payments/  ./eCommerceMessaging.Billing.Payments/
COPY eCommerceMessaging.Sales.Messages/  ./eCommerceMessaging.Sales.Messages/
COPY eCommerceMessaging.Billing.Messages/  ./eCommerceMessaging.Billing.Messages/
COPY eCommerceMessaging.BaseHost/ ./eCommerceMessaging.BaseHost/

WORKDIR /app/eCommerceMessaging.Billing.Payments
RUN dotnet publish -c Release -o out

FROM build-env AS final
WORKDIR /app/eCommerceMessaging.Billing.Payments
COPY --from=build-env /app/eCommerceMessaging.Billing.Payments/out .
ENTRYPOINT ["dotnet", "eCommerceMessaging.Billing.Payments.dll"]