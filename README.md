# Yusufislamyetkin-Homework2

Microservice Mimari’lerde Transaction Yönetimi.

Microservice'lerde transaction yönetiminin iki yönetimini inceleyeceğiz. Bu yöntemeler arasında uygun olanı seçip uygulamak gerekir.

1- Two-Phase Commit (2PC)

Bir örnek üzerinden anlatmanın daha doğru olduğunu düşünüyorum. Bir E-ticaret örneğinden gideceğiz. Stok kontrolü ve ödeme sisteminin transaction’larını ele alalım. Two-Phase commit yönetiminin ilk örnek fazında koordinatör transactionları inceler ve commite hazır olup olmadıklarına bakar. Eğer ikisi de commit edilmeye hazırsa işlem tamamlanır ve diske yazılır. Hata durumunu ele alırsak eğer transactionlarda commit aşamasında işlem tamamlanmazsa commit edilmeye hazır değilse iki transaction da iptal edilir. Bir bütün olarak iptal işlemi sağlanılmış olur.

2- Saga Pattern

İlk olarak 1987 yılında akademik bir makale ile ortaya atılmıştır. Saga pattern'de her trancsaction ayrı bir konumda tutulur. Birbirinden bağımsız olarak çalışırlar. Yürütme aşamasında her servis teker teker yönetilir, işlemi tamamlanan bir sonraki trasactiona yönlendirir. Bu şekilde en sonuncu transaction'a kadar varılır ve son servis de işlendiğinde olay tamamlanır. Hata durumunda ise hatanın alındığı yerde hata alındı olarak işaretlenir. işlemin durumu başarısız olarak güncellenir.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------


Uygulama Ödevi : Patika Bootcamp Web Api #net6

Proje 2 farklı web api controller'a sahip (tek projede). Birisi katılımcıların süreçlerini, diğeri admin fonksiyonlarını handle eder. Rest standartları göz önüne alınmıştır. 

*Proje UI'a sahip değildir. Sadece api .


--BootCampApiController

-Bootcamp Listele (Aktif/Geçmiş)
-Bootcamp Getir
-Bootcampe Katıl


--AdminApiController

-Bootcamp Kaydet
-Bootcamp Sil
-Katılımcı Onayla
-Katılımcı Sil

