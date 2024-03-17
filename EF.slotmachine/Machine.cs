
namespace EF.slotmachine
{
    public class Machine
    {
        private List<Afbeelding> afbeeldingen = new List<Afbeelding>() { new Afbeelding(), new Afbeelding(), new Afbeelding() };
        private uint score = 0;
        private List<string> resultaten = new List<string>();

        public List<string> Spin()
        {
            resultaten.Clear();

            afbeeldingen.ForEach(afbeelding => {
                resultaten.Add(afbeelding.Spin());
            });

            if (resultaten[0] == resultaten[1] && resultaten[0] == resultaten[2]) score = 3;
            else if (resultaten[0] == resultaten[1] || resultaten[0] == resultaten[2] || resultaten[1] == resultaten[2]) score = 1;
            else score = 0;

            return resultaten;
        }

        public uint Gewonnen()
        {
            return score;
        }
    }

}
