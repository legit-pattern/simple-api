using simple_api.Extensions;

namespace simple_api.Engine
{
    public class BoardingCardsHelper
    {
        public List<string> OrganizeBoardingCards(List<string> collection)
        {
            // Example data
            // JSON: [ "GOT-ARN", "HEL-GOT", "CPH-HEL" ]

            var result = new List<string>();

            var resultRaw = new List<KeyValuePair<string, string>>();


            var from = new List<string>();
            var to = new List<string>();

            var dict = new Dictionary<string, string>();

            // Separate data
            foreach (var item in collection)
            {
                var pair = item.Split("-");
                dict.Add(pair[0], pair[1]);

                from.Add(pair[0]);
                to.Add(pair[1]);
            }

            // Add/Find starting point
            foreach (var f in from)
            {
                if (!to.Contains(f))
                {
                    resultRaw.Add(dict.GetEntry(f));
                    break;
                }
            }

            // Add the rest
            var currentBoardingPass = resultRaw[0];
            for (int i = 0; i < dict.Count; i++)
            {
                // Check if the current boarding pass' departure has a destination (Ask for permission)
                if (from.Contains(currentBoardingPass.Value))
                {
                    currentBoardingPass = dict.GetEntry(currentBoardingPass.Value);
                    resultRaw.Add(currentBoardingPass);
                }
            }

            // Clean up so we can present nicely :) 
            foreach (var item in resultRaw)
            {
                result.Add($"{item.Key}-{item.Value}");
            }

            return result;
        }
    }
}
