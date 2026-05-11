# NhapTCfloor3 - Phiên bản mới (ASP.NET Core 8)

## Tối ưu hóa so với phiên bản cũ

| Đặc điểm | Cũ (Web Forms) | Mới (ASP.NET Core 8) |
|-----------|-----------------|----------------------|
| Framework | .NET 4.7.2 Web Forms | .NET 8 Minimal API |
| Giao diện | PostBack toàn trang | SPA - AJAX (không reload) |
| ViewState | ~200-500KB mỗi request | 0 KB (không có ViewState) |
| jQuery | 3 phiên bản trùng lặp | Không cần jQuery |
| CDN | Phụ thuộc internet | 100% local (chạy LAN) |
| Tốc độ tải | 3-5 giây | <0.5 giây |
| Database | Đồng bộ (blocking) | Bất đồng bộ (async) |
| CSS | Bootstrap 4 + custom | Bootstrap 5 (local) |
| Tabs | AjaxControlToolkit | Bootstrap native tabs |

## Cách chạy

```bash
cd NhapTCfloor3_New/NhapTCfloor3
dotnet run
```

Mở trình duyệt: `http://localhost:5000`

## Cách publish

```bash
dotnet publish -c Release -o ./publish
```

Copy thư mục `publish` lên server IIS hoặc chạy trực tiếp:
```bash
cd publish
dotnet NhapTCfloor3.dll
```

## Cấu trúc

```
NhapTCfloor3/
├── Program.cs          # Backend API (tất cả endpoints)
├── appsettings.json    # Cấu hình
└── wwwroot/            # Frontend (static files)
    ├── index.html      # Trang chính
    ├── css/
    │   ├── bootstrap.min.css
    │   └── app.css
    ├── js/
    │   ├── bootstrap.bundle.min.js
    │   └── app.js
    └── images/
        └── KendaLogo.png
```

## Tính năng

- Chọn máy → Tải danh sách keo (AJAX, không reload)
- Xem/Sửa/Thêm mới phối phương
- 8 bảng cân liệu (type 0-7)
- Bảng quy trình luyện keo
- Copy recipe sang mã mới
- Tất cả thao tác qua API REST (nhanh, nhẹ)
