# Finate - Job Portal Website
### Preview link: <a href="https://preview.themeforest.net/item/finate-job-portal-website-template-using-bootstrap-5/full_screen_preview/34406201?_ga=2.247955969.708615302.1709920698-2127994476.1709359058">Finate</a> 

### Структура сайта в Figma: <a href="https://www.figma.com/file/TEFhNy9vho47LeIh5xMVEe/Untitled?type=design&node-id=0%3A1&mode=design&t=VHaotrmziHAQv3Oi-1">Finate in Figma</a>
## Структура веб-сайта:
  #### На всех страницах:
      1. Навбар с ссылками/Меню бургер
      2. Подписка на рассылку о новых вакансиях/кандидатах
      3. Футер

#### 1. Главная страница:
    1.1. Поиск с фильтрами
    1.2. Популярные категории
    1.3. Недавние опубликованные вакансии
    1.4. Инструкция по пользованию сайтом
    1.5. Лучшие кандидаты

#### 2. Страница с вакансиями:
    2.1. Поиск вакансий c фильтрами
    2.2. Вакансии

#### 3. Страница вакансии:
    3.1. Карточка вакансии
    3.2. Описание вакансии
    3.3. Что надо будет делать на работе?
    3.4. Требования
    3.5. Требования по образованию
    3.6. Рабочие часы
    3.7. Преимущества(Benefits)
    3.8. Statement
    3.9. Откликнуться на вакансию
    3.10. Краткая информация
    3.11. Контакты
    3.12. Тэги

#### 4. Откликнуться на вакансию:
    4.1. Блок с телефоном, почтой и адресом
    4.2. Форма отправки сообщения по почте
    4.3. Карта
  
#### 5. Страница с кандидатами:
    5.1. Поиск кандидатов с фильтрами
    5.2. Кандидаты

#### 6 Страница кандидата:
    6.1. Карточка кандидата
    6.2. О кандидате
    6.3. Образование и Курсы
    6.4. Опыт работы и стажировки
    6.5. Hard и Soft скилы
    6.6. Краткая информация о кандидате
    6.7. Контакты кандидата
    6.8. Поле для связи с кандидатом по почте(Для работадателей и админов)
    6.9. Поле для оценки кандидата

#### 7./8. Логин/Регистрация

#### 9. Админ панель:
    9.1. Статистика(Кол-во зарегистрированных кандидатов/Работадателей,
         кол-во откликов на вакансии/на анкеты кандидатов и т.д.)
    9.2. Блок управления аккаунтами кандидата/работадателя

## Стек технологий:
    1. Бэкенд: ASP.NET Core
      1.1 MediatR(для удобной реализации CQRS)
      1.2 FluentValidation(для удобной валидации запросов и комманд)
      1.3 MicrosoftIdentity + JWT(для удобной реализации Аутентификации, Авторизации и Регистрации)
    2. Фронтенд: RazorView
    3. БД: PostgreSQL
    4. Архитектура приложения: Clean Architecture(Монолит)
  
## Схема БД:
![FinateDB](https://github.com/s1ches/Finate/assets/121990701/2bc5a9a5-d92c-4fd1-b281-87ed1dc21b06)


## Роли
###  1. Кандидат
      Может создать анкету для поиска работы, указать там описание, просматривать вакансии
      и откликаться на них, просматривать анкеты других кандидатов
###  2. Компания
      Может создавать множество вакансий и указывать там описание, просматривать анкеты,
      откликаться на них, просматривать другие вакансии
###  3. Админ
      Не может создавать анкеты кандидата и вакансий, но может смотреть их писать компаниям и кандидатам,
      банить пользователей, удалять вакансии и просматривать статистику работы сайта, просматривать
      отпправленные сообщения пользователей, изменять вакансии и резюме кандидатов
  
