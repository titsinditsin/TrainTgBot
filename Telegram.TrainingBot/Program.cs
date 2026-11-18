using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using DTOs;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;

string botToken = Environment.GetEnvironmentVariable("BOT_TOKEN");
if (string.IsNullOrEmpty(botToken))
{
    Console.WriteLine("Ошибка: Переменная окружения BOT_TOKEN не найдена!");
    return;
}

var botClient = new TelegramBotClient(botToken);
var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("http://localhost:5069");
var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
{
    try
    {
        if (update.Message is null) return;
        string[] words = update.Message.Text.Split(' ');
        switch (words[0])
        {
            case "/start":
                {
                    var userDto = new UserDto()
                    {
                        TgId = update.Message.Chat.Id,
                        UserName = update.Message.From.FirstName
                    };
                    var response = await httpClient.GetAsync($"/User/{update.Message.Chat.Id}");
                    if (!response.IsSuccessStatusCode)
                    {
                        await httpClient.PostAsJsonAsync("/User", userDto);
                    }
                    await client.SendMessage(update.Message.Chat.Id, $"Здравствуйте, {userDto.UserName} это бот для учёта тренировок!");
                    break;
                }
            case "/begin":
                {
                    await client.SendMessage(update.Message.Chat.Id, "Тренировка начата");
                    await httpClient.PostAsync($"/Training/Start?tgId={update.Message.Chat.Id}", null);
                    break;
                }
            case "/end":
                {
                    await client.SendMessage(update.Message.Chat.Id, "Тренировка завершена, отличная работа!");
                    await httpClient.PutAsync($"/Training/End?tgId={update.Message.Chat.Id}", null);
                    break;
                }
            case "/exercises":
                {
                    var response = await httpClient.GetAsync("/Exercise");
                    string body = await response.Content.ReadAsStringAsync();
                    var exercises = JsonSerializer.Deserialize<List<ExerciseDto>>(body, jsonOptions);
                    var sb = new StringBuilder();
                    sb.AppendLine("Список упражнений:");
                    foreach (var ex in exercises)
                    {
                        sb.AppendLine($"{ex.exId}. {ex.exName} ({ex.muscleGroup})");
                    }
                    await client.SendMessage(update.Message.Chat.Id, sb.ToString());
                    break;
                }
            case "/set":
                {
                    if (words.Length != 4)
                    {
                        await client.SendMessage(update.Message.Chat.Id, "Неверные вводные данные");
                        break;
                    }
                    var response = await httpClient.GetAsync($"/Training/IsActive?tgId={update.Message.Chat.Id}");
                    if (!response.IsSuccessStatusCode)
                    {
                        await client.SendMessage(update.Message.Chat.Id, "Сначала начни тренировку командой /begin!");
                        break;
                    }
                    string body = await response.Content.ReadAsStringAsync();
                    var training = JsonSerializer.Deserialize<TrainingDto>(body, jsonOptions);
                    var workoutDto = new WorkoutDto()
                    {
                        TrId = training.TrId,
                        ExId = int.Parse(words[1]),
                        Weight = int.Parse(words[2]),
                        Times = int.Parse(words[3])
                    };
                    await httpClient.PostAsJsonAsync("/Workout", workoutDto);
                    await client.SendMessage(update.Message.Chat.Id, "Подход записан!");
                    break;
                }
            case "/info":
                {
                    string infoText = "Доступные команды:\n" +
                                      "/start - Регистрация\n" +
                                      "/begin - Начать тренировку\n" +
                                      "/exercises - Список упражнений\n" +
                                      "/set [id] [вес] [повторения] - Записать подход\n" +
                                      "/end - Завершить тренировку";
                    await client.SendMessage(update.Message.Chat.Id, infoText);
                    break;
                }
        }
    }
    catch (Exception ex) 
    {
        await client.SendMessage(update.Message.Chat.Id, $"Ошибка {ex.Message}");
    }
}


/// <summary>
/// Обработчик ошибок Telegram API.
/// </summary>
async Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
{
    Console.WriteLine($"Ошибка Telegram API: {exception.Message}");
    await Task.CompletedTask;
}

//запуск
botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, new ReceiverOptions
    {
    DropPendingUpdates = true
    });
Console.WriteLine("Бот запущен в фоновом режиме");
await Task.Delay(-1);