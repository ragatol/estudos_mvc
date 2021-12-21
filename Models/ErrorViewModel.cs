namespace mvc_test.Models;

using Microsoft.AspNetCore.Mvc;
public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
