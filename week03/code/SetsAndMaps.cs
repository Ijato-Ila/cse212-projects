using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var results = new List<string>();

        foreach (var word in words)
        {
            if (word.Length != 2) continue;
            if (word[0] == word[1]) continue; // skip "aa", "bb", etc.

            var reversed = new string(new[] { word[1], word[0] });

            if (seen.Contains(reversed))
            {
                results.Add($"{word} & {reversed}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return results.ToArray();
    }

    // Problem 2
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length >= 4)
            {
                var degree = fields[3].Trim();
                if (!degrees.ContainsKey(degree))
                {
                    degrees[degree] = 0;
                }
                degrees[degree]++;
            }
        }
        return degrees;
    }

    // Problem 3
    public static bool IsAnagram(string word1, string word2)
    {
        var w1 = word1.Replace(" ", "").ToLower();
        var w2 = word2.Replace(" ", "").ToLower();

        if (w1.Length != w2.Length) return false;

        var freq = new Dictionary<char, int>();
        foreach (var c in w1)
        {
            if (!freq.ContainsKey(c)) freq[c] = 0;
            freq[c]++;
        }

        foreach (var c in w2)
        {
            if (!freq.ContainsKey(c)) return false;
            freq[c]--;
            if (freq[c] < 0) return false;
        }

        return true;
    }

    // Problem 5
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var response = client.Send(new HttpRequestMessage(HttpMethod.Get, uri));
        using var jsonStream = response.Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var results = new List<string>();
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                var place = feature.Properties.Place;
                var mag = feature.Properties.Mag;
                results.Add($"{place} - Mag {mag}");
            }
        }

        return results.ToArray();
    }
}
