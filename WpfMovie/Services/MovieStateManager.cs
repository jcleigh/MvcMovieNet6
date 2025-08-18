using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using WpfMovie.Models;

namespace WpfMovie.Services
{
    public class MovieStateManager
    {
        /// <summary>
        /// Uses binaryFormatter to serialize the object, and return a string that is base64 encoded
        /// </summary>
        /// <param name="anyMovie"></param>
        /// <returns></returns>
        public string Serialize(Movie anyMovie)
        {
            // TODO: This replaces BinaryFormatter with System.Text.Json. This will not deserialize old binary data.
            // Proposal fix for SYSLIB0011
            var options = new JsonSerializerOptions { WriteIndented = false };
            {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(anyMovie, options)));
            }

        }

        /// <summary>
        /// Reverses the serialize operation to recreate a movie object
        /// </summary>
        /// <param name="movieString"></param>
        /// <returns></returns>
        public Movie Deserialize(string movieString)
        {
            // TODO: This replaces BinaryFormatter with System.Text.Json. This will not deserialize old binary data.
            // Proposal fix for SYSLIB0011
            var options = new JsonSerializerOptions { WriteIndented = false };
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(movieString));
            return JsonSerializer.Deserialize<Movie>(json, options);
        }
    }
}