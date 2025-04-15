# PhoneBookApp Web Panel

Bu proje, PhoneBookApp mikroservis yapısına bağlı olarak çalışan web tabanlı bir rehber yönetim panelidir. Vue.js ve Bootstrap kullanılarak geliştirilmiştir.

## Başlatma Adımları

Projeyi çalıştırmadan önce aşağıdaki adımları sırasıyla uygulayın.

### 1. Docker servislerini başlat

Root dizinindeyken aşağıdaki komutu çalıştırarak PostgreSQL, RabbitMQ, API servisleri ve Gateway’i ayağa kaldırın:

````
docker-compose up --build -d
````

### 2. Web projesi dizinine geç

````
cd web/
````


### 3. Bağımlılıkları yükle

Vue.js projesi için gerekli olan bağımlılıkları yükleyin:

````
npm install
````


### 4. Uygulamayı başlat

Geliştirme ortamında uygulamayı çalıştırmak için:

````
npm run dev
````


## Tarayıcıdan Erişim

Uygulama başlatıldıktan sonra aşağıdaki adres üzerinden erişim sağlayabilirsiniz:

````
http://localhost:5173
````


## Ek Bilgiler

- Web panel, Gateway üzerinden Contact ve Report API'lerle iletişim kurar.
- Bootstrap grid sistemi kullanılarak responsive yapı sağlanmıştır.
