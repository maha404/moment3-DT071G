// Kod skriven av: Maria Halvarsson - DT071G
using System.Collections;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace moment3
{
    public class Post
    {

        public string Author { get; set; } 
        public string Content { get; set; }
        
        // Constructor
        public Post(string author, string content) 
        {
            this.Author = author;
            this.Content = content;
        }

        // Skriva ett inlägg
        public static void WritePost()
        {
            // Sökväg till json-filen. 
            string path = @"C:\Users\Maria\OneDrive\Skrivbord\Programmering med c#\Moment 3\moment3\posts.json";

           List<Post> posts = GetPosts(path);
           
           Console.WriteLine("-- Skriv ditt inlägg --");
           Console.WriteLine();

           Console.WriteLine("Skriv in ditt namn:");
           string? author = Console.ReadLine();


           Console.WriteLine("Skriv ditt inlägg:");
           string? content = Console.ReadLine();

           var post = new Post(author, content);

            // Kollar om author eller content är tom 
           if(string.IsNullOrEmpty(author) || string.IsNullOrEmpty(content)) {
                Console.WriteLine("Fälten får inte vara tomma!");
                Console.WriteLine();
                WritePost(); // Skriver om denna method
           } else {
                Console.WriteLine($"{author} - {content}");

                // Lägger till post till listan posts
                posts.Add(post);

                // Skickar posts vidare till SavePosts
                SavePosts(posts);
                Console.Clear();
                Program.Main();
           }
        }


        // Hämta alla inlägg
        public static List<Post> GetPosts(string path) 
        {

        if(new FileInfo("posts.json").Length != 0) { // Kollar om filen inte är lika med 0, dvs tom. 
            if(File.Exists(path)) { // Kollar om filen finns med angiven sökväg
                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
            }
        } 
            return new List<Post>();
        }

        // Spara ett inlägg
        public static void SavePosts(List<Post> posts) 
         {

            string path = @"C:\Users\Maria\OneDrive\Skrivbord\Programmering med c#\Moment 3\moment3\posts.json";

            var jsonString = JsonSerializer.Serialize(posts, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // För att kunna spara specialtecken, åäö. 
            });

            File.WriteAllText(path, jsonString);

         }

        // Radera ett inlägg
         public static void DeletePost() 
        {
            string path = @"C:\Users\Maria\OneDrive\Skrivbord\Programmering med c#\Moment 3\moment3\posts.json";
            
            List<Post> posts = GetPosts(path); // Hämtar in alla poster

            Console.WriteLine("Skriv siffran på inlägget som du vill ta bort");
            
            string ? answer = Console.ReadLine();
            // Check för att kolla om fältet är tomt eller inte
            if(string.IsNullOrEmpty(answer)) {
                Console.WriteLine("Fälten får inte vara tomma!");
                Console.WriteLine();
                DeletePost();
            } else {
                // Tar bort post beroende på nummer (index) från posts listan. 
                posts.RemoveAt(Convert.ToInt32(answer));
                SavePosts(posts);
                Console.WriteLine("Inlägget har tagits bort!");
                Console.Clear();
                Program.Main();
            }
           
        }

        
    }
    
}