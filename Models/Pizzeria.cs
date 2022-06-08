namespace la_mia_pizzeria_static.Models
{
    public class Pizzeria
    {
        public string Nome;
        public List<Pizza> listaPizze;
        public Pizzeria(string nome)
        {
            this.Nome = nome;
            listaPizze = new List<Pizza>();
            this.addPizza(new Pizza(0, "Margherita", "Pomodori, Mozzarella, Basilico, Olio EVO", "margherita.jpg", 10.50));
            this.addPizza(new Pizza(1, "Diavola", "Pomodori, Mozzarella, Salame Piccante, Olio EVO Piccante", "diavola.jpg", 7.80));
            this.addPizza(new Pizza(2, "Capricciosa", "Pomodori, Mozzarella, Prosciutto Cotto, Funghi, Olive, Carciofini", "capricciosa.jpg", 15.00));
            this.addPizza(new Pizza(3, "Americana", "Pomodori, Mozzarella, Wurstel, Patatine Fritte", "americana.jpg", 13.05));
            this.addPizza(new Pizza(4, "Salsiccia e Friarielli", "Mozzarella, Salsiccia, Friarielli", "salsiccia-friarielli.jpg", 13.05));
        }
        public void addPizza(Pizza pizza)
        {
            listaPizze.Add(pizza);
        }
    }
}
