﻿namespace ChuckNorrisService.Models;

public class Joke
{
    public string Id { get; set; }
    public string Value { get; set; }
}

public record JokeAsRecord(string Id, string Value);
