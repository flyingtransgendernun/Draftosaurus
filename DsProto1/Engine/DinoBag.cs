using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Engine
{
    public class DinoBag : Stack<Dinosaur>
    {
        private const int AmountOfDinosInBag = 48;
        public DinoBag() : base(AmountOfDinosInBag)
        {
            int amountForEachSpecies = this.Capacity / DinoSpecies.AmountOfSpecies;
            List<Dinosaur> dinos = [];
            for(int i = 0; i < amountForEachSpecies; i++)
            {
                foreach(DinoSpecies s in DinoSpecies.All)
                {
                    dinos.Add(new Dinosaur(s));
                }
            }
            foreach(Dinosaur d in dinos.Shuffle())
            {
                Push(d);
            }
        }

        public void Distribute(IEnumerable<Player> players, int amountPerPlayer)
        {
            for(int i = 0; i < amountPerPlayer; i++)
            {
                foreach(Player p in players)
                {
                    if(TryPop(out Dinosaur? d) && d != null)
                    {
                        p.Hand.Add(d);
                    }
                    else
                    {
                        throw new Exception("No dinosaurs left in bag");
                    }
                }
            }
        }
    }
}
