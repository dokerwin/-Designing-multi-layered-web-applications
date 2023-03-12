namespace Hexagonal.Domain.Services.Services.Interfaces;


public interface ILogger <T> 
{
    void LogDebug(string message);
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message);
}