using System.Collections;
using System.Collections.Generic;

public class DrinkTypes
{
    static Dictionary<string, int[]> _types = null;
    public static Dictionary<string, int[]> Types
    {
        get { if (_types == null) GenerateTypes(); return _types; }
    }

    static void GenerateTypes()
    {
        _types = new Dictionary<string, int[]>();
        //int sugarLevel, int drinkKopi, int drinkTeh, int milkCondensed, int milkEvaporated, int iceLevel
        // kopi variants
        _types.Add("kopi o", new int[] { 2, 1, 0, 0, 0, 0 });
        _types.Add("kopi", new int[] { 2, 1, 0, 1, 0, 0 });
        _types.Add("kopi gau", new int[] { 2, 2, 0, 0, 0, 0 });
        _types.Add("kopi o gau", new int[] { 2, 2, 0, 1, 0, 0 });
        _types.Add("kopi siew dai", new int[] { 1, 1, 0, 1, 0, 0 });
        _types.Add("kopi c siew dai", new int[] {1, 1, 0, 0, 1, 0});
        _types.Add("kopi o siew dai", new int[] { 1, 1, 0, 0, 0, 0 });
        _types.Add("kopi c", new int[] { 2, 1, 0, 0, 1, 0 });
        _types.Add("kopi c kosong", new int[] { 0, 1, 0, 0, 1, 0 });
        _types.Add("kopi kosong", new int[] { 0, 1, 0, 1, 0, 0 });
        _types.Add("kopi o kosong", new int[] { 0, 1, 0, 0, 0, 0 });
        
        // kopi peng variants
        _types.Add("kopi o peng", new int[] { 2, 1, 0, 0, 0, 1 });
        _types.Add("kopi peng", new int[] { 2, 1, 0, 1, 0, 1 });
        _types.Add("kopi gau peng", new int[] { 2, 2, 0, 0, 0, 1 });
        _types.Add("kopi o gau peng", new int[] { 2, 2, 0, 1, 0, 1 });
        _types.Add("kopi peng siew dai", new int[] { 1, 1, 0, 1, 0, 1 });
        _types.Add("kopi c peng siew dai", new int[] {1, 1, 0, 0, 1, 1});
        _types.Add("kopi o peng siew dai", new int[] { 1, 1, 0, 0, 0, 1 });
        _types.Add("kopi c peng", new int[] { 2, 1, 0, 0, 1, 1 });
        _types.Add("kopi c kosong peng", new int[] { 0, 1, 0, 0, 1, 1 });
        _types.Add("kopi kosong peng", new int[] { 0, 1, 0, 1, 0, 1 });
        _types.Add("kopi o kosong peng", new int[] { 0, 1, 0, 0, 0, 1 });

        // teh variants
        _types.Add("teh o", new int[] { 2, 0, 1, 0, 0, 0 });
        _types.Add("teh", new int[] { 2, 0, 1, 1, 0, 0 });
        _types.Add("teh gau", new int[] { 2, 0, 2, 0, 0, 0 });
        _types.Add("teh o gau", new int[] { 2, 0, 2, 1, 0, 0 });
        _types.Add("teh siew dai", new int[] { 1, 0, 1, 1, 0, 0 });
        _types.Add("teh c siew dai", new int[] {1, 0, 1, 0, 1, 0});
        _types.Add("teh o siew dai", new int[] { 1, 0, 1, 0, 0, 0 });
        _types.Add("teh c", new int[] { 2, 0, 1, 0, 1, 0 });
        _types.Add("teh c kosong", new int[] { 0, 0, 1, 0, 1, 0 });
        _types.Add("teh kosong", new int[] { 0, 0, 1, 1, 0, 0 });
        _types.Add("teh o kosong", new int[] { 0, 0, 1, 0, 0, 0 });

        // teh peng variants
        _types.Add("teh o peng", new int[] { 2, 0, 1, 0, 0, 1 });
        _types.Add("teh peng", new int[] { 2, 0, 1, 1, 0, 1 });
        _types.Add("teh gau peng", new int[] { 2, 0, 2, 0, 0, 1 });
        _types.Add("teh o gau peng", new int[] { 2, 0, 2, 1, 0, 1 });
        _types.Add("teh peng siew dai", new int[] { 1, 0, 1, 1, 0, 1 });
        _types.Add("teh c peng siew dai", new int[] {1, 0, 1, 0, 1, 1});
        _types.Add("teh o peng siew dai", new int[] { 1, 0, 1, 0, 0, 1 });
        _types.Add("teh c peng", new int[] { 2, 0, 1, 0, 1, 1 });
        _types.Add("teh c kosong peng", new int[] { 0, 0, 1, 0, 1, 1 });
        _types.Add("teh kosong peng", new int[] { 0, 0, 1, 1, 0, 1 });
        _types.Add("teh o kosong peng", new int[] { 0, 0, 1, 0, 0, 1 });
    }
}
