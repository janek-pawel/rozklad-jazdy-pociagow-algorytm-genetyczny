using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

using Rozkład_Jazdy;

public class RozkładJazdyInterfejs : Form{
	
	private Algorytm_Genetyczny alg; 
	
	private PictureBox ekran;
	
	private Label liczba_stacji_label;
	private Label liczba_pociągów_label;
	private Label liczba_osobników_label;
	private Label liczba_generacji_label;
	private Label pstwo_krzyżowania_label;
	private Label pstwo_mutacji_label;
	private Label ziarno_losowości_label;
	
	private TextBox liczba_stacji_text;
	private TextBox liczba_pociągów_text;
	private TextBox liczba_osobników_text;
	private TextBox liczba_generacji_text;
	private TextBox pstwo_krzyżowania_text;
	private TextBox pstwo_mutacji_text;
	private TextBox ziarno_losowości_text;
	
	private Label generacje_licz;
	private Label fitness_label;
	private Label fitness_var;
	
	private Button inicjalizuj_pop_button;
	private Button krok_algorytmu;
	private Button rozpocznij_działanie;
	private Button graf_button;
		
	private SolidBrush czarny = new SolidBrush(Color.FromArgb(255,24,24,24));
	private SolidBrush biały = new SolidBrush(Color.White);
	private SolidBrush niebieski = new SolidBrush(Color.FromArgb(255,0,0x80,0xC0));
	private Pen pędzel_odcinek = new Pen(Color.FromArgb(128,0,0x80,0xC0),6);
	private Font czcionka_stacji = new Font("Arial",10);
	private StringFormat format_centrum = new StringFormat();
	private StringFormat format_prawy = new StringFormat();
	
	private int[] punkty_siatki_x;
	private int pad_x = 80;
	private int pad_y = 24;
	private int pad_y_bottom = 48;
	private double skala_y = 1.0;
	private int odstęp_num = 1;
	private double odstęp_linie = 1.0;
	private int line_bottom = -1;
	private int num_pos = -1;
	
	private Pen linia_czarna = new Pen(Color.Black,2);
	private Pen linia_czarna_cieńsza = new Pen(Color.FromArgb(255,64,64,64),1);
	private Pen linia_niebieska = new Pen(Color.FromArgb(128,0,128,192),4);
	private Pen linia_czerwona = new Pen(Color.FromArgb(128,255,0x32,0x24),4);
	
	private System.Windows.Forms.Timer timer;

	[STAThread]
	static void Main(){
		Application.Run(new RozkładJazdyInterfejs());
	}
	
