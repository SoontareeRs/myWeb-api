# ใช้ image base ของ .NET SDK 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# ตั้งค่าตำแหน่งทำงานใน container
WORKDIR /app

# คัดลอกไฟล์โปรเจกต์ไปยัง container
COPY *.csproj ./
RUN dotnet restore

# คัดลอกไฟล์ทั้งหมดไปยัง container
COPY . ./
RUN dotnet build -c Release -o out

# ตรวจสอบว่าไฟล์ build ถูกสร้างขึ้นหรือไม่
RUN ls /app/out

# ใช้ image base ของ ASP.NET สำหรับการรัน
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# คัดลอกผลลัพธ์จากขั้นตอน build มาที่ runtime container
COPY --from=build /app/out .

# เปิดพอร์ตที่ใช้ใน container
EXPOSE 5245

# สั่งให้รันแอปพลิเคชัน
ENTRYPOINT ["dotnet", "MyWebAPI.dll"]
