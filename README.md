\# TrainingBot



Telegram-бот для учёта силовых тренировок и отслеживания прогресса.  

Позволяет запускать тренировочные сессии, просматривать справочник упражнений и записывать подходы с весом и количеством повторений через REST API.



\---



\## Стек



| Технология | Назначение |

|---|---|

| C# (.NET 10) | Язык и рантайм |

| ASP.NET Core Web API | Серверная часть и обработка HTTP-запросов |

| PostgreSQL | Хранение данных |

| Entity Framework Core | Работа с базой данных (ORM) |

| Telegram.Bot | Взаимодействие с Telegram API |



\---



\## Возможности



| Команда | Статус | Описание |

|---|---|---|

| `/start` | Готово | Регистрация пользователя в системе |

| `/begin` | Готово | Начало новой тренировочной сессии |

| `/exercises` | Готово | Вывод списка доступных упражнений и их ID |

| `/set \[id] \[вес] \[повторения]` | Готово | Запись подхода в рамках активной тренировки |

| `/end` | Готово | Завершение текущей тренировки |

| `/info` | Готово | Справка по доступным командам |



\---



\## Запуск



\### 1. База данных

Установите PostgreSQL и создайте базу данных `tren\_bot\_bd`.  

Укажите строку подключения в файле `TrainingBotCore/appsettings.json`:



```json

"ConnectionStrings": {

&#x20; "DefaultConnection": "Host=localhost;Port=5432;Database=tren\_bot\_bd;Username=postgres;Password=ваш\_пароль"

}

```

Примените миграции Entity Framework Core (или создайте таблицы согласно TrainingDbContext).



2\. Токен бота

Укажите токен от @BotFather в настройках клиента Telegram.TrainingBot (в Program.cs или переменных окружения) и убедитесь, что базовый адрес HttpClient соответствует порту запущенного Web API.



3\. Запуск приложения

Поскольку проект состоит из клиента и сервера, запустите оба проекта (в Visual Studio через настройку Несколько запускаемых проектов или в двух окнах терминала):





\# 1. Запуск Web API

```Bash

dotnet run --project TrainingBotCore

```

\# 2. Запуск Telegram-бота

```

dotnet run --project Telegram.TrainingBot

```

Структура проекта

```



TrainingBot.slnx

├── Telegram.TrainingBot/               # Клиент Telegram-бота (обработка команд и HTTP-запросы к API)

│   ├── DTOs/

│   │   ├── ExerciseDto.cs

│   │   ├── TrainingDto.cs

│   │   ├── UserDto.cs

│   │   └── WorkoutDto.cs

│   └── Program.cs

├── TrainingBotClassLibrary/            # Библиотека классов (модели БД, контекст и сервисы)

│   ├── Data/

│   │   └── TrainingDbContext.cs

│   ├── DTOs/

│   │   └── WorkoutCreateDto.cs

│   ├── Models/

│   │   ├── Exercise.cs

│   │   ├── Training.cs

│   │   ├── User.cs

│   │   └── WorkoutSet.cs

│   └── Services/

│       ├── ExerciseService/

│       │   ├── ExerciseService.cs

│       │   └── IExerciseService.cs

│       ├── TrainingService/

│       │   ├── ITrainingService.cs

│       │   └── TrainingService.cs

│       ├── UserService/

│       │   ├── IUserService.cs

│       │   └── UserService.cs

│       └── WorkoutSetService/

│           ├── IWorkoutService.cs

│           └── WorkoutService.cs

├── TrainingBotCore/                    # ASP.NET Core Web API

│   ├── Controllers/

│   │   ├── ExerciseController.cs

│   │   ├── TrainingController.cs

│   │   ├── UserController.cs

│   │   └── WorkoutController.cs

│   ├── appsettings.json

│   └── Program.cs

└── README.md

```

