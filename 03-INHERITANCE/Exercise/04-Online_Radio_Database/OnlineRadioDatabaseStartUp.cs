using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_OnlineRadioDatabase
    {
    class OnlineRadioDatabaseStartUp
        {
        static void Main(string[] args)
            {
            var numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            int playlistLenghtInSeconds = 0;
            int plHours = 0, plMin = 0, plSec = 0;

            for (int i = 0; i < numberOfSongs; i++)
                {
                try
                    {
                    var inputSongInfo = Console.ReadLine().Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    var artistName = inputSongInfo[0];
                    var songName = inputSongInfo[1];
                    var minSec = inputSongInfo[2]
                        .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    var song = new Song(artistName, songName, minSec[0], minSec[1]);
                    songs.Add(song);
                    playlistLenghtInSeconds += minSec[0] * 60 + minSec[1];
                    Console.WriteLine("Song added.");
                    }
                catch (Exception ex)
                    {
                    Console.WriteLine(ex.Message);
                    }
                }

            Console.WriteLine($"Songs added: {songs.Count}");

            plHours = playlistLenghtInSeconds / 3600;
            plMin = (playlistLenghtInSeconds % 3600) / 60;
            plSec = ((playlistLenghtInSeconds % 3600) % 60) % 60;

            Console.WriteLine($"Playlist length: {plHours}h {plMin}m {plSec}s");

            }
        }
    }
