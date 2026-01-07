# Desktop Application Development using MVC Architecture  
## (Studi Kasus Aplikasi Penjualan)

Aplikasi ini merupakan **aplikasi desktop berbasis Visual Basic .NET (WinForms)** yang dibangun menggunakan **arsitektur MVC (Model–View–Controller)**.  
Aplikasi dikembangkan sebagai bagian dari **tugas Ujian Akhir Semester (UAS) Pemrograman Visual Desktop** dengan studi kasus **aplikasi penjualan**.

---

## 📌 Tujuan Pengembangan
Tujuan utama dari pengembangan aplikasi ini adalah:
- Menerapkan konsep **MVC Architecture** pada aplikasi desktop
- Memisahkan logika bisnis, tampilan, dan pengelolaan data
- Meningkatkan **maintainability**, **scalability**, dan **readability** kode
- Menghasilkan aplikasi penjualan desktop yang **fungsional dan terstruktur**

---

## 🧱 Arsitektur MVC
Aplikasi ini menerapkan pola **Model–View–Controller**, dengan pembagian sebagai berikut:

### 🔹 Model
Berisi representasi data dan logika bisnis, seperti:
- `ItemModel`
- `CategoryModel`
- `SupplierModel`
- `SalesModel`
- `PurchaseModel`

Model bertanggung jawab terhadap:
- Struktur data
- Validasi data
- Interaksi dengan database melalui Controller

### 🔹 View
Berupa **Form (WinForms)** yang digunakan oleh user, antara lain:
- Form Utama
- Form Item (List & Input)
- Form Kategori
- Form Supplier
- Form Penjualan
- Form Pembelian
- Form Laporan Penjualan & Pembelian
- Form Setting Database

View hanya menangani **tampilan dan interaksi user**, tanpa logika database.

### 🔹 Controller
Menjadi penghubung antara **View dan Model**, antara lain:
- `ItemController`
- `CategoryController`
- `SupplierController`
- `SalesController`
- `PurchaseController`

Controller bertugas:
- Mengelola CRUD (Create, Read, Update, Delete)
- Menjalankan logika aplikasi
- Mengatur alur data dari dan ke database

---

## ⚙️ Fitur Aplikasi
Beberapa fitur utama yang tersedia:
- ✅ Master Data Item
- ✅ Master Data Kategori
- ✅ Master Data Supplier
- ✅ Transaksi Penjualan
- ✅ Transaksi Pembelian
- ✅ Laporan Penjualan
- ✅ Laporan Pembelian
- ✅ Pengaturan Koneksi Database
- ✅ Pencarian & Filter Data
- ✅ CRUD Data Terintegrasi

---

## 🛠️ Teknologi yang Digunakan
- **Bahasa Pemrograman**: Visual Basic .NET
- **Framework**: Windows Forms (WinForms)
- **Database**: MySQL / MariaDB
- **Library**: MySql.Data
- **Arsitektur**: MVC (Model–View–Controller)

---

## 🗄️ Konfigurasi Database
Pengaturan database disimpan dalam file `setting.ini` yang dapat diatur melalui **Form Setting Database**, meliputi:
- Server
- Database
- Username
- Password

Tersedia fitur **Test Connection** untuk memastikan koneksi database berjalan dengan baik.

---

## ▶️ Cara Menjalankan Aplikasi
1. Clone repository ini
2. Buka project menggunakan **Visual Studio**
3. Pastikan database MySQL/MariaDB sudah aktif
4. Jalankan aplikasi
5. Atur koneksi database melalui **Form Setting Database**
6. Aplikasi siap digunakan

---

## 📚 Kesimpulan
Aplikasi ini berhasil mengimplementasikan **arsitektur MVC pada aplikasi desktop**, sehingga kode menjadi lebih terstruktur, mudah dipelihara, dan mudah dikembangkan.  
Penerapan MVC juga membuktikan bahwa konsep arsitektur modern tidak hanya berlaku pada aplikasi web, tetapi juga **sangat relevan untuk aplikasi desktop**.

---

## 👤 Author
**Nama**: _EKO APRILIYANI_  
**Mata Kuliah**: Pemrograman Visual Desktop  
**Jenis Tugas**: Ujian Akhir Semester (UAS)

---

⭐ Jika repository ini bermanfaat, silakan beri **star**!
