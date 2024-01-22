namespace Vlogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> theVlogger = new();

            string[] newActivity;
            while ((newActivity = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries))[0] != "Statistics")
            {
                string firstVlogger = newActivity[0];
                string action = newActivity[1];
                string secondVlogger = newActivity[2];

                if (action == "joined")
                {
                    if (theVlogger.ContainsKey(firstVlogger) == false)
                    {
                        var newVlogger = new Vlogger(firstVlogger, new SortedSet<string>(), new SortedSet<string>());
                        theVlogger.Add(firstVlogger, newVlogger);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (action == "followed")
                {
                    if (CheckIfCanFollow(theVlogger, firstVlogger, secondVlogger))
                    {
                        theVlogger[secondVlogger].Followers.Add(theVlogger[firstVlogger].Name);
                        theVlogger[firstVlogger].Following.Add(theVlogger[secondVlogger].Name);
                    }

                    continue;
                }

            }

      var theMostFamous = theVlogger
                .OrderByDescending(v => v.Value.Followers.Count)
                .ThenBy(v => v.Value.Following.Count)
                .FirstOrDefault();

            Console.WriteLine($"The V-Logger has a total of {theVlogger.Keys.Count} vloggers in its logs.");

            int index = 1;
            Console.WriteLine($"{index}. {theMostFamous.Value.Name} : " +
                              $"{theMostFamous.Value.Followers.Count} followers" +
                              $"{theMostFamous.Value.Following.Count} following");
            foreach (var follower in theMostFamous.Value.Followers)
            {
                Console.WriteLine($"* {follower}");
            }

            theVlogger.Remove(theMostFamous.Value.Name);

            foreach (var vlogger in
                     theVlogger.OrderByDescending(v => v.Value.Followers.Count)
                         .ThenBy(v => v.Value.Following.Count))
            {
                Console.WriteLine($"{++index}. {vlogger.Value.Name} : {vlogger.Value.Followers.Count} followers " +
                                  $"{vlogger.Value.Following.Count} following");
            }

        }

        private static bool CheckIfCanFollow(Dictionary<string, Vlogger> theVlogger, string firstVlogger, string secondVlogger)
        {
            bool returnVal = theVlogger.ContainsKey(firstVlogger)
                   && theVlogger.ContainsKey(secondVlogger) 
                   && firstVlogger != secondVlogger;

            return returnVal;
        }
    }

    class Vlogger
    {
        public Vlogger(string name, SortedSet<string> followers, SortedSet<string> following)
        {
            Name = name;
            Followers = followers;
            Following = following;
        }

        public string Name { get; set; }
        public SortedSet<string> Followers { get; set; }
        public SortedSet<string> Following { get; set; }
    }
}
