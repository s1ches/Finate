namespace Finate.Application.Interfaces;

public interface IEmailSender
{
    public Task SendEmailAsync(string to, string message, CancellationToken cancellationToken);
}