FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/Nhom10_HoDuongTien.Web.Mvc/Nhom10_HoDuongTien.Web.Mvc.csproj", "src/Nhom10_HoDuongTien.Web.Mvc/"]
COPY ["src/Nhom10_HoDuongTien.Web.Core/Nhom10_HoDuongTien.Web.Core.csproj", "src/Nhom10_HoDuongTien.Web.Core/"]
COPY ["src/Nhom10_HoDuongTien.Application/Nhom10_HoDuongTien.Application.csproj", "src/Nhom10_HoDuongTien.Application/"]
COPY ["src/Nhom10_HoDuongTien.Core/Nhom10_HoDuongTien.Core.csproj", "src/Nhom10_HoDuongTien.Core/"]
COPY ["src/Nhom10_HoDuongTien.EntityFrameworkCore/Nhom10_HoDuongTien.EntityFrameworkCore.csproj", "src/Nhom10_HoDuongTien.EntityFrameworkCore/"]
WORKDIR "/src/src/Nhom10_HoDuongTien.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Nhom10_HoDuongTien.Web.Mvc", "src/Nhom10_HoDuongTien.Web.Mvc"]
COPY ["src/Nhom10_HoDuongTien.Web.Core", "src/Nhom10_HoDuongTien.Web.Core"]
COPY ["src/Nhom10_HoDuongTien.Application", "src/Nhom10_HoDuongTien.Application"]
COPY ["src/Nhom10_HoDuongTien.Core", "src/Nhom10_HoDuongTien.Core"]
COPY ["src/Nhom10_HoDuongTien.EntityFrameworkCore", "src/Nhom10_HoDuongTien.EntityFrameworkCore"]
WORKDIR "/src/src/Nhom10_HoDuongTien.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Nhom10_HoDuongTien.Web.Mvc.dll"]
