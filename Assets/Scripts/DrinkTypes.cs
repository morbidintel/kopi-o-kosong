using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkTypes : MonoBehaviour
{
    public Dictionary<string, int[]> drinkTypes = new Dictionary<string, int[]>();
    public List<string> stage1 = new List<string>();
    public List<string> stage2;
    public List<string> stage3;
    public List<string> stage4;
    public List<string> stage5;

    void Awake()
    {
        //int sugarLevel, int drinkKopi, int drinkTeh, int milkCondensed, int milkEvaporated, int iceLevel
        drinkTypes.Add("kopi o",        new int[] { 2, 1, 0, 0, 0, 0});
        drinkTypes.Add("kopi",          new int[] { 2, 1, 0, 1, 0, 0 });
        drinkTypes.Add("kopi gau",      new int[] { 2, 2, 0, 0, 0, 0 });
        drinkTypes.Add("kopi o gau",    new int[] { 2, 2, 0, 1, 0, 0 });
        drinkTypes.Add("kopi siew dai", new int[] { 1, 1, 0, 1, 0, 0 });
        drinkTypes.Add("kopi o siew dai", new int[] { 1, 1, 0, 0, 0, 0 });
        drinkTypes.Add("kopi c",        new int[] { 2, 1, 0, 0, 1, 0 });
        drinkTypes.Add("kopi c kosong", new int[] { 0, 1, 0, 0, 1, 0 });
        drinkTypes.Add("kopi kosong",   new int[] { 0, 1, 0, 1, 0, 0 });
        drinkTypes.Add("kopi o kosong", new int[] { 0, 1, 0, 0, 0, 0});

        drinkTypes.Add("kopi o peng", new int[] { 2, 1, 0, 0, 0, 1 });
        drinkTypes.Add("kopi peng", new int[] { 2, 1, 0, 1, 0, 1 });
        drinkTypes.Add("kopi gau peng", new int[] { 2, 2, 0, 0, 0, 1 });
        drinkTypes.Add("kopi o gau peng", new int[] { 2, 2, 0, 1, 0, 1 });
        drinkTypes.Add("kopi peng siew dai", new int[] { 1, 1, 0, 1, 0, 1 });
        drinkTypes.Add("kopi o peng siew dai", new int[] { 1, 1, 0, 0, 0, 1 });
        drinkTypes.Add("kopi c peng", new int[] { 2, 1, 0, 0, 1, 1 });
        drinkTypes.Add("kopi c kosong peng", new int[] { 0, 1, 0, 0, 1, 1 });
        drinkTypes.Add("kopi kosong peng", new int[] { 0, 1, 0, 1, 0, 1 });
        drinkTypes.Add("kopi o kosong peng", new int[] {0, 1, 0, 0, 0, 1});

        drinkTypes.Add("teh o",         new int[] { 2, 0, 1, 0, 0, 0 });
        drinkTypes.Add("teh",           new int[] { 2, 0, 1, 1, 0, 0 });
        drinkTypes.Add("teh gau",       new int[] { 2, 0, 2, 0, 0, 0 });
        drinkTypes.Add("teh o gau",     new int[] { 2, 0, 2, 1, 0, 0 });
        drinkTypes.Add("teh siew dai",  new int[] { 1, 0, 1, 1, 0, 0 });
        drinkTypes.Add("teh o siew dai", new int[] { 1, 0, 1, 0, 0, 0 });
        drinkTypes.Add("teh c",         new int[] { 2, 0, 1, 0, 1, 0 });
        drinkTypes.Add("teh c kosong",  new int[] { 0, 0, 1, 0, 1, 0 });
        drinkTypes.Add("teh kosong",    new int[] { 0, 0, 1, 1, 0, 0 });
        drinkTypes.Add("teh o kosong", new int[] {0, 0, 1, 0, 0, 0});

        drinkTypes.Add("teh o peng", new int[] { 2, 0, 1, 0, 0, 1 });
        drinkTypes.Add("teh peng", new int[] { 2, 0, 1, 1, 0, 1 });
        drinkTypes.Add("teh gau peng", new int[] { 2, 0, 2, 0, 0, 1 });
        drinkTypes.Add("teh o gau peng", new int[] { 2, 0, 2, 1, 0, 1 });
        drinkTypes.Add("teh peng siew dai", new int[] { 1, 0, 1, 1, 0, 1 });
        drinkTypes.Add("teh o peng siew dai", new int[] { 1, 0, 1, 0, 0, 1 });
        drinkTypes.Add("teh c peng", new int[] { 2, 0, 1, 0, 1, 1 });
        drinkTypes.Add("teh c kosong peng", new int[] { 0, 0, 1, 0, 1, 1 });
        drinkTypes.Add("teh kosong peng", new int[] { 0, 0, 1, 1, 0, 1 });
        drinkTypes.Add("teh o kosong", new int[] {0, 0, 1, 0, 0, 1});

        stage1.Add("kopi o");
        stage1.Add("kopi");
        stage1.Add("teh o");
        stage1.Add("teh");

        stage2 = new List<string>(stage1);
        stage2.Add("kopi o peng");
        stage2.Add("kopi peng");
        stage2.Add("teh o peng");
        stage2.Add("teh peng");
        stage2.Add("teh siew dai");
        stage2.Add("kopi siew dai");

        stage3 = new List<string>(stage2);
        stage3.Add("teh siew dai peng");
        stage3.Add("kopi siew dai peng");
        stage3.Add("teh gau");
        stage3.Add("teh o gau");
        stage3.Add("kopi gau");
        stage3.Add("kopi o gau");
        stage3.Add("kopi kosong");
        stage3.Add("teh kosong");
        stage3.Add("kopi o kosong");
        stage3.Add("teh o kosong");

        stage4 = new List<string>(stage3);
        //todo: stage 4 and 5
    }
}
