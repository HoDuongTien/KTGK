FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/Nhom10_HoDuongTien.Web.Host/Nhom10_HoDuongTien.Web.Host.csproj", "src/Nhom10_HoDuongTien.Web.Host/"]
COPY ["src/Nhom10_HoDuongTien.Web.Core/Nhom10_HoDuongTien.Web.Core.csproj", "src/Nhom10_HoDuongTien.Web.Core/"]
COPY ["src/Nhom10_HoDuongTien.Application/Nhom10_HoDuongTien.Application.csproj", "src/Nhom10_HoDuongTien.Application/"]
COPY ["src/Nhom10_HoDuongTien.Core/Nhom10_HoDuongTien.Core.csproj", "src/Nhom10_HoDuongTien.Core/"]
COPY ["src/Nhom10_HoDuongTien.EntityFrameworkCore/Nhom10_HoDuongTien.EntityFrameworkCore.csproj", "src/Nhom10_HoDuongTien.EntityFrameworkCore/"]
WORKDIR "/src/src/Nhom10_HoDuongTien.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Nhom10_HoDuongTien.Web.Host", "src/Nhom10_HoDuongTien.Web.Host"]
COPY ["src/Nhom10_HoDuongTien.Web.Core", "src/Nhom10_HoDuongTien.Web.Core"]
COPY ["src/Nhom10_HoDuongTien.Application", "src/Nhom10_HoDuongTien.Application"]
COPY ["src/Nhom10_HoDuongTien.Core", "src/Nhom10_HoDuongTien.Core"]
COPY ["src/Nhom10_HoDuongTien.EntityFrameworkCore", "src/Nhom10_HoDuongTien.EntityFrameworkCore"]
WORKDIR "/src/src/Nhom10_HoDuongTien.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Nhom10_HoDuongTien.Web.Host.dll"]
