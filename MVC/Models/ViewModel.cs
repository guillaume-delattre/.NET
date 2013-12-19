namespace MVC.Models
{
    public class ViewModel
    {
        public Personne[] Personnes { get; set; }
        public int SelectedId { get; set; }

        public ViewModel()
        {
            Personnes = new Personne[] { 
            new Personne{ Id = 1, Prenom = "Pierre", Nom = "Martino"}, 
            new Personne{ Id = 2, Prenom = "Pauline", Nom = "Pereiro"}, 
            new Personne{ Id = 3, Prenom = "Jacques", Nom = "Alfonso"} };
            SelectedId = 2;
        }
    }

    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}