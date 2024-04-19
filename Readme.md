# Sinema Bileti Rezervasyon Uygulaması
* Bu proje, sinema bileti rezervasyon bilgilerini SQLite veritabanı dosyasına kaydetme projesidir.
* Visual Studio 2022 (.Net SDK 8) ile yapılmıştır.
* Microsoft.EntityFrameworkCore.Sqlite (8.0.4) NuGet paketi yüklenmiştir.

# Proje Varlıkları
* AsrınBaydemir.db => Verilerin kayıt edileceği veritabanıdır.
* Models => Film.cs, Salon.cs ve Seans.cs adlı dosyaları içeren klasördür.
* Film.cs => Film veritabanı modeli için oluşturulan sınıftır.
* Salon.cs => Salon veritabanı modeli için oluşturulan sınıftır.
* Seans.cs => Seans veritabanı modeli için oluşturulan sınıftır.
* EntityAyar.cs => DbContext sınıfını miras alan bir sınıftır. DbSet ve modelBuilder nesneleri için oluşturulan sınıftır.

## Film.cs
* public int id { get; set; }
* public string? FilmAd { get; set; }
* public DateTime FilmTarih { get; set; }
* public TimeSpan Saat1 { get; set; }
* public TimeSpan Saat2 { get; set; }
* public TimeSpan Saat3 { get; set; }
* public TimeSpan Saat4 { get; set; }
* public TimeSpan Saat5 { get; set; }
* public TimeSpan Saat6 { get; set; }

## Salon.cs
* public int id {  get; set; }
* public string? SalonAd { get; set; }
* public int Kapasite { get; set; }

## Seans.cs
* public int id {  get; set; }
* public string? FilmAd { get; set; }
* public DateTime FilmTarih { get; set; }
* public TimeSpan FilmSaat {  get; set; }
* public string? FilmSalon { get; set; }
* public string? MusteriAd { get; set; }
* public string? TCKimlikNo { get; set; }

## EntityAyar.cs
* public virtual DbSet<Film> Film { get; set; }
* public virtual DbSet<Salon> Salon { get; set; }
* public virtual DbSet<Seans> Seans { get; set; }
* OnConfiguring(DbContextOptionsBuilder) => Veritabanı bağlantı ayarlarını yapılandırmak için kullanılır.
* OnModelCreating(ModelBuilder) ve OnModelCreatingPartial(ModelBuilder) => Veritabanı modelini oluşturmak için kullanılır.

## Form1
* Bir tane TabControl nesnesi kullanılmıştır.
* Üç tane TabPage (Film, Salon, Seans) nesnesi kullanılmıştır.

## Form1.cs
* button1_Click(object, EventArgs) => Boş alan kontrolü yapılır. Boş alan yok ise Film sınıfından nesne oluşturulur ve veriler ilgili alanlara aktarılır. Daha sonra veriler Entity Framework kullanılarak Film veritabanına kayıt edilir ve dataGridView nesnesinde listelenir.

* button2_Click(object, EventArgs) => Film veritabanından alınan veriler Entity Framework kullanılarak dataGridView nesnesinde listelenir.

* button3_Click(object, EventArgs) => Boş alan kontrolü yapılır. Boş alan yok ise Salon sınıfından nesne oluşturulur ve veriler ilgili alanlara aktarılır. Daha sonra veriler Entity Framework kullanılarak Salon veritabanına kayıt edilir ve dataGridView nesnesinde listelenir.

* button4_Click(object, EventArgs) => Salon veritabanından alınan veriler Entity Framework kullanılarak dataGridView nesnesinde listelenir.

* button5_Click(object, EventArgs) => Boş alan kontrolü yapılır. Boş alan yok ise Seans sınıfından nesne oluşturulur ve veriler ilgili alanlara aktarılır. Daha sonra veriler Entity Framework kullanılarak Seans veritabanına kayıt edilir ve dataGridView nesnesinde listelenir. Salon kapasitesi bir azaltılır.

* button6_Click(object, EventArgs) => Seans veritabanından alınan veriler Entity Framework kullanılarak dataGridView nesnesinde listelenir.

* comboBox1_MouseHover(object, EventArgs) => Film veritabanından alınan veriler (film adları) Entity Framework kullanılarak comboBox1 nesnesinde listelenir.

* comboBox4_MouseHover(object, EventArgs) => Salon veritabanından alınan veriler (aalon adları) Entity Framework kullanılarak comboBox4 nesnesinde listelenir.

* comboBox1_SelectedIndexChanged(object, EventArgs) => comboBox1 nesnesinde bir film seçildiğinde çalışır. Film veritabanından alınan veriler (film tarihi ve film seans saatleri) Entity Framework kullanılarak; comboBox2 nesnesinde film tarihi ve comboBox3 nesnesinde film saatleri listelenir.

# Nasıl Çalışır

1. Uygulama çalıştırıldığında Film bölümü gelmektedir. Film adı, film tarihi ve filmin saatlerini (6 adet saat bilgisi) giriniz. Kaydet kısmına basınız. Veriler kayıt edilecek ve listelenecektir. Veri girişi yapmadan veritabanında olan verileri listelemek için Listele kısmına basınız.

2. Salon bölümüne basınız. Salon adı ve salon kapasitesini giriniz. Kaydet kısmına basınız. Veriler kayıt edilecek ve listelenecektir. Veri girişi yapmadan veritabanında olan verileri listelemek için Listele kısmına basınız.

3. Seans bölümüne basınız. Film adı, film saati, film tarihi, salon adı, müşteri adı ve kimlik numarası bilgisini giriniz. Kaydet kısmına basınız. Veriler kayıt edilecek ve listelenecektir. Veri girişi yapmadan veritabanında olan verileri listelemek için Listele kısmına basınız.

* Not: Uygulamanın çalıştırıldığı dizinde AsrınBaydemir.db veritabanı dosyasının, Form1 ve Microsoft.EntityFrameworkCore.Sqlite NuGet paketinin dll dosyalarının olması gerekmektedir.
* Not: Verilerin kayıt edilme veya listelenme aşamasında bir sorun ile karşılaşılır ise Try Catch bloğunun yakaladığı hata veya hatalar mesaj olarak kullanıcıya iletilecektir.

# Kayıt Edilen Veriler

* Film => 1, Test Film, 15.04.2024, 10:00:00, 12:00:00, 14:00:00, 16:00:00, 18:00:00, 20:00:00
* Salon => 1, Test Salon, 1
* Seans => 1, Test Film, 15.04.2024, 10:00:00, Test Salon, Test Müşteri, 01234567890

# Güncel Veriler

* Film => 1, Test Film, 15.04.2024, 10:00:00, 12:00:00, 14:00:00, 16:00:00, 18:00:00, 20:00:00
* Salon => 1, Test Salon, 0
* Seans => 1, Test Film, 15.04.2024, 10:00:00, Test Salon, Test Müşteri, 01234567890

* Not => Test Salon seçildiği için kapasitesi bir azalmıştır. (1 -> 0)