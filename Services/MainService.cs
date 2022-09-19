﻿using System;
using System.Collections.Generic;

namespace Class_5.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    private readonly IFileService _fileService;
    public MainService(IFileService fileService)
    {
        _fileService = fileService;
        _fileService.Read();
        // don't want to create this dependency here
        //_fileService = new FileService();
    }

    public void Invoke()
    {
        string choice;
        do
        {
            Console.WriteLine("1) Add Movie");
            Console.WriteLine("2) Display All Movies");
            Console.WriteLine("X) Quit");
            choice = Console.ReadLine();

            // Logic would need to exist to validate inputs and data prior to writing to the file
            // You would need to decide where this logic would reside.
            // Is it part of the FileService or some other service?
            if (choice == "1")
            {
                String ans3;
                int temp = 0;
                Console.WriteLine("Enter movie name");
                string ans2 = Console.ReadLine();
                List<string> genres = new List<string>();
                do
                {
                    Console.WriteLine("Enter genre (or done to quit)");
                    ans3 = Console.ReadLine();
                    if (ans3 != "done" && ans3.Length > 0) {
                    genres.Add(ans3);
                    }

                } while (ans3 != "done");

                string genresString = string.Join("|", genres);

                _fileService.Write(temp, ans2, genresString);
            }
            else if (choice == "2")
            {
                _fileService.Read();
                _fileService.Display();
            }
        }
        while (choice != "X");
    }
}
