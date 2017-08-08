FROM microsoft/aspnetcore-build
ARG source
WORKDIR /app
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "nyom.api.dll"]
COPY ${source:-obj/Docker/publish} .