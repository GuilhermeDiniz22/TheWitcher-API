using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpgapi.Models
{
    public class Personagem
    {
        public int Id { get; set; }

        public string Nome { get; set; } = "Geralt";

        public int PontosdeVida { get; set; } = 100;

        public int PontosdeMana { get; set; } = 80;

        public int Força { get; set; } = 10;

        public int Defesa { get; set; } = 10;

        public int Inteligencia { get; set; } = 10;

        public ClasseRpg Classe { get; set; } = ClasseRpg.Bruxo;
    }
}