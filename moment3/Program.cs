// Kod skriven av: Maria Halvarsson - DT071G
using System.Collections;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace moment3
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(" - MARIA'S GUESTBOOK - ");
            Console.WriteLine();
            Console.WriteLine("1 - Skriv i gästboken");
            Console.WriteLine("2 - Ta bort inlägg");
            Console.WriteLine();
            Console.WriteLine("x - Avsluta");
            Console.WriteLine();

            string path = @"C:\Users\Maria\OneDrive\Skrivbord\Programmering med c#\Moment 3\moment3\posts.json";
            
            List<Post> posts = Post.GetPosts(path);

            foreach(var post in posts) {
                var index = posts.IndexOf(post);
                Console.WriteLine($"[{index}] {post.Author} - {post.Content}");
            }
            Console.WriteLine();
            
            Console.Write("Vad vill du göra?:");

            switch(Console.ReadLine())
            {
                case "1": 
                    Post.WritePost();
                    break;
                case "2":
                    Post.DeletePost();
                    break;
                case "x":
                return;
            }

        }
    }
}