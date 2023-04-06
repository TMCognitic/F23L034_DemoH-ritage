namespace F23L034_DemoHéritage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cercle o = new Cercle() { Rayon = 3, Couleur = "vert" };

            Console.WriteLine(o.ToString());
        }
    }

    //Le mot clé sealed au niveau classe en interdit son héritage
    class Forme
    {
        public string? Couleur { get; set; }

        public virtual double Perimetre { get { return double.NaN; } } //Dans la bonne pratique ce n'est pas comme ça que l'on fera!!!!
        public virtual double Surface { get { return double.NaN; } } //Dans la bonne pratique ce n'est pas comme ça que l'on fera!!!!

        //Le mot clé ovveride ne peut être utilisé sur une méthode, une propriété, un indexeur ou un événement que
        //si le parent est virtual, abstract ou lui même override
        //Le mot clé sealed ne peut utilisé que sur les membres override, et interdit les futurs redéfinission
        public override string ToString()
        {
            return $"Je suis une forme {Couleur}.";
        }
    }

    class Carre : Forme
    {
        public double Cote { get; set; }        

        public override double Perimetre { get { return Cote * 4; } }
        public override double Surface { get { return Cote * Cote; } }

        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Je suis un carré {Couleur} de {Cote} cm de coté\nMa surface est de : {Surface} cm² et mon périmètre est de {Perimetre} cm.";
        }
    }

    class Cercle : Forme
    {
        public double Rayon { get; set; }

        public override double Perimetre { get { return 2 * Math.PI * Rayon; } } // 2 Pi R
        public override double Surface { get { return Math.PI * Math.Pow(Rayon, 2); } } // Pi R²

        //La redéfinission n'est pas obligatoire en C#
        //public override string ToString()
        //{
        //    Console.WriteLine(base.ToString());
        //    return $"Je suis un cercle {Couleur} de {Rayon * 2} cm de diamètre\nMa surface est de : {Surface} cm² et mon périmètre est de {Perimetre} cm.";
        //}
    }
}