## **Branch Stratejisi**
Master ve development olmak üzere iki branchimiz var. Her sürüm taglenerek master üzerinden oluşturulmalı.  
Yeni bir feature yeni bir branch üzerinde çalışılacak ve tamamlandığında development branch'ine merge edilmeli. 
Buglar için ayrı bir branch oluşturup fixledikten sonra master’a merge’leyip yeni bir sürüm ile oluşturulmalı.




## CryptoDash Nedir?

CryptoDash free bir coin fiyat servisinden çektiği verileri günlük,haftalık ve aylık chartlar üzerinde kullanıcıya gösteren bir projedir.

## Kurulum

Paylaşılan sürümlerin içerisinde projede kullanılan mssql db backup dosyası üzerinden kendi ortamınızda db'yi restore edip uygulama içerisindeki appsettings içerisinde gerekli connection string ayarlarını yapmalısınız.
CoinApi üzerinden ücretsiz bir üyelik ile apikey alarak yine appsettings(secret.json kullanmanızı öneririm) içerisinde ApiKey alanına girmeniz halinde proje sorunsuz ayağa kalkacaktır.

