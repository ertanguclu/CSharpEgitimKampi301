--C# Egitim Kampı

--FrmStatistics

![CsharpEgitimKampi301](https://github.com/user-attachments/assets/b84d98c4-3df3-4468-aa9d-a01231372809)

Bu uygulamada, EgitimKampiEfTravelDb adında bir SQL Server veri tabanı oluşturuldu. Veri tabanına Location, Customer ve Guide isimli tablolar oluşturuldu ve bu tablolara veri setleri eklendi. Uygulamada Entity Framework(EF), ADO.NET altyapısı kullanılarak veri tabanı ile bağlantı sağlandı ve bir Model Context oluşturuldu. C# Windows Form uygulaması üzerinden, LINQ sorguları ile veri tabanından veriler çekilerek bir istatistik paneli yapıldı

Veritabanı İstatistikleri ve Kod Açıklamaları
Bu projede, bir veritabanındaki Location ve Guide tabloları üzerinden çeşitli istatistiksel veriler elde etmeyi öğrendim. Aşağıda, her bir istatistiksel veriyi nasıl sorguladığımı ve gösterdiğimi açıklıyorum:

Lokasyon Sayısı
Konumların toplam sayısını bulmak için:

lblLocationCount.Text = db.Location.Count().ToString();
Toplam Kapasite
Tüm konumların kapasite toplamını hesaplamak için:

lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
Rehber Sayısı
Rehberlerin toplam sayısını bulmak için:

lblGuideCount.Text = db.Guide.Count().ToString();
Ortalama Kapasite
Konumların kapasitesinin ortalamasını hesaplamak için:

lblAvgCapacity.Text = $"{db.Location.Average(x => x.Capacity):F2}";
Ortalama Tur Fiyatı
Konumların fiyatlarının ortalamasını bulmak için:

lblAvgPrice.Text = $"{db.Location.Average(x => x.Price):F2} ₺";
Eklenen Son Ülke
En son eklenen ülkenin adını almak için:

int lblLastCountryId = db.Location.Max(x => x.LocationId);
lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lblLastCountryId).Select(y => y.Country).FirstOrDefault();
Kapadokya Tur Kapasitesi
Kapadokya'daki ilk konumun kapasitesini almak için:

lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
Türkiye Turları Ortalama Kapasite
Türkiye'deki konumların kapasite ortalamasını hesaplamak için:

lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();
Roma Gezi Rehberi
Roma Turistik şehrine ait rehberin adını ve soyadını almak için:

var romaGuideId = db.Location.Where(x => x.City == "Roma Turistik").Select(y => y.GuideId).FirstOrDefault();
lblRomaGuideName.Text = db.Guide.Where(x => x.GuideId == romaGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();
En Yüksek Kapasiteli Tur
En yüksek kapasiteye sahip konumu bulmak için:

var maxCapacity = db.Location.Max(x => x.Capacity);
lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();
En Pahalı Tur
En pahalı konumu bulmak için:
var maxPriceLocation = db.Location.Max(x => x.Price);
lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPriceLocation).Select(y => y.City).FirstOrDefault().ToString();
Ayşegül Çınar Tur Sayısı
Ayşegül Çınar rehberinin yönettiği tur sayısını bulmak için:
var guideIdByNameAysegulCinar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
lblAsyegulCinarLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameAysegulCinar).Count().ToString();
