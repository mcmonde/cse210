using System;
using System.Collections.Generic;

namespace Foundation1
{

    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store videos
            List<Video> videos = new List<Video>();

            // Create and add videos to the list
            Video video1 = new Video("C# Tutorial", "John Doe", 600);
            video1.AddComment(new Comment("Alice", "Great tutorial!"));
            video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
            video1.AddComment(new Comment("Charlie", "Can you do one on LINQ?"));

            Video video2 = new Video("Cooking Basics", "Jane Smith", 1200);
            video2.AddComment(new Comment("Dave", "Love this recipe!"));
            video2.AddComment(new Comment("Eve", "Can't wait to try this."));
            video2.AddComment(new Comment("Frank", "Looks delicious!"));

            Video video3 = new Video("Travel Vlog: Japan", "Mike Johnson", 1800);
            video3.AddComment(new Comment("Grace", "Amazing footage!"));
            video3.AddComment(new Comment("Hannah", "Japan is on my bucket list now."));
            video3.AddComment(new Comment("Ian", "Great editing skills!"));

            videos.Add(video1);
            videos.Add(video2);
            videos.Add(video3);

            foreach (var video in videos) {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

                foreach (var comment in video.GetComments()) {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }
                
                Console.WriteLine(); // Blank line for better readability
            }
        }
    }
}
