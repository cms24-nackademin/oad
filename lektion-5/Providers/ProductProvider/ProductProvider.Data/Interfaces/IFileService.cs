﻿namespace ProductProvider.Data.Interfaces;

public interface IFileService
{
    public bool SaveToFile(string filePath, string content);

    public string GetContentFromFile(string filePath);
}
