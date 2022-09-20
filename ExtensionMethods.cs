using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chorizo
{
    //Add extension method.
    public static class ExtensionMethods
    {
        public static int CountLetter(this string text, char letter)
        {
            return text.Count(n => n == letter);
        }

        public static string? ToJsonString<T>(this T obj, bool indented = true)
        {
            JsonSerializerOptions opt = new()
            {
                WriteIndented = indented
            };
            try
            {
                return JsonSerializer.Serialize(obj, obj!.GetType(), opt);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }
    }
}