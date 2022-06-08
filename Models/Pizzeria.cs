namespace la_mia_pizzeria_static.Models
{
    public class Pizzeria
    {
        public string Nome;

        public List<Pizza> listaPizze;

        public static PizzaContext db = new PizzaContext();

        public Pizzeria(string nome)
        {
            //DB---- - COMMENTO IN MODO CHE NON CREI PIU' PIZZE CON NOMI UGUALI
            Pizza margherita = new Pizza("margherita", "pomodori, mozzarella, basilico, olio evo", "margherita.jpg", 10.50);
            Pizza diavola = new Pizza("diavola", "pomodori, mozzarella, salame piccante, olio evo piccante", "diavola.jpg", 7.80);
            Pizza capricciosa = new Pizza("capricciosa", "pomodori, mozzarella, prosciutto cotto, funghi, olive, carciofini", "capricciosa.jpg", 15.00);
            Pizza americana = new Pizza("americana", "pomodori, mozzarella, wurstel, patatine fritte", "americana.jpg", 13.05);
            Pizza salsicciafriarielli = new Pizza("salsiccia e friarielli", "mozzarella, salsiccia, friarielli", "salsiccia-friarielli.jpg", 13.05);

            db.Add(margherita);
            db.Add(diavola);
            db.Add(capricciosa);
            db.Add(americana);
            db.Add(salsicciafriarielli);
            db.SaveChanges();

            this.Nome = nome;
            listaPizze = new List<Pizza>();
            //this.addPizza(new Pizza(0, "Margherita", "Pomodori, Mozzarella, Basilico, Olio EVO", "margherita.jpg", 10.50));
            //this.addPizza(new Pizza(1, "Diavola", "Pomodori, Mozzarella, Salame Piccante, Olio EVO Piccante", "diavola.jpg", 7.80));
            //this.addPizza(new Pizza(2, "Capricciosa", "Pomodori, Mozzarella, Prosciutto Cotto, Funghi, Olive, Carciofini", "capricciosa.jpg", 15.00));
            //this.addPizza(new Pizza(3, "Americana", "Pomodori, Mozzarella, Wurstel, Patatine Fritte", "americana.jpg", 13.05));
            //this.addPizza(new Pizza(4, "Salsiccia e Friarielli", "Mozzarella, Salsiccia, Friarielli", "salsiccia-friarielli.jpg", 13.05));
        }
        public void addPizza(Pizza pizza)
        {
            listaPizze.Add(pizza);
        }
    }
}
