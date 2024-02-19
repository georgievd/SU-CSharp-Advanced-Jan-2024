namespace Ranking
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, string> contests = new ();
            List<Intern> interns = new ();

            string newContest;
            while ((newContest = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = newContest.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contestName = tokens[0];
                string contestPass = tokens[1];

                contests[contestName] = contestPass;
            }

            string submission;
            while ((submission = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = submission.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contestName = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (!contests.ContainsKey(contestName) || contests[contestName] != password) continue;
                if (interns.Any(i => i.Name == username))
                {
                    var intern = interns.First(i => i.Name == username);
                    if (intern.Contests.TryAdd(contestName, points)) continue;
                    if (intern.Contests[contestName] >= points) continue;

                    intern.Contests[contestName] = points;
                }
                else
                {
                    var newIntern = new Intern(username, new Dictionary<string, int>());
                    newIntern.Contests.Add(contestName, points);

                    interns.Add(newIntern);
                }
            }

            var bestCandidate = interns.MaxBy(x => x.Contests.Values.Sum());
            Console.WriteLine($"Best candidate is {bestCandidate.Name} with total" +
                              $" {bestCandidate.Contests.Values.Sum()} points.");

            Console.WriteLine("Ranking: ");

            foreach (var intern in interns.OrderBy(x => x.Name))
            {
                Console.WriteLine(intern.Name);
                foreach (var contest in intern.Contests
                             .OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
        class Intern
        {
            public Intern(string name, Dictionary<string, int> contests)
            {
                Name = name;
                Contests = contests;
            }

            public string Name { get; set; }
            public Dictionary<string, int> Contests { get; set; }
        }
    }
}
