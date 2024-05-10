// By Jake Kirkman and Brian Chavez
// a cute little program ^.^
// vinyl stack class for music records
using System;
using System.Collections.Generic;
class VinylStack
{
    // default constructor 
    public VinylStack() { }

    private List<List<object>> vinylList = new List<List<object>>();
    private List<List<object>> played = new List<List<object>>();

    // push - put a disc on the vinyl stack
    public void Push(List<object> vinyl)
    {
        vinylList.Insert(0, vinyl);
    }

    // poll - view item on the top of the stack and return the name
    public string Poll()
    {
        if (vinylList.Count > 0)
            return vinylList[0][0].ToString();
        else
            return "The vinyl stack is empty!";
    }

    // pop - return the disc, play it, and remove it, will display song name
    public void Pop()
    {
        for (int i = 1; i < vinylList[0].Count; i += 2)
        {
            if ((int)vinylList[0][i] == 37)
                Thread.Sleep((int)vinylList[0][i + 1]);
            else
                Console.Beep((int)vinylList[0][i], (int)vinylList[0][i + 1]);
        }
        played.Add(vinylList[0]);

        vinylList.RemoveAt(0);
    }

    // remove - get rid of the top record without playing it
    public void Remove()
    {
        played.Add(vinylList[0]);
        vinylList.RemoveAt(0);
    }
    // vinylStorage - stores popped discs in case you want to use them later
    public bool VinylStorage()
    {
        Console.Write("Select a song to replay: ");
        string replaySong = Console.ReadLine();

        for (int i = 0; i < played.Count; i++)
        {
            if (played[i][0].ToString() == replaySong)
            {
                for (int j = 1; j < played[i].Count; j += 2)
                {
                    if ((int)played[i][j] == 37)
                        Thread.Sleep((int)played[i][j + 1]);
                    else
                        Console.Beep((int)played[i][j], (int)played[i][j + 1]);
                }
                return true;
            }
        }
        return false;
    }

    public bool StackIsEmpty()
    {
        if (vinylList.Count == 0)
        {
            return true;
        }
        else
            return false;
    }

    public bool HistoryIsEmpty()
    {
        if (played.Count == 0)
        {
            return true;
        }
        else
            return false;
    }

    //public void vinylRecords()
    //{
    //    Console.WriteLine("- " + vinylList[0][0]);
    //    Console.WriteLine();
    //}

    public void RecordHistory()
    {
        for (int i = 0; i < played.Count; i++)
            Console.WriteLine("- " + played[i][0]);
        Console.WriteLine();
    }
}

class Frequencies
{
    public int cNat3 = 131;
    public int cSharp3 = 139;
    public int dNat3 = 147;
    public int dSharp3 = 156;
    public int eNat3 = 165;
    public int fNat3 = 175;
    public int fSharp3 = 185;
    public int gNat3 = 196;
    public int gSharp3 = 208;
    public int aNat3 = 220;
    public int aSharp3 = 233;
    public int bNat3 = 247;

    public int cNat4 = 262;
    public int cSharp4 = 277;
    public int dNat4 = 294;
    public int dSharp4 = 311;
    public int eNat4 = 330;
    public int fNat4 = 349;
    public int fSharp4 = 370;
    public int gNat4 = 392;
    public int gSharp4 = 415;
    public int aNat4 = 440;
    public int aSharp4 = 466;
    public int bNat4 = 494;

    public int cNat5 = 523;
    public int cSharp5 = 554;
    public int dNat5 = 587;
    public int dSharp5 = 622;
    public int eNat5 = 659;
    public int fNat5 = 698;
    public int fSharp5 = 740;
    public int gNat5 = 784;
    public int gSharp5 = 831;
    public int aNat5 = 880;
    public int aSharp5 = 932;
    public int bNat5 = 988;
    public int cNat6 = 1047;
    public int dNat6 = 1175;

    public int rest = 37;
    public Frequencies() { }
}

class Notes
{
    public int whole;
    public int dottedHalf;
    public int half;
    public int dottedQuarter;
    public int quarter;
    public int eighth;
    public int sixteenth;
    public int triplet;
    public int halfTriplet;
    public Notes(double bpm) 
    {
        whole = ComputeDuration(4, bpm);
        dottedHalf = ComputeDuration(3, bpm);
        half = ComputeDuration(2, bpm);
        dottedQuarter = ComputeDuration(1.5, bpm);
        quarter = ComputeDuration(1, bpm);
        eighth = ComputeDuration(0.5, bpm);
        sixteenth = ComputeDuration(0.25, bpm);
        triplet = ComputeDuration(0.33, bpm);
        halfTriplet = ComputeDuration(0.17, bpm);
    }

