FROM microsoft/aspnetcore-build
RUN mkdir /nyom
WORKDIR /nyom
ENTRYPOINT ["dotnet", "nyom.api.dll"]
COPY /bin/Release/netcoreapp1.1/publish/ /nyom