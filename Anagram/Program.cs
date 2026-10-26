namespace Algoritm;

//Key -> List<string>

//aet -> eat/tea/ate
//ant -> tan/nat
//abt -> bat
public IList<IList<string>> GroupAnagrams(string[] strs)
{
    Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

    foreach (var str in strs)
    {
        var chars = str.ToCharArray();
        Array.Sort(chars);

        var key = chars.ToString();

        if (!dictionary.TryGetValue(key, out List<string> v))
        {
            v = new List<string>();
            dictionary[key] = v; 
        }

        v.Add(str);
    }

    return dictionary.Values.ToList<IList<string>>();
}

