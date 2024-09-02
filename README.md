
Проект оркестрован посредством docker-compose.
В качестве БД выступает MS SQL.
Использовалась ORM EntityFramework.
Для тестов был выбран NUnit.

---
### Маршруты Контроллера


**По умолчанию все маршруты начинаются с http://localhost:12345**

1. **Метод `Add`**
    
    - **HTTP Метод:** `POST`
    - **Маршрут:** `api/patient`
    - **Описание:** Добавляет новую запись пациента.
    - **Пример Запроса:**
```
POST /api/patient
Content-Type: application/json

{
  "PatientLastName": "Doe",
  "PatientFirstName": "John",
  "PatientPatronymic": "Jr",
  "PatientAddress": "123 Main St",
  "PatientBirthday": "1990-01-01",
  "PatientGender": "M",
  "SectionId": 1
}
```


2. **Метод `Update`**
    
    - **HTTP Метод:** `PUT`
    - **Маршрут:** `api/patient/{id}`
    - **Описание:** Обновляет существующую запись пациента по указанному `id`.
    - **Пример Запроса:**
```
PUT /api/patient/1
Content-Type: application/json

{
  "PatientLastName": "Doe",
  "PatientFirstName": "John",
  "PatientPatronymic": "Jr",
  "PatientAddress": "123 Main St",
  "PatientBirthday": "1990-01-01",
  "PatientGender": "M",
  "SectionId": 1
}
```
3. **Метод `Delete`**
    
    - **HTTP Метод:** `DELETE`
    - **Маршрут:** `api/patient/{id}`
    - **Описание:** Удаляет запись пациента по указанному `id`.
    - **Пример Запроса:**
```
DELETE /api/patient/1
```
        
4. **Метод `Get`**
    
    - **HTTP Метод:** `GET`
    - **Маршрут:** `api/patient/{id}`
    - **Описание:** Получает запись пациента по указанному `id`.
    - **Пример Запроса:**
```
GET /api/patient/1
```
5. **Метод `GetList`**
    
    - **HTTP Метод:** `GET`
    - **Маршрут:** `api/patient`
    - **Описание:** Получает список пациентов с поддержкой сортировки и постраничного возврата данных.
    - **Пример Запроса:**
```
GET /api/patient?sortField=PatientLastName&ascending=true&page=1&pageSize=10
```
    
