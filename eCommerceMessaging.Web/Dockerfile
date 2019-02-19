FROM microsoft/dotnet:sdk AS build-env

WORKDIR /app
COPY eCommerceMessaging.Web/ ./eCommerceMessaging.Web/
COPY eCommerceMessaging.Sales.Messages/  ./eCommerceMessaging.Sales.Messages/

WORKDIR /app/eCommerceMessaging.Web/
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime AS final
WORKDIR /app/eCommerceMessaging.Web
COPY --from=build-env /app/eCommerceMessaging.Web/out .
ENTRYPOINT ["dotnet", "eCommerceMessaging.Web.dll"]