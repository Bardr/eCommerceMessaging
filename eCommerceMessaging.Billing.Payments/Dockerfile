FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app


COPY eCommerceMessaging.Billing.Payments/*.csproj  ./eCommerceMessaging.Billing.Payments/
COPY eCommerceMessaging.Sales.Messages/*.csproj  ./eCommerceMessaging.Sales.Messages/
COPY eCommerceMessaging.Billing.Messages/*.csproj  ./eCommerceMessaging.Billing.Messages/
COPY eCommerceMessaging.BaseHost/*.csproj  ./eCommerceMessaging.BaseHost/

COPY . .

RUN dotnet publish -c Release -o out

FROM build-env AS final
WORKDIR /app/eCommerceMessaging.Billing.Payments
COPY --from=build-env /app/eCommerceMessaging.Billing.Payments/out .
ENTRYPOINT ["dotnet", "eCommerceMessaging.Billing.Payments.dll"]