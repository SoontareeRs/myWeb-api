# ใช้ image baseของ .NET SDK 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# ตั้งค่าตำแหน่งทำงานใน container
WORKDIR /app

# คัดลอกไฟล์โปรเจกต์ไปยัง container
COPY *.csproj ./
RUN dotnet restore

# คัดลอกไฟล์ทั้งหมดไปยัง container
COPY . ./
RUN dotnet build -c Release -o out

# สร้างภาพสำหรับการรัน
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# เปิดพอร์ตที่ใช้
EXPOSE 80

# สั่งให้รันแอปพลิเคชัน
ENTRYPOINT ["dotnet", "MyWebAPI.dll"]
