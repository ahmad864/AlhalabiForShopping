# المرحلة 1: بناء التطبيق
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# نسخ ملف csproj واستعادة الحزم
COPY *.csproj ./
RUN dotnet restore

# نسخ كل الملفات وبناء المشروع
COPY . ./
RUN dotnet publish -c Release -o out

# المرحلة 2: تشغيل التطبيق
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# نسخ الملفات المنشورة من مرحلة البناء
COPY --from=build /app/out .

# نقطة الدخول للتطبيق
ENTRYPOINT ["dotnet", "AlhalabiForShopping.dll"]