    private int ComputeDuration(double theNote, double theBPM)
    {
        double duration = ((60 / theBPM) * (theNote)) * 1000;
        int noteDuration = (int)Math.Round(duration);
        return noteDuration;
    }
}

class RecordPlayer
{
    static int Main(string[] args)
    {
        VinylStack jukeBox = new VinylStack();
        Frequencies pitch = new Frequencies();

        // get note length for each song
        double takeOnMeBPM = 165;
        double rainsOfCastamereBPM = 100;
        double marioThemeBPM = 100;
        double megalovaniaBPM = 120;
        Notes TOMNotes = new Notes(takeOnMeBPM);
        Notes ROCNotes = new Notes(rainsOfCastamereBPM);
        Notes MTNotes = new Notes(marioThemeBPM);
        Notes MLVNotes = new Notes(megalovaniaBPM);

        List<object> marioTheme = new List<object>() { "1-1", pitch.eNat5,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth,
            pitch.rest, MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.rest,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth,
            pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.eNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.aNat4,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth,
            pitch.bNat4,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.aSharp4,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.gNat4,MTNotes.triplet, pitch.cNat5,MTNotes.triplet, pitch.eNat5,MTNotes.triplet,
            pitch.aNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.gNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.dNat5,MTNotes.sixteenth, pitch.bNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.rest,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth,
            pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.eNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.aNat4,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth,
            pitch.bNat4,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.aSharp4,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.gNat4,MTNotes.triplet, pitch.cNat5,MTNotes.triplet, pitch.eNat5,MTNotes.triplet,
            pitch.aNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.gNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.dNat5,MTNotes.sixteenth, pitch.bNat4,MTNotes.sixteenth, pitch.rest,MTNotes.quarter, pitch.gNat5,MTNotes.sixteenth, pitch.fSharp5,MTNotes.sixteenth,
            pitch.fNat5,MTNotes.sixteenth, pitch.dSharp5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth,
            pitch.aNat4,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth,
            pitch.dNat5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.gNat5,MTNotes.sixteenth, pitch.fSharp5,MTNotes.sixteenth,pitch.fNat5,MTNotes.sixteenth, pitch.dSharp5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.cNat6,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.cNat6,MTNotes.sixteenth, pitch.cNat6,MTNotes.sixteenth, pitch.rest,MTNotes.quarter,
            pitch.gNat5,MTNotes.sixteenth, pitch.fSharp5,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.dSharp5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth,
            pitch.aNat4,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth,
            pitch.dNat5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.dSharp5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.dNat5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth,
            pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.gNat4,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.cNat4,MTNotes.sixteenth, pitch.rest,MTNotes.quarter,
            pitch.gNat5,MTNotes.sixteenth, pitch.fSharp5,MTNotes.sixteenth,
            pitch.fNat5,MTNotes.sixteenth, pitch.dSharp5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth,
            pitch.aNat4,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth,
            pitch.dNat5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.gNat5,MTNotes.sixteenth, pitch.fSharp5,MTNotes.sixteenth,pitch.fNat5,MTNotes.sixteenth, pitch.dSharp5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.cNat6,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.cNat6,MTNotes.sixteenth, pitch.cNat6,MTNotes.sixteenth, pitch.rest,MTNotes.quarter,
            pitch.gNat5,MTNotes.sixteenth, pitch.fSharp5,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.dSharp5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth,
            pitch.aNat4,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth,
            pitch.dNat5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.dSharp5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.dNat5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth,
            pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.dottedQuarter, pitch.cNat5,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.dNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.cNat5,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.dNat5,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth, pitch.rest,MTNotes.half, pitch.cNat5,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.dNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.eNat5,MTNotes.sixteenth,
            pitch.eNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.gNat5,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.rest,MTNotes.sixteenth,
            pitch.eNat5,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.gSharp4,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth,
            pitch.rest,MTNotes.eighth, pitch.rest,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.aNat5,MTNotes.sixteenth, pitch.rest,MTNotes.halfTriplet, pitch.aNat5,MTNotes.triplet,
            pitch.aNat5,MTNotes.triplet, pitch.gNat5,MTNotes.triplet, pitch.fNat5,MTNotes.triplet, pitch.eNat5,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth,
            pitch.aNat4,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.rest,MTNotes.sixteenth,  pitch.eNat5,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.gSharp4,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth,
            pitch.rest,MTNotes.eighth, pitch.rest,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.bNat4,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.rest,MTNotes.halfTriplet,
            pitch.fNat5,MTNotes.triplet, pitch.fNat5,MTNotes.triplet, pitch.eNat5,MTNotes.triplet, pitch.dNat5,MTNotes.triplet, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.dottedQuarter,
            pitch.rest,MTNotes.sixteenth, pitch.eNat5,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.gSharp4,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth,
            pitch.rest,MTNotes.eighth, pitch.rest,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.aNat5,MTNotes.sixteenth, pitch.rest,MTNotes.halfTriplet, pitch.aNat5,MTNotes.triplet,
            pitch.aNat5,MTNotes.triplet, pitch.gNat5,MTNotes.triplet, pitch.fNat5,MTNotes.triplet, pitch.eNat5,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth,
            pitch.aNat4,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.rest,MTNotes.sixteenth,  pitch.eNat5,MTNotes.sixteenth, pitch.cNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.gSharp4,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.rest,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth,
            pitch.rest,MTNotes.eighth, pitch.rest,MTNotes.sixteenth, pitch.aNat4,MTNotes.sixteenth, pitch.bNat4,MTNotes.sixteenth, pitch.fNat5,MTNotes.sixteenth, pitch.rest,MTNotes.halfTriplet,
            pitch.fNat5,MTNotes.triplet, pitch.fNat5,MTNotes.triplet, pitch.eNat5,MTNotes.triplet, pitch.dNat5,MTNotes.triplet, pitch.cNat5,MTNotes.sixteenth, pitch.gNat4,MTNotes.sixteenth,
            pitch.rest,MTNotes.sixteenth, pitch.eNat4,MTNotes.sixteenth, pitch.cNat4,MTNotes.sixteenth, pitch.rest,MTNotes.eighth, pitch.rest,MTNotes.sixteenth };

        List<object> takeOnMe = new List<object>() { "Take On Me", pitch.fSharp5,TOMNotes.eighth, pitch.fSharp5,TOMNotes.eighth, pitch.dNat5,TOMNotes.eighth, pitch.bNat4,TOMNotes.eighth, pitch.rest,TOMNotes.eighth,
            pitch.bNat4,TOMNotes.eighth, pitch.rest,TOMNotes.eighth, pitch.eNat5,TOMNotes.eighth, pitch.rest,TOMNotes.eighth, pitch.eNat5,TOMNotes.eighth, pitch.rest,TOMNotes.eighth,
            pitch.eNat5,TOMNotes.eighth, pitch.gSharp5,TOMNotes.eighth, pitch.gSharp5,TOMNotes.eighth, pitch.aNat5,TOMNotes.eighth, pitch.bNat5,TOMNotes.eighth, pitch.aNat5,TOMNotes.eighth,
            pitch.aNat5,TOMNotes.eighth, pitch.aNat5,TOMNotes.eighth, pitch.fSharp5,TOMNotes.eighth, pitch.rest,TOMNotes.eighth, pitch.dNat5,TOMNotes.eighth, pitch.rest,TOMNotes.eighth,
            pitch.fSharp5,TOMNotes.eighth, pitch.rest,TOMNotes.eighth, pitch.fSharp5,TOMNotes.eighth, pitch.rest,TOMNotes.eighth, pitch.fSharp5,TOMNotes.eighth, pitch.eNat5,TOMNotes.eighth,
            pitch.eNat5,TOMNotes.eighth, pitch.fSharp5,TOMNotes.eighth, pitch.eNat5,TOMNotes.eighth };

        List<object> rainsOfCastamere = new List<object>() { "Rains of Castamere", pitch.aNat3,ROCNotes.eighth, pitch.fNat4,ROCNotes.dottedQuarter, pitch.aNat3,ROCNotes.eighth, pitch.eNat4,ROCNotes.dottedQuarter,
            pitch.aNat3,ROCNotes.eighth, pitch.fNat4,ROCNotes.quarter, pitch.gNat4,ROCNotes.quarter, pitch.eNat4,ROCNotes.dottedQuarter, pitch.aNat3,ROCNotes.eighth,
            pitch.gNat4,ROCNotes.quarter, pitch.fNat4,ROCNotes.quarter, pitch.eNat4,ROCNotes.quarter, pitch.dNat4,ROCNotes.quarter, pitch.eNat4,ROCNotes.dottedHalf, pitch.cNat4,ROCNotes.eighth,
            pitch.aNat4,ROCNotes.dottedQuarter, pitch.cNat4,ROCNotes.eighth, pitch.gNat4,ROCNotes.dottedQuarter, pitch.cNat4,ROCNotes.eighth, pitch.aNat4,ROCNotes.quarter,
            pitch.aSharp4,ROCNotes.quarter, pitch.gNat4,ROCNotes.dottedQuarter, pitch.cNat4,ROCNotes.eighth, pitch.aSharp4,ROCNotes.quarter, pitch.aNat4,ROCNotes.quarter,
            pitch.gNat4,ROCNotes.quarter, pitch.fNat4,ROCNotes.quarter, pitch.eNat4,ROCNotes.dottedHalf };

        // because Chris and Brian never played Undertale :)
        List<object> megalovania = new List<object>() { "Megalovania", pitch.dNat5,MLVNotes.sixteenth, pitch.dNat5,MLVNotes.sixteenth, pitch.dNat6,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth, pitch.aNat5,MLVNotes.sixteenth,
            pitch.rest,MLVNotes.eighth, pitch.gSharp5,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth, pitch.gNat5,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth, pitch.fNat5,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth,
            pitch.dNat5,MLVNotes.sixteenth, pitch.fNat5,MLVNotes.sixteenth, pitch.gNat5,MLVNotes.sixteenth, pitch.cNat5,MLVNotes.sixteenth, pitch.cNat5,MLVNotes.sixteenth, pitch.dNat6,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth, pitch.aNat5,MLVNotes.sixteenth,
            pitch.rest,MLVNotes.eighth, pitch.gSharp5,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth, pitch.gNat5,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth, pitch.fNat5,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth,
            pitch.dNat5,MLVNotes.sixteenth, pitch.fNat5,MLVNotes.sixteenth, pitch.gNat5,MLVNotes.sixteenth, pitch.bNat4,MLVNotes.sixteenth, pitch.bNat4,MLVNotes.sixteenth, pitch.dNat6,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth, pitch.aNat5,MLVNotes.sixteenth,
            pitch.rest,MLVNotes.eighth, pitch.gSharp5,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth, pitch.gNat5,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth, pitch.fNat5,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth,
            pitch.dNat5,MLVNotes.sixteenth, pitch.fNat5,MLVNotes.sixteenth, pitch.gNat5,MLVNotes.sixteenth, pitch.aSharp4,MLVNotes.sixteenth, pitch.aSharp4,MLVNotes.sixteenth, pitch.dNat6,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth, pitch.aNat5,MLVNotes.sixteenth,
            pitch.rest,MLVNotes.eighth, pitch.gSharp5,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth, pitch.gNat5,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth, pitch.fNat5,MLVNotes.sixteenth, pitch.rest,MLVNotes.sixteenth,
            pitch.dNat5,MLVNotes.sixteenth, pitch.fNat5,MLVNotes.sixteenth, pitch.gNat5,MLVNotes.sixteenth };

        jukeBox.Push(marioTheme);
        jukeBox.Push(takeOnMe);
        jukeBox.Push(rainsOfCastamere);
        jukeBox.Push(megalovania);

        Console.WriteLine("Welcome to the jukebox!!!");
        Console.WriteLine();
        Console.WriteLine("Type \"top\" to get the record on top of the vinyl stack.");
        Console.WriteLine("Type \"replay\" to play a record again.");
        Console.WriteLine("Type \"remove\" to take the top item off of the stack without playing it.");
        Console.WriteLine("Type \"exit\" to end the program.");
        Console.WriteLine();
        Console.WriteLine("Record on top of the vinyl stack: " + jukeBox.Poll());
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();
        while (choice != "exit")
        {
            if (choice == "top")
                jukeBox.Pop();
            else if (choice == "replay")
            {
                if (!jukeBox.VinylStorage())
                {
                    Console.WriteLine("That record is not in the history");
                }
            }
            else if (choice == "remove")
            {
                Console.WriteLine(jukeBox.Poll() + " was removed and added to the vinyl history.");
                jukeBox.Remove();
            }
            else
            {
                Console.WriteLine("Invalid command...");
            }

            if (choice != "exit")
            {
                Console.WriteLine("Would you like to view the record on top of the vinyl stack?");
                Console.Write("y or n: ");
                string viewRecord = Console.ReadLine();
                if(viewRecord == "y" ) 
                    Console.WriteLine("Record on top of the vinyl stack: " + jukeBox.Poll() + "\n");
                if (!jukeBox.HistoryIsEmpty())
                {
                    Console.WriteLine("Available record history.");
                    jukeBox.RecordHistory();
                }
                Console.Write("Enter a new command (top, replay, remove, or exit): ");
                choice = Console.ReadLine();
            }
            if (choice == "exit")
                Console.WriteLine("Thank you for using the jukebox!");
        }
        return 0;
    }
}
