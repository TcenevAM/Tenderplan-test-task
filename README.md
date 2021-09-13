## Описание

  Тестовое задание для компании tenderplan
## Установка

  - В проекте AuthenticationAPI в appsetings.json ввести строку подключения к postgre бд. Вписать ключи для создания jwt в категорию SecurityKey и refresh token в категорию RefreshKey.
  Задать время жизни этих токенов. Изначально жизнь jwt измеряется в минутах, rt в днях
  - В проекте TenderplanTestTask в appsetings.json ввести строку подключения бд из прошлого пункта. Вставить SecurityKey из прошлого пункта
