namespace Task3;

public class PrintQueue
{
    private List<PrintJob> _jobs = new(); // черга заявок
    private List<PrintLogEntry> _log = new(); // журнал друку
    
    public void AddJob(PrintJob job) // додати завдання у чергу
    {
        _jobs.Add(job);
        Console.WriteLine($"[+] Завдання додано: {job.User} – {job.Document} (Пріоритет: {job.Priority})");
    }
    
    public void ProcessNextJob() // друк
    {
        if (_jobs.Count == 0)
        {
            Console.WriteLine("Черга порожня.");
            return;
        }
        
        var nextJob = _jobs.OrderByDescending(j => j.Priority).First(); // вибираємо завдання з найбільшим пріоритетом
        _jobs.Remove(nextJob);
        
        Console.WriteLine($"[Друк] {nextJob.User} – {nextJob.Document}"); 
        
        _log.Add(new PrintLogEntry(nextJob.User, nextJob.Document, DateTime.Now)); // додаємо запис у статистику
    }
    
    public void ShowLog()
    {
        Console.WriteLine("\n=== Статистика друку ===");
        foreach (var entry in _log)
        {
            Console.WriteLine($"{entry.TimePrinted:HH:mm:ss} | {entry.User} – {entry.Document}");
        }
    }
    
    public void SaveLogToFile(string filePath) 
    {
        using var writer = new StreamWriter(filePath);
        writer.WriteLine("=== Статистика друку ===");
        foreach (var entry in _log)
        {
            writer.WriteLine($"{entry.TimePrinted:HH:mm:ss} | {entry.User} – {entry.Document}");
        }
        Console.WriteLine($"Статистика збережена у файл: {filePath}");
    }
}