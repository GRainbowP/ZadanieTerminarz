namespace ZadanieTerminarz
{
    public partial class MainPage : ContentPage
    {
        int index = 1;
        List<Termin> terminy = new List<Termin>();
        public MainPage()
        {
            InitializeComponent();

            String line;
            try
            {
                StreamReader sr = new StreamReader("dane.txt");
                line = sr.ReadLine();

                while(line != null)
                {
                    String[] parts = line.Split(";");
                    Termin t = new Termin(parts[0], parts[1], DateTime.Parse(parts[2]), TimeOnly.Parse(parts[3]));
                    terminy.Add(t);

                    line = sr.ReadLine();
                }
                sr.Close();

            }catch (Exception e)
            {
                Console.WriteLine("Wystąpił problem: " + e.Message);
            }

            terminTitle.Text = terminy[0].Tytul;
            terminDesc.Text = terminy[0].Opis;
            terminDate.Text = terminy[0].Data.ToString("yyyy-MM-dd");
            terminHour.Text = terminy[0].Godzina.ToString("H:mm");
        }

        private void beforeTermin_Clicked(object sender, EventArgs e)
        {
            if (index == 1) index = terminy.Count;
            else index--;

            
            terminTitle.Text = terminy[index - 1].Tytul;
            terminDesc.Text = terminy[index - 1].Opis;
            terminDate.Text = terminy[index - 1].Data.ToString("yyyy-MM-dd");
            terminHour.Text = terminy[index - 1].Godzina.ToString("H:mm");
        }

        private void nextTermin_Clicked(object sender, EventArgs e)
        {
            if (index == terminy.Count) index = 1;
            else index++;

            terminTitle.Text = terminy[index - 1].Tytul;
            terminDesc.Text = terminy[index - 1].Opis;
            terminDate.Text = terminy[index - 1].Data.ToString("yyyy-MM-dd");
            terminHour.Text = terminy[index - 1].Godzina.ToString();
        }
    }

    class Termin
    {
        private string tytul, opis;
        private DateTime data;
        private TimeOnly godzina;

        public Termin(string tytul, string opis, DateTime data, TimeOnly godzina)
        {
            this.tytul = tytul;
            this.opis = opis;
            this.data = data;
            this.godzina = godzina;
        }

        public string Tytul { get => tytul; }
        public string Opis { get => opis; }
        public DateTime Data { get => data; }
        public TimeOnly Godzina { get => godzina; }
    }
}