	public RozkładJazdyInterfejs(){
		
		// Inicjalizacja algorytmu		
		alg = new Algorytm_Genetyczny(12,18,1024,32,0.8,0.05,47);
		
		// Tworzenie wszyyystkich kontrolek
		
		ekran = new PictureBox();
		ekran.Location = new Point(256,8);
		ekran.Paint += new PaintEventHandler(rysuj);
		
		liczba_stacji_label = new Label();
		liczba_pociągów_label = new Label();
		liczba_osobników_label = new Label();
		liczba_generacji_label = new Label();
		pstwo_krzyżowania_label = new Label();
		pstwo_mutacji_label = new Label();
		ziarno_losowości_label = new Label();
		
		liczba_stacji_text = new TextBox();
		liczba_pociągów_text = new TextBox();
		liczba_osobników_text = new TextBox();
		liczba_generacji_text = new TextBox();
		pstwo_krzyżowania_text = new TextBox();
		pstwo_mutacji_text = new TextBox();
		ziarno_losowości_text = new TextBox();
		
		liczba_stacji_label.Size = liczba_pociągów_label.Size = liczba_osobników_label.Size = liczba_generacji_label.Size = pstwo_krzyżowania_label.Size = pstwo_mutacji_label.Size = liczba_stacji_text.Size = liczba_pociągów_text.Size = liczba_osobników_text.Size = liczba_generacji_text.Size = pstwo_krzyżowania_text.Size = pstwo_mutacji_text.Size = new Size(108,20);
		
		ziarno_losowości_text.Size = ziarno_losowości_label.Size = new Size(232,20);
				
		liczba_stacji_label.Location = new Point(12,12);
		liczba_stacji_text.Location = new Point(liczba_stacji_label.Left,liczba_stacji_label.Bottom+0);
		
		liczba_pociągów_label.Location = new Point(liczba_stacji_label.Right+16,liczba_stacji_label.Top);
		liczba_pociągów_text.Location = new Point(liczba_pociągów_label.Left,liczba_pociągów_label.Bottom+0);
		
		liczba_osobników_label.Location = new Point(liczba_stacji_text.Left,liczba_stacji_text.Bottom+24);
		liczba_osobników_text.Location = new Point(liczba_osobników_label.Left,liczba_osobników_label.Bottom+0);
		
		liczba_generacji_label.Location = new Point(liczba_pociągów_text.Left,liczba_pociągów_text.Bottom+24);
		liczba_generacji_text.Location = new Point(liczba_generacji_label.Left,liczba_generacji_label.Bottom+0);
		
		pstwo_krzyżowania_label.Location = new Point(liczba_osobników_text.Left,liczba_osobników_text.Bottom+12);
		pstwo_krzyżowania_text.Location = new Point(pstwo_krzyżowania_label.Left,pstwo_krzyżowania_label.Bottom+0);
		
		pstwo_mutacji_label.Location = new Point(liczba_generacji_text.Left,liczba_generacji_text.Bottom+12);
		pstwo_mutacji_text.Location = new Point(pstwo_mutacji_label.Left,pstwo_mutacji_label.Bottom+0);
		
		ziarno_losowości_label.Location = new Point(pstwo_krzyżowania_text.Left,pstwo_krzyżowania_text.Bottom+24);
		ziarno_losowości_text.Location = new Point(ziarno_losowości_label.Left,ziarno_losowości_label.Bottom+0);
			
		liczba_stacji_label.Text = "Liczba stacji";
		liczba_pociągów_label.Text = "Liczba pociągów";
		liczba_osobników_label.Text = "Populacja";
		liczba_generacji_label.Text = "Generacje";
		pstwo_krzyżowania_label.Text = "P-stwo krzyżowania";
		pstwo_mutacji_label.Text = "P-stwo mutacji";
		ziarno_losowości_label.Text = "Ziarno losowości";
		
		liczba_stacji_text.Text = "12";
		liczba_pociągów_text.Text = "18";
		liczba_osobników_text.Text = "1024";
		liczba_generacji_text.Text = "32";
		pstwo_krzyżowania_text.Text = "0,8";
		pstwo_mutacji_text.Text = "0,05";
		ziarno_losowości_text.Text = "47";
		
		generacje_licz = new Label();
		fitness_label = new Label();
		fitness_var = new Label();
		
		generacje_licz.Font = new Font("Tahoma",12);
		fitness_label.Font = new Font("Tahoma",12);
		generacje_licz.Size = new Size(232,generacje_licz.Font.Height);
		fitness_label.Size = new Size(232,fitness_label.Font.Height);
		fitness_var.Font = new Font("Tahoma",12);
		fitness_var.Size = new Size(232,fitness_var.Font.Height*2);
		
		generacje_licz.Location = new Point(ziarno_losowości_text.Left,ziarno_losowości_text.Bottom+24);
		fitness_label.Location = new Point(generacje_licz.Left,generacje_licz.Bottom+8);
		fitness_var.Location = new Point(fitness_label.Left,fitness_label.Bottom+8);
		
		generacje_licz.Text = "Generacja: -/-";
		fitness_label.Text = "Fitness";
		fitness_var.Text = "Naj: -\nŚr: -";
		
		inicjalizuj_pop_button = new Button();
		krok_algorytmu = new Button();
		rozpocznij_działanie = new Button();
		graf_button = new Button();
		
		graf_button.Size = inicjalizuj_pop_button.Size = krok_algorytmu.Size = rozpocznij_działanie.Size = new Size(ziarno_losowości_text.Size.Width,32);
		
		graf_button.Text = "Wykres";
		inicjalizuj_pop_button.Text = "Inicjalizuj populację";
		krok_algorytmu.Text = "Krok";
		rozpocznij_działanie.Text = "Rozpocznij działanie";
		
		krok_algorytmu.Enabled = rozpocznij_działanie.Enabled = graf_button.Enabled = false;
		
		timer = new System.Windows.Forms.Timer();
		timer.Tick += new EventHandler(krok_alg);
		timer.Interval = 40;
		
		// Funkcjonalności kontrolek
		
		rozpocznij_działanie.Click += new EventHandler( (object sender, EventArgs e) => {
			timer.Start();
		});
		
		// Funkcja do rysowania wykresów -> szybko dodana, działa poprzez użycie języka Python z biblioteką matplotlib
		
		graf_button.Click += new EventHandler( (object sender, EventArgs e) => {
			using(StreamWriter sw = new StreamWriter("fitness.txt")){
				sw.WriteLine("Najlepszy fitness");
				for(int i=0;i<alg.naj_fitness_hist.Count;++i)
					sw.WriteLine(i+"\t"+alg.naj_fitness_hist[i]);
				sw.WriteLine();
				sw.WriteLine("Średni fitness");
				for(int i=0;i<alg.śr_fitness_hist.Count;++i)
					sw.WriteLine(i+"\t"+alg.śr_fitness_hist[i]);
				sw.WriteLine();
			}
			
			using (Process myProcess = new Process()){
				myProcess.StartInfo.FileName = "pyw.exe";
				myProcess.StartInfo.Arguments = "wykres.pyw";
				myProcess.Start();
			}
			
		});
		
		krok_algorytmu.Click += new EventHandler(krok_alg);
		
		// funkcja do inicjalizacji populacji na podstawie danych wprowadzonych przez użytkownika		
		inicjalizuj_pop_button.Click += new EventHandler( (object sender,EventArgs e) => {
			
			int st=0,pc=0,pop=0,gen=0;
			double krz=0.0,mut=0.0;
			int? seed = null;
			
			try{
				st = Convert.ToInt32(liczba_stacji_text.Text);
				pc = Convert.ToInt32(liczba_pociągów_text.Text);
				pop = Convert.ToInt32(liczba_osobników_text.Text);
				gen = Convert.ToInt32(liczba_generacji_text.Text);
				krz = Convert.ToDouble(pstwo_krzyżowania_text.Text);
				mut = Convert.ToDouble(pstwo_mutacji_text.Text);
				if(ziarno_losowości_text.Text!="")
					seed = Convert.ToInt32(ziarno_losowości_text.Text);
			} catch( Exception err ){
				MessageBox.Show(err.Message);
				return;
			}
			
			alg = new Algorytm_Genetyczny(st,pc,pop,gen,krz,mut,seed);
			aktualizuj_punkty();
			alg.Inicjalizuj_Populację();
			generacje_licz.Text = "Generacja: 0/"+alg.generacje;
			fitness_var.Text = "Naj: "+alg.naj_fitness+"\nŚr: "+alg.śr_fitness;
			ekran.Focus(); ekran.Invalidate();
			krok_algorytmu.Enabled = rozpocznij_działanie.Enabled = graf_button.Enabled = true;
		});
		
		this.ClientSize = new Size(1024,512);
		this.SizeChanged += new EventHandler(zmiana_rozmiaru);
		zmiana_rozmiaru(null,null);
		
		this.Text = "Rozkład Jazdy";
		this.Controls.AddRange(new Control[]{
			ekran,
			liczba_stacji_label,
			liczba_pociągów_label,
			liczba_osobników_label,
			liczba_generacji_label,
			pstwo_krzyżowania_label,
			pstwo_mutacji_label,
			ziarno_losowości_label,
			liczba_stacji_text,
			liczba_pociągów_text,
			liczba_osobników_text,
			liczba_generacji_text,
			pstwo_krzyżowania_text,
			pstwo_mutacji_text,
			ziarno_losowości_text,
			inicjalizuj_pop_button,
			krok_algorytmu,
			rozpocznij_działanie,
			generacje_licz,
			fitness_label,
			fitness_var,
			graf_button
		});
		
		format_centrum.Alignment = StringAlignment.Center;
		format_prawy.Alignment = StringAlignment.Far;
	}
	
	private void krok_alg(object sender,EventArgs e){
		if(alg.generacja_num<alg.generacje){
			alg.Krok_Algorytmu();
			generacje_licz.Text = "Generacja: "+alg.generacja_num+"/"+alg.generacje;
			fitness_var.Text = "Naj: "+alg.naj_fitness+"\nŚr: "+alg.śr_fitness;
			ekran.Focus(); ekran.Invalidate();
		} else
			timer.Stop();
	}
	
	private void aktualizuj_punkty(){
		punkty_siatki_x = new int[alg.stacje.Count];
		for(int j=0;j<alg.stacje.Count;++j){
			punkty_siatki_x[j] = (int)( ( j * (ekran.Size.Height-pad_y-pad_y_bottom) / (double)(alg.stacje.Count-1) ) + pad_y + 0.5 );
		}
	}
	
	// funkcja do dostosywania pozycji kontrolek na podstawie aktualnego rozmiaru ekranu
	private void zmiana_rozmiaru(object sender,EventArgs e){
		ekran.Size = new Size(ClientSize.Width-256-8,ClientSize.Height-16);
		ekran.Focus();
		ekran.Invalidate();
		
		aktualizuj_punkty();
		
		graf_button.Location =  new Point(ziarno_losowości_text.Left,ClientSize.Height-12-rozpocznij_działanie.Size.Height);
		rozpocznij_działanie.Location = new Point(graf_button.Left,graf_button.Top-graf_button.Size.Height);
		krok_algorytmu.Location = new Point(rozpocznij_działanie.Left,rozpocznij_działanie.Top-krok_algorytmu.Size.Height);
		inicjalizuj_pop_button.Location = new Point(krok_algorytmu.Left,krok_algorytmu.Top-inicjalizuj_pop_button.Size.Height);
		
		line_bottom = ekran.Size.Height-pad_y_bottom;
		num_pos = ekran.Size.Height-((pad_y_bottom+czcionka_stacji.Height)>>1);
		
	}
	
	// Rysowanie wykresu
	private void rysuj(object sender,PaintEventArgs e){
			
		double w = 0;
		foreach(Stacja stacja in alg.stacje){
			foreach(string tekst in stacja.nazwa.Split('\n')){
				SizeF wymiary = e.Graphics.MeasureString(tekst, czcionka_stacji);
				if (wymiary.Width > w){
					w = wymiary.Width;
				}
			}
		}
		pad_x = (int)(w+16.5);
		
		e.Graphics.FillRectangle(biały,new Rectangle(0,0,ekran.Size.Width,ekran.Size.Height));
		
		
		// siatka
		
		if(alg.max_czas_naj_os>0){
			skala_y = (double)( ekran.Size.Width - pad_x - 8 ) / alg.max_czas_naj_os;
		} else{
			skala_y = 1.0;
		}
		
		odstęp_linie = skala_y;
		odstęp_num = 4;
		
		while(odstęp_linie<16.0&&odstęp_num>1){
			odstęp_linie *= 2.0;
			odstęp_num *= 2;
		}
		
		double odstęp_linie_tmp = odstęp_linie;
		int odstęp_nr = 4;
		
		while(odstęp_linie_tmp>16.0&&odstęp_nr>1){
			odstęp_nr /= 2;
			odstęp_num /= 2;
			odstęp_linie_tmp /= 2.0;
		}
		
		int licznik = 0;
		for(double y = pad_x; y <= ekran.Size.Width; y += odstęp_linie ){
			int poz_y = (int)(y+0.5);
			e.Graphics.DrawLine((((licznik++)&3)==0) ? linia_czarna : linia_czarna_cieńsza,new Point(poz_y,pad_y),new Point(poz_y,line_bottom));
		} licznik = 0;
		foreach(int punkt_x in punkty_siatki_x){
			e.Graphics.DrawLine(linia_czarna,new Point(pad_x,punkt_x),new Point(ekran.Size.Width,punkt_x));
			e.Graphics.DrawString(alg.stacje[licznik++].nazwa,czcionka_stacji,czarny,new Point(pad_x-8,punkt_x-(czcionka_stacji.Height>>1)),format_prawy);
		}
		licznik = 0;
		for(double y = pad_x; y <= ekran.Size.Width; y += odstęp_nr*odstęp_linie ){
			int poz_y = (int)(y+0.5);
			e.Graphics.DrawString(licznik.ToString(),czcionka_stacji,czarny,new Point(poz_y,num_pos),format_centrum);
			Console.Write("{0}\r",licznik);
			licznik += odstęp_num;
		}
		
		// rysowanie połączeń
			
		if(alg.generacja_num>=0){
			
			foreach (var kvp in alg.rozkład_jazdy_najlepszego_osobnika){
				
				int pociąg_id = kvp.Key;
				var czas = kvp.Value;
				
				var trasa = alg.pociągi[pociąg_id].trasa;
				
				if(czas.Count==trasa.Count){
					for(int i=0;i<czas.Count;++i){
						
						var odc = trasa[i];
						
						int czas_przejazd = czas[i]+odc.czas_przejazdu;
											
						e.Graphics.DrawLine(
							linia_czerwona,
							new Point(pad_x+(int)(czas[i]*skala_y+0.5), punkty_siatki_x[odc.stacja_początkowa_id]),
							new Point(pad_x+(int)(czas_przejazd*skala_y+0.5), punkty_siatki_x[odc.stacja_końcowa_id])
						);
						if(i<trasa.Count-1){				
							e.Graphics.DrawLine(
								linia_czerwona,
								new Point(pad_x+(int)(czas_przejazd*skala_y+0.5), punkty_siatki_x[odc.stacja_końcowa_id]),
								new Point(pad_x+(int)(czas[i+1]*skala_y+0.5), punkty_siatki_x[odc.stacja_końcowa_id])
							);
						}
						
					}
				}
			}
		}
		
		
	}
	
}