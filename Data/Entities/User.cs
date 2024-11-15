﻿namespace Data.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public required string Username { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
}