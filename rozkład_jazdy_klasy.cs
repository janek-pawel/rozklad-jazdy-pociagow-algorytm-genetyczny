using System;
using System.Collections.Generic;

namespace Rozkład_Jazdy{
	
	public class Pociąg{
		
		public int nr_pociągu = -1;
		public List<Odcinek> trasa = new List<Odcinek>();
		
		public Pociąg(int nr_pociągu,List<Odcinek> trasa){
			this.nr_pociągu = nr_pociągu;
			this.trasa = trasa;
		}
		
		public Pociąg(int nr_pociągu){
			this.nr_pociągu = nr_pociągu;
		}
		
	}

	public class RozkładJazdy{
		
		public List<Pociąg> pociągi = new List<Pociąg>();
		
		public RozkładJazdy(){
		}
		
	}

	public class Stacja{
		
		public string nazwa = "";
		public int stacja_id = -1;
		public int ilość_torów = 2;
		
		public Stacja(int stacja_id,string nazwa,int ilość_torów=2){
			this.nazwa = nazwa;
			this.stacja_id = stacja_id;
			this.ilość_torów = ilość_torów;
		}
		
	}

	// Definiuje jednokierunkowy odcinek pomiędzy stacjami
	public class Odcinek{
		
		public int odcinek_id = -1;
		public int stacja_początkowa_id = -1;
		public int stacja_końcowa_id = -1;
		public int czas_przejazdu { get; private set; }
		public int min_czas_postoju = -1;
		
		public Odcinek(int odcinek_id,int stacja_początkowa_id,int stacja_końcowa_id,int czas_przejazdu,int min_czas_postoju){
			this.odcinek_id = odcinek_id;
			this.stacja_początkowa_id = stacja_początkowa_id;
			this.stacja_końcowa_id = stacja_końcowa_id;
			this.czas_przejazdu = czas_przejazdu;
			this.min_czas_postoju = min_czas_postoju;
		}
	}
}