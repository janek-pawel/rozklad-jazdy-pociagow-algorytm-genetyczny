using System;
using System.Collections.Generic;
using System.Linq;

using Rozkład_Jazdy;

// Klasa całego algorytmu genetycznego
public class Algorytm_Genetyczny{
	
	// Lista dosłownie wszystkich nazw stacji w Polsce. Do aktualizacji jako klasa statyczna
	public string[] nazwy_stacji = {"Aleksandrów Kujawski","Andrychów","Andrychów Górnica","Andrzejówka","Anieliny","Annolesie","Antonin","Antoniów","Antoniówka","Arcelin","Augustów","Augustów Port","Augustówka","Babi Dół","Babiak","Babica","Babica Kolonia","Babimost","Baborów","Baborówko","Baboszewo","Baby","Bachorce","Baciuty","Bagicz","Bagienice","Bajtkowo","Balin","Balinka","Banie","Baranowo","Baranów Sandomierski","Baranówka","Barchów","Barcice","Barcin","Barcino","Barczewo","Barcząca","Bardo Przyłęk","Bardo Śląskie","Barnowo","Barnówko","Bartnica","Bartodzieje","Bartosze","Bartoszyce","Bartąg","Barwałd Górny","Barwałd Średni","Barwice","Barzkowice","Barłogi","Baszewice","Basznia","Basznia Dolna","Batowice Lubańskie","Bażanowice","Bednary","Bedoń","Belęcin Wielkopolski","Bemowizna","Berejów","Berezów","Bernacice","Besko","Bezwola","Bełchatów Miasto","Bełchów","Bełczna","Bełsznica","Bełżec","Bełżec Drugi","Biadki","Biadoliny","Biała","Biała Pajęczańska","Biała Pilska","Biała Piska","Biała Podlaska","Biała Podlaska Rozrządowa","Biała Złotoryjska","Białki","Białki Siedleckie","Białogard","Białowieża","Białowieża Pałac","Białośliwie","Białuń","Biały Bór","Biały Dunajec","Biały Kościół","Biały Zdrój Południowy","Biały Zdrój Północny","Białystok","Białystok Bacieczki","Białystok Fabryczny","Białystok Nowe Miasto","Białystok Stadion","Białystok Starosielce","Białystok Wiadukt","Biecz","Bieczyno Pomorskie","Biedrzychowice Dolne","Biel","Bielany Podlaskie","Bielany Wrocławskie","Bielawa Centralna","Bielawa Zachodnia","Bielawy","Bielice Parsów","Bielin","Bieliny Opoczyńskie","Bielsk Podlaski","Bielsko Biała BUS","Bielsko-Biała Aleksandrowice","Bielsko-Biała Górne","Bielsko-Biała Główna","Bielsko-Biała Komorowice","Bielsko-Biała Leszczyny","Bielsko-Biała Lipnik","Bielsko-Biała Mikuszowice","Bielsko-Biała Północ","Bielsko-Biała Wapienica","Bielsko-Biała Wschód","Bielsko-Biała Zachód","Bieniów","Bierawa","Bierkowice","Biernatowo","Bierutów","Bieruń Mleczarnia","Bieruń Stary","Bierzwnik","Biesal","Biesowice","Biniew","Binino","Biskupice Lubelskie","Biskupice Oławskie","Biskupice Wielkopolskie","Biskupice koło Kluczborka","Biskupiec Pomorski","Biskupiec Reszelski","Biskupnica","Biłgoraj","Bińcze","Blachownia","Blizna","Bliżyn","Bobowa","Bobowa-Miasto","Bobowicko","Bobrowniki","Bobrowo Pomorskie","Bobry","Bobrówka","Bochnia","Bochotnica","Boczów","Bodzechów","Bogaczewo","Bogaczów","Bogatynia","Bogdaniec","Bogdanowo","Bogoniowice Ciężkowice","Boguchwała","Bogumiłowice","Boguszewo","Boguszów-Gorce","Boguszów-Gorce Wschód","Boguszów-Gorce Zachód","Bojanowo","Bojary","Boksycka","Bolechowo","Boleszewo","Boleszkowice","Bolesławice Świdnickie","Bolesławiec","Bolęcin","Boreczek","Borek Wielkopolski","Borki Siedleckie","Borki-Kosy","Borkowice","Borkowo","Boronów","Borowa Oleśnicka","Borowiany","Borowiki","Borowina","Borsukówka","Borszewice","Borucice","Borujsko","Borzym","Borzytuchom","Boszkowo","Boża Wola","Bożacin","Bożepole Wielkie","Brachlewo","Brachów","Bralin","Braniewo","Braniewo Brama","Braniewo Gr","Bratian","Bratków","Bratków Zgorzelecki","Bratoszewice","Brochocin Trzebnicki","Brodnica","Brody Iłżeckie","Brody Warszawskie","Brokęcino","Bronisław","Bronów","Brusy","Brwice","Brwinów","Brzask","Brzeg","Brzeg Dolny","Brzeg Głogowski","Brzesko Okocim","Brzeszcze","Brzeszcze Jawiszowice","Brzeszcze Kopalnia","Brzezie","Brzezinka Średzka","Brzeziny","Brzeźnica","Brzeźnica Bychawska","Brzeźnica nad Wartą","Brzeźno","Brzeźno Człuchowskie","Brzostów Wielkopolski","Brzoza Bydgoska","Brzoza Toruńska","Brzozowica","Brzozowiec Gorzowski","Brzustowa Opatowska","Brzustów","Brzózki","Buchałów","Bucze","Buczkowice","Budachów","Budki Nowe","Budwity","Budy Głogowskie","Budziszowice","Budzyń","Bujaki","Buk","Buk (Bieszczady)","Bukowa","Bukowice Trzebnickie","Bukowiec","Bukowiec Międzyrzecki","Bukowina Bobrzańska","Bukowina Sycowska","Bukowno","Bukowno Przymiarki","Bukowo","Bukowo Człuchowskie","Bukowo Krąpiel","Bukwałd","Bulowice","Burkat","Bursztynowo","Busko-Zdrój","Byczyna Kluczborska","Bydgoszcz Akademia","Bydgoszcz Bielawy","Bydgoszcz Brdyujście","Bydgoszcz Błonie","Bydgoszcz Emilianowo","Bydgoszcz Fordon","Bydgoszcz Główna","Bydgoszcz Leśna","Bydgoszcz Osowa Góra","Bydgoszcz Wschód","Bydgoszcz Zachód","Bydgoszcz Łęgnowo","Bystra","Bystra Podhalańska","Bystrzyca Kłodzka","Bystrzyca Kłodzka Przedmieście","Bystrzyca koło Lublina","Bytnica","Bytom","Bytom Bobrek","Bytom Karb","Bytom Odrzański","Bytom Północny","Bytonia","Bytów","Bzowiec","Bąk","Bąkowiec","Bąków","Będziemyśl","Będzin","Będzin Ksawera","Będzin Miasto","Będzino","Będów","Będźmierowice","Błaszki","Błażkowa","Błonie","Błotnica","Błotnica Strzelecka","Błądzim","Cegłów","Cekcyn","Celestynów","Cerkiewnik","Chabówka","Charnowo Słupskie","Charsznica","Chałupki","Chałupki Gr","Chałupy","Chechło","Chełchy","Chełm","Chełm Cementownia","Chełm Miasto","Chełm Śląski","Chełmce","Chełmek","Chełmek Wołowski","Chełmica","Chełmoniec","Chełmsko","Chełmża","Chludowo","Chmielnik","Chmielniki Bydgoskie","Chmielów Zagumnie","Chmielów koło Tarnobrzega","Chocianów","Chocicza","Chociszew","Chociszewo Rogoziniec","Chociw Łaski","Chociwel","Chocznia","Chocznia Górna","Chodzież","Chojna","Chojnice","Chojnik","Chojnów","Chomranice","Chorzele","Chorzelów","Chorzew Siemkowice","Chorzów Batory","Chorzów Miasto","Chorzów Stary","Choszczno","Chotomów","Chotyłów","Chromin","Chronów","Chrosna","Chrośnica","Chrusty Nowe","Chruszczobród","Chruściel","Chrzanów","Chrzanów Śródmieście","Chrzypsko Wielkie","Chrząstawa Mała","Chrząstawa Wielka","Chrząstowice","Chrząstowice Olkuskie","Chrzęsne","Chróstnik","Chróścice","Chróścina Nyska","Chróścina Opolska","Chwalibogowo","Chwarstnica","Chwałkowo Kościelne","Chwiram","Chybie","Chybie Mnich","Chynów","Chytra","Ciasna","Ciechanowice","Ciechanów","Ciechanów Przemysłowy","Ciechocinek","Ciecholub","Ciecierzyn","Cieksyn","Ciemnice","Cienin","Cienin Kościelny","Ciepielów","Cieplewo","Cierpice Kąkol","Cierpigórz","Cieszeniewo","Cieszków","Cieszyn","Cieszyn Markl. Gr","Cieszyn Mnisztwo","Cieszyno Łobeskie","Cieśle","Cikowice","Cimochy","Ciosmy","Cisie","Cisiec","Cisna","Cisówka","Cięcina","Cięcina Dolna","Cmolas","Cybowo","Cychry","Cygany","Cykarzew","Cykarzew Stary","Czachówek Górny","Czachówek Południowy","Czachówek Wschodni","Czachówek Środkowy","Czaple Chwaliszowice","Czaplinek","Czarków","Czarlin","Czarna Białostocka","Czarna Tarnowska","Czarna Woda","Czarnca","Czarne","Czarne Małe","Czarniecka Góra","Czarnobór","Czarnowo-Undy","Czarnowęsy Pomorskie","Czarny Blok","Czarny Kierz","Czastary","Czaszyn","Czechowice-Dziedzice","Czechowice-Dziedzice Południowe","Czechowice-Dziedzice Przystanek","Czechowizna","Czekanów","Czekanów Wieś","Czekanów Śląski","Czeluścin","Czempiń","Czepino","Czeremcha","Czeremcha Gr","Czerlonka","Czermno","Czerna","Czerna Mała","Czernica Wrocławska","Czerniejewo","Czerniewice","Czernikowo","Czersk","Czersk Świecki","Czeruchy","Czerwieńsk","Czerwionka","Czerwionka Dębieńsko","Czerwonak","Czerwonak Osiedle","Czerwonka","Czerwony Bór","Czeska Wieś","Czesławice","Czosnowo","Czudec","Czuprynowo","Czyżew","Czyżowice","Częstochowa","Częstochowa Aniołów","Częstochowa Gnaszyn","Częstochowa Raków","Częstochowa Stradom","Człopa","Człuchów","Dalanówek","Dalekie","Daleszewo Gryfińskie","Dalęcino","Damasławek","Damnica","Daniszewo","Daniszyn","Dankowice","Darłowo","Daszewo","Delastowice","Deszczno","Dionizów PODG","Dobczyn","Dobiegniew","Dobieszyn","Dobiesław","Dobino Wałeckie","Doboszowice","Dobra koło Limanowej","Dobre Miasto","Dobrocin","Dobrojewo","Dobroszyce","Dobrowoda","Dobroń","Dobrynka","Dobryszyce koło Radomska","Dobrzechów","Dobrzejewice","Dobrzeń Wielki","Dobrzykowice Wrocławskie","Dobrzyniewo Duże","Dobrzyń","Dolaszewo Wałeckie","Dolice","Dolna Odra","Dolnik","Domaniewice","Domaniewice Centrum","Domanin","Domaszków","Domaszowice","Domasław","Dominów","Domisław","Dopiewo","Dorohusk","Dorohusk Gr","Dragacz","Drawiny","Drawno","Drawski Młyn","Drawsko Pomorskie","Drogomyśl","Drogosze","Drużyna Poznańska","Drużyny","Drygały","Drygulec","Drzewce","Drzewica","Drzeńsko","Drzonowo","Drzycim","Drzymałowo","Dubidze","Dubielno","Dulowa","Duninów","Dunowo","Durzyn R17","Duszniki-Zdrój","Dwikozy","Dwory","Dygowo","Dyszno","Dytmarów","Dziadówki","Dziarnowo PODG","Działdowo","Działoszyn","Dziembówko","Dziemiany Kaszubskie","Dziergowice","Dzierzgoń","Dzierżanów Wielkopolski","Dzierżoniów Dolny","Dzierżoniów Śląski","Dzierżążno","Dzietrzniki","Dziewięcierz","Dziewoklicz","Dziewule","Dzikowice","Dzikowo Wałeckie","Dziwno","Dziwnówek","Dzięczyn","Dąbie koło Dębicy","Dąbie nad Nerem","Dąbkowizna","Dąbroszyn","Dąbrowa Białostocka","Dąbrowa Chełmińska","Dąbrowa Górnicza","Dąbrowa Górnicza Gołonóg","Dąbrowa Górnicza Huta Katowice","Dąbrowa Górnicza Pogoria","Dąbrowa Górnicza Południowa","Dąbrowa Górnicza Sikorka","Dąbrowa Górnicza Strzemieszyce","Dąbrowa Górnicza Wschodnia","Dąbrowa Górnicza Ząbkowice","Dąbrowa Międzylesie","Dąbrowa Niemodlińska","Dąbrowa Oleśnicka","Dąbrowa Tarnowska","Dąbrowa-Łazy","Dąbrowica Małopolska","Dąbrowica koło Biłgoraja","Dąbrowice Skierniewickie","Dąbrowy","Dąbrówka Bytowska","Dąbrówka Górkło","Dąbrówka Kobułcka","Dąbrówka Malborska","Dąbrówka Wielkopolska","Dąbrówki Breńskie","Dęba Opoczyńska","Dęba Rozalin","Dębe Wielkie","Dębica","Dębica Wschodnia","Dęblin","Dębnica Wielkopolska","Dębno Lubuskie","Dębostrów","Dębowy Gaj","Dębska Kuźnia","Dębska Wola","Dębsko Pomorskie","Długi Kąt","Długie","Długokąty","Długomilowice","Długopole-Zdrój","Długołęka","Dźwirzyno","Dźwirzyno Senator nż.","Dźwirzyno camping","Dźwirzyno osiedle","Elbląg","Elbląg Zdrój","Ełk","Ełk Szyba Wschód","Ełk Szyba Zachód","Ełk Zachód","Fasty","Fałkowo","Firlus","Fiszewo","Fiuk","Florek","Fosowskie","Frankamionka","Frankowo","Frombork","Fronołów","Frysztak","Gajówka","Gamerki Wielkie","Garbatka-Letnisko","Garbce","Garcz","Garczegorze","Garczyn","Gardeja","Garki","Garwolin","Garzyn","Gaworzyce","Gawrony","Gałczewko","Gałkówek","Gałęzinowo","Gdakowo","Gdańsk Brzeźno","Gdańsk Brętowo","Gdańsk Główny","Gdańsk Jasień","Gdańsk Kiełpinek","Gdańsk Kolonia","Gdańsk Lipce","Gdańsk Matarnia","Gdańsk Niedźwiednik","Gdańsk Nowe Szkoty","Gdańsk Nowy Port","Gdańsk Oliwa","Gdańsk Orunia","Gdańsk Osowa","Gdańsk Politechnika","Gdańsk Port Lotniczy","Gdańsk Przymorze Uniwersytet","Gdańsk Rębiechowo","Gdańsk Stocznia","Gdańsk Strzyża","Gdańsk Wrzeszcz","Gdańsk Zaspa","Gdańsk Zaspa Towar.","Gdańsk Śródmieście","Gdańsk Żabianka-AWFiS","Gdynia Chylonia","Gdynia Cisowa","Gdynia Grabówek","Gdynia Główna","Gdynia Karwiny","Gdynia Leszczynki","Gdynia Orłowo","Gdynia Redłowo","Gdynia Stadion","Gdynia Stocznia – Uniwersytet Morski","Gdynia Wielki Kack","Gdynia Wzgórze Św. Maksymiliana","Geniusze","Gierałtowice","Gierałtów","Gierałtów Wykroty","Gierwaty","Gilów","Giżycko","Gliniczek","Gliniszcze","Glinnik","Glinnik Wieś","Gliwice","Gliwice Kuźnica","Gliwice Sośnica","Gliwice Łabędy","Gniewczyna","Gniewkowo","Gniezno","Gniezno Winiary","Gnilec","Goczałkowice","Goczałkowice-Zdrój","Goczałków","Gocły","Godki","Godków","Godurowo","Godów","Godętowo","Gogolewo","Gogolin","Gola","Golce","Golczewo Pomorskie","Goleniów","Goleszów","Goleszów Górny","Golina","Goliszów","Golub Dobrzyń","Golęczewo","Gomunice","Goniądz","Gonty","Goraj","Gorlice","Gorlice Glinik","Gorlice Zagórzany","Gorzanów","Gorzelin","Gorzkowice","Gorzuchowo Chełmińskie","Gorzuchów Kłodzki","Gorzupia","Gorzyca","Gorzyń Wielkopolski","Gorzów Chrzanowski","Gorzów Wielkopolski","Gorzów Wielkopolski Karnin","Gorzów Wielkopolski Wieprzyce","Gorzów Wielkopolski Wschodni","Gorzów Wielkopolski Zamoście","Gorzów Wielkopolski Zieleniec","Gorzędów","Gostomia","Gostynin","Gostyń","Goszcza","Goszczowice","Gosławice","Goworowo","Gozdowo","Gołaszewo Kujawskie","Gołańcz","Gołotczyzna","Gołubie Kaszubskie","Gołąb","Gołębiewko","Gościcino Wejherowskie","Gościszewo","Gościszów","Gośniewice","Goświnowice","Grabce","Grabianowo","Grabiny","Grabniak","Grabowno Wielkie","Grabowo","Grabów Szlachecki","Grabów nad Pilicą","Gracze","Grajewo","Gralewo","Grambow Gr","Granowiec","Granowo Nowotomyskie","Gregorowce","Grocholin","Grochowiska","Grodków Śląski","Grodzie","Grodziec Mały","Grodziec Niemodliński","Grodziec Śląski","Grodzisk Mazowiecki","Grodzisk Mazowiecki Jordanowice","Grodzisk Mazowiecki Okrężna","Grodzisk Mazowiecki Piaskowa","Grodzisk Mazowiecki Radońska","Grodzisk Wielkopolski","Grodzisko","Grodzisko Dolne","Grodziszcze Mazowieckie","Grom","Gromnik","Gronajny","Gronowo Elbląskie","Grotniki","Grudki","Grudze","Grudziądz","Grudziądz Mniszek","Grudziądz Owczarki","Grudziądz Przedmieście","Grupa","Grybów","Gryfice","Gryfino","Gryfów Śląski","Grylewo","Gryźliny","Grzegorzewice","Grzegorzewo","Grzmiąca","Grzybno","Grzybowa Góra","Grzybowo","Grzybów","Grzywna","Grzędzice Stargardzkie","Grzędzin Kozielski","Grzępa","Grzęska","Gródczanki","Gródek","Grąblewo","Grębocice","Grębocin","Gręboszów","Grębów","Gubin","Gubin (GR)","Gucin","Gumieniec","Gutowiec","Gutowo Pomorskie","Gutowo Wielkopolskie","Gułtowy","Gwda Mała","Gzin","Góra","Góra Kalwaria","Góralice","Górażdże","Górka Duchowna","Górki Noteckie","Górki Pomorskie","Górki Szczukowskie","Górki Śląskie","Górna Grupa","Górowo","Górzyca","Górzyca Reska","Górzyniec","Gąbin","Gącz","Gądki","Gądków Wielki","Gągławki","Gąsawy Plebańskie","Gąski","Gąsocin","Gębarzewo","Gęsia Górka","Głazów","Głogów","Głogów Huta","Głogów Małopolski","Głogówek","Głogówko","Głowaczewo","Głowno","Głubczyce","Głubczyce Las","Głuchowo","Głuchołazy","Głuchołazy Miasto","Głuchołazy Zdrój","Głuchów","Głuszyca","Głuszyca Górna","Głuszyno Pomorskie","Głębokie Międzyrzeckie","Hajnówka","Halinów","Hartowiec","Hel","Henrykowo","Henryków","Herby Nowe","Herby Stare","Hermanowice","Hordzieżka","Horyniec-Zdrój","Hołówki Duże","Hrebenne","Hrebenne Gr","Hrubieszów Miasto","Hryniewicze","Hucisko","Hurko","Huta","Huta Czechy","Huta Deręgowska","Huta Komorowska","Huta Krzeszowska","Idzikowice","Imbramowice","Imielin","Inowrocław","Inowrocław Mątwy","Inowrocław Rąbinek","Inwałd","Iwin","Iwiny","Iwowe","Izbica","Iława Główna","Iława Miasto","Iłowa Żagańska","Iłowiec","Iłowo","Jaborowice","Jabłonowo Pomorskie","Jabłoń Kościelna","Jackowice","Jackowo Dworskie","Jacków","Jadachy","Jadowniki","Jadwiżyn","Jagodna","Jagodzin","Jajkowo","Jaksice","Jaktorów","Jakubowice","Jakuszyce Gr","Jamielnik","Jamiołki","Janikowo","Janinów","Jankowa","Jankowa Żagańska","Jankowce","Jankowo Dolne","Jankowo Pomorskie","Janków Przygodzki","Janowice Wielkie","Janowiec Wielkopolski","Janówek","Jarnuty","Jarocin","Jarosty","Jaroszowiec Olkuski","Jarosław","Jarszewo","Jarzębia Łąka","Jarzębiec","Jasice","Jasienica","Jasienica Dolna","Jasienica Mazowiecka","Jasienica koło Bielska","Jasień","Jasień Brzeski","Jasiniec Białebłota","Jasiona","Jasionna Łowicka","Jaski","Jastarnia","Jastarnia Wczasy","Jastrowie","Jastrząb","Jastrząbka","Jastrzębie Pomorskie","Jastrzębie Zdr.Bzie","Jastrzębie Zdr.Górne","Jastrzębie Zdr.Mosz.","Jastrzębie Zdr.Rupt.","Jastrzębie Zdr.Szot.","Jastrzębie Zdr.Zof.","Jastrzębie Zdrój","Jastrzębie Śląskie","Jastrzębna","Jastrzębsko","Jaszczów","Jasło","Jasło Fabryczne","Jasło Niegłowice","Jawiszowice Jaźnik","Jawor","Jaworze Jasienica","Jaworzno Ciężkowice","Jaworzno Szczakowa","Jaworzno Szczakowa Lokomotywownia","Jaworzno koło Wielunia","Jaworzyna Śląska","Jazy","Jaśkowice","Jaśkowice Legnickie","Jaślany","Jaźwiny","Jedlanka","Jedlicze","Jedlicze Męcinka","Jedlina Górna","Jedlina-Zdrój","Jedlnia Kościelna","Jedlnia-Letnisko","Jeglia","Jelcz Miłoszyce","Jelcz-Laskowice","Jelenia Góra","Jelenia Góra Celwis.","Jelenia Góra Cieplice","Jelenia Góra Orle","Jelenia Góra Przemysłowa","Jelenia Góra Sobieszów","Jelenia Góra Zabobrze","Jelenia Góra Zachodnia","Jelenin","Jelenin Żagański","Jelenino","Jeleń","Jeleśnia","Jelna","Jelonki","Jemielna Oleśnicka","Jeruty","Jerzmanice Lubuskie","Jerzmanice-Zdrój","Jerzmanki","Jesionka","Jesionowiec","Jezierzany","Jezierzyce Słupskie","Jeziorany","Jeziorki Wałeckie","Jezioro Wirów","Jełowa","Jeżewice","Jeżewo","Jeżów Sudecki","Jeżówka","Jonkowo","Jordanów","Julianka","Jurata","Justynów","Juszczyn","Józefów","Józefów Roztoczański","Jędrzejów","Jędrzychowice","Kaczkowo","Kaczorowo","Kaczory","Kaczyce","Kadyny","Kadłub","Kalembina","Kaletnik","Kalety","Kaliska","Kaliska Kujawskie","Kalisz","Kalisz Kaszubski","Kalisz Pomorski","Kalisz Pomorski Miasto","Kalisz Szczypiorno","Kalisz Winiary","Kaliszki","Kalnica","Kalwaria Zebrzydowska","Kalwaria Zebrzydowska Lanckorona","Kamienica Elbląska","Kamienica Królewska","Kamieniec","Kamieniec Ząbkowicki","Kamienna Góra","Kamienna Karczma","Kamienna Nowa","Kamień Krajeński","Kamień Mały","Kamień Pomorski","Kamień Pomorski BUS","Kamień Łowicki","Kamień Śląski","Kamieńczyce","Kamieńsk","Kamionka Wielka","Kamionki Jezioro","Kanie","Kanie Helenowskie","Kaniów","Karcino","Karczyn","Karlino","Karnkowo","Karolinówka","Karpacz","Karpacz BUS","Karpacz Bachus","Karpacz Biały Jar","Karpacz Górny","Karpacz Morskie Oko","Karpacz Ośr. Zdrowia","Karpacz Pegaz","Karpacz Wang","Karsin","Kartuzy","Karwica Mazurska","Karwice","Karzec","Karłowice","Kasina Wielka","Katowice","Katowice Brynów","Katowice Kostuchna","Katowice Ligota","Katowice Murcki","Katowice Ochojec","Katowice Piotrowice","Katowice Podlesie","Katowice Szopienice Południowe","Katowice Zawodzie","Katowice Załęże","Kaunas (Kowno)","Kawcze","Kawki","Kawnice","Kazimierz Biskupi","Kazimierz Dolny","Kazimierz Pomorski","Kazimierówka","Kaługa","Kały","Kałęczyn","Kaźmierz Wlkp.","Kcynia","Kiekrz","Kielce","Kielce Białogon","Kielce Herbskie","Kielce Piaski","Kielce Słowik","Kielce Ślichowice","Kielcza","Kierzków","Kietlanka","Kietrz","Kiełpin","Kiełpino","Kiełpino Kartuskie","Kije","Kijewo","Kikowo","Kiszkowo","Kity","Klecza Dolna","Klecza Górna","Klembów","Klemensów","Klementowice","Klepacze","Kleszczele","Klewki","Klikowa","Klimontów","Kliniska","Klonowo koło Lidzbarka","Kluczbork","Klęczany","Klępicz","Klępnica","Knieje","Knurów","Knurów Kopalnia","Knurów Szczygł.","Knyszyn","Kobiałki","Kobierzyce","Kobiór","Kobylany","Kobylec","Kobylin","Kobylnica","Kobylnica Słupska","Kobyłka","Kobyłka Ossów","Kochanowice","Kochanówka Pustków","Kochcice-Glinica","Kojszówka","Kokotów","Kolbuszowa","Kolesin","Kolin","Kolonia","Kolonowskie","Kolumna","Koluszki","Komańcza","Komańcza Letnisko","Komorowo Pomorskie","Komorowo Żuławskie","Komorów","Komorów Podmurynia","Komprachcice","Konarskie","Koniecpol","Koniecpol Magdasz","Konin","Konin Marantów","Konin Niesłusz","Konin Zachód","Konin Żagański","Koniuchy","Konojady","Konopki","Konopne","Konotopie","Kopalina","Kornatowo","Kornelin","Kornica","Korsze","Korwinów","Korzenica","Korzeńsko","Korzybie","Korzystno","Kosewo","Kosina","Kosiorki","Kosowo Wielkopolskie","Kostki","Kostomłoty","Kostrzyn","Kostrzyn Gr","Kostrzyn Wielkopolski","Kostów","Koszalin","Koszewnica","Koszęcin","Kosów Lacki","Kotlin","Kotomierz","Kotowo","Kotulin","Kotuń","Kotórz Mały","Kowalewo Pom. Miasto","Kowalewo Pomorskie","Kowalów","Kownatki","Kozia Góra","Kozia Góra Krajeńska","Koziebrody","Koziegłowy","Kozielice","Koziki","Koziołek","Kozuby","Kozy","Kozy Zagroda","Kozów","Kozłowo","Kozłów","Kołacz","Kołaczkowo","Kołaki","Kołbiel","Kołczygłówki","Koło","Kołobrzeg","Kołobrzeg BUS","Kołobrzeg Stadion","Kołodziejewo","Kończyce","Kończyce Radomskie","Końskie","Końskowola","Kościan","Kościelec Kujawski","Kościernica","Kościerzyna","Koźla Kożuchowska","Koźlice","Koźmin Wielkopolski","Kożuchów","Krajenka","Kraków Batowice","Kraków Bieżanów","Kraków Bieżanów Drożdżownia","Kraków Bonarka","Kraków Bronowice","Kraków Business Park","Kraków Główny","Kraków Lotnisko","Kraków Lubocza","Kraków Mydlniki","Kraków Mydlniki Wapiennik","Kraków Młynówka","Kraków Nowa Huta","Kraków Olsza","Kraków Olszanica","Kraków Opatkowice","Kraków Podgórze","Kraków Podgórze P2","Kraków Prokocim","Kraków Płaszów","Kraków Sanktuarium","Kraków Sidzina","Kraków Swoszowice","Kraków Zabłocie","Kraków Zakliki","Kraków Złocień","Kraków Łagiewniki","Kraków Łobzów","Kramsk","Krasiejów","Kraski","Krasnołąka","Krasnystaw Fabryczny","Krasnystaw Miasto","Kraśnik","Kretki","Kretlewo","Krobia","Krobica","Krojanty","Krosno","Krosno Miasto","Krosno Odrzańskie","Krosno Polanka","Krosno Turaszówka","Krosnowa","Krosnowice Kłodzkie","Krostkowo","Krotoszyn","Krośnice","Krośnice Mazowieckie","Krupski Młyn","Krusze","Kruszwica","Kruszyna","Krynica-Zdrój","Krynka Łukowska","Krzcięcice","Krzemienica","Krzemieniewo","Krzemionki","Krzepice","Krzepów","Krzeszna","Krzeszowice","Krzewie","Krzewina Zgorzelecka","Krześnica Sarbinowo","Krzna","Krzycko Wielkie","Krzymosze","Krzywda","Krzywin Gryfiński","Krzywizna","Krzyż","Krzyż Rudno","Krzyżanowice","Krzyżowa","Królewo Malborskie","Kręcko","Krępa Krajeńska","Krężel","Krężnica Jara","Książ Wlkp.","Książki","Książno","Księginice","Kubice","Kudowa-Zdrój","Kuklinów","Kuleje","Kulesze Kościelne","Kulice Tczewskie","Kulin Kłodzki","Kundzin","Kunowice","Kunowice Gr","Kunowo Kujawskie","Kunów","Kupienin","Kupienino","Kuriany","Kurowo Braniewskie","Kurpie","Kursko","Kurzętnik","Kurów Suski","Kusięta Nowe","Kustrzyce","Kutno","Kutno Azory","Kuźnia Raciborska","Kuźnica (Hel)","Kuźnica Białostocka","Kuźnica Białostocka Gr","Kwiatki","Kwidzyn","Kwieciszowice","Kwilcz","Kórnik","Kąkolewo","Kątne","Kąty Wrocławskie","Kędzierak PZS","Kędzierzyn Blachow.","Kędzierzyn-Koźle","Kędzierzyn-Koźle Azoty","Kędzierzyn-Koźle Przystanek","Kędzierzyn-Koźle Zachodnie","Kępa","Kępice","Kępka","Kępno","Kęszyce","Kętrzyn","Kętrzyno","Kęty","Kęty Podlesie","Kłaj","Kłecko Wielkopolskie","Kłobuck","Kłobuczyn","Kłodawa","Kłodnica R9","Kłodzko Główne","Kłodzko Książek","Kłodzko Miasto","Kłodzko Nowe","Kłodzko Zagórze","Kłokowa","Kłomnice","Kłosowice","Kłudna","Kłyżów","Lachowice","Lachowice Centrum","Laliki","Las Suwalski","Lasek","Laski","Laski Lubuskie","Laski Odrzańskie","Laski Tucholskie","Laskowice Oleskie","Laskowice Pomorskie","Laskownica","Lasocice","Lasowice Małe Oleskie","Lasów","Lednogóra","Legionowo","Legionowo Piaski","Legionowo Przystanek","Legnica","Legnica Piekary","Lekartów","Leluchów","Leokadia","Leopoldów","Leosia","Lesiów","Lesięcin","Lesko","Lesko Łukawica","Leszczydół","Leszczyny","Leszno","Leszno Grzybowo","Leszno Górne","Leszno Kartuskie","Letnica","Lewickie","Lewin Brzeski","Lewin Kłodzki","Lewki","Lewki R2","Leńcze","Leśnica","Leśnice","Leśniczówka","Leżajsk","Libiąż","Libusza","Licze","Lidzbark","Lidzbark Miasto","Lidzbark Warmiński","Ligota Toszecka","Ligowiec","Limanowa","Linia Zakrzewo","Linie","Linkowo","Linowo","Lipa","Lipce Reymontowskie","Lipiany","Lipie Góry","Lipienica","Lipinki","Lipinki Łużyckie","Lipińskie Małe","Lipka Krajeńska","Lipki","Lipniak","Lipno","Lipno Nowe","Lipowa Tucholska","Lipowa Wschodnia","Lipowa Śląska","Lipowe Pole","Lipuska Huta","Lipusz","Lisewo","Lisie Pole","Lisiowólka","Lisowice","Lisowo","Lisów","Lizawice","Lniano","Lotyń","Lubaczów","Lubajny","Lubania-Lipiny","Lubanice","Lubanie","Lubanowo","Lubartów","Lubartów Lipowa","Lubartów Słowackiego","Lubaszowa","Lubawka","Lubawka Gr","Lubań Śląski","Lubicz","Lubiechnia Mała","Lubiewo","Lubin (Górniczy)","Lubin Stadion","Lublin Airport","Lublin Główny","Lublin Ponikwoda","Lublin Północny","Lublin Północny PODG","Lublin Zachodni","Lublin Zadębie","Lublin Zalew","Lublin Zemborzyce","Lubliniec","Lubnia","Lubogoszcz","Lubomino","Lubosina","Lubosz k/Międzychodu","Luboń koło Poznania","Lubsko","Lubycza Królewska","Lubzina","Luciążanka","Lucynów","Ludwikowice Kłodzkie","Ludynia","Ludynia Dwór","Lusławice","Lutol Suchy","Luzino","Lwówek Śląski","Lądek Stojków","Lądek Zdrój","Lębork","Lębork Mosty","Lębork Nowy Świat","Lędziechowo","Lędziny","Machnacz","Maciowakrze","Majdan","Majdan Kolejka","Majdan Królewski","Majdan Królewski Podlasek","Majdan Stuleński","Majewo","Maksymilianowo","Maków","Maków Podhalański","Malbork","Malbork Kałdowo","Malce","Malczyce","Malhowice","Malichy","Maliniec","Malinka Bajczary","Malinka Skocznia","Manieczki","Marcinkowice","Marcinkowo","Marcinków","Marcinowice Świdnickie","Marciszów","Marczów","Markuszowa","Marków","Martiany","Marzenin","Masłońskie Natalin","Matysy","Maziły","Maćkowo","Małaszewicze Przystanek","Małdyty","Małe Gacno","Małki","Małkinia","Małogoszcz","Małomice","Małowice Wołowskie","Mańkowice","Mechowo Łobeskie","Medyka","Medyka Gr","Medyka Rozrządowa","Medyka Towarowa","Metan","Metelin","Mełno","Miasteczko Krajeńskie","Miasteczko Śląskie","Miastko","Miały","Michalczew","Michalin","Michałowice","Michałów-Reginów","Miechucino","Miechów","Miedary","Miedwiecko","Miedźno","Miejsce","Mielec","Mieleszyn","Mielno Koszalińskie","Mielęcin Myśliborski","Mielęcin Wałecki","Mienia","Mieroszów","Mieroszów Gr","Mierzęcin Strzelecki","Mieszaki","Mieszkowice","Mieszków","Mietków","Mika","Mikołajki","Mikołajki Pomorskie","Mikołajów","Mikołów","Mikołów Jamna","Mikulowice -gr. pań.","Mikułowa","Mikłasze","Milanów","Milanówek","Milanówek Grudów","Milcz","Milcza","Milejów","Milicz","Milik","Milówka","Milówka Zabawa","Minkowice","Minkowice Oławskie","Mirakowo","Mirosław Ujski","Mirosławiec","Mirsk","Misie","Miączyn","Miąsowa","Międzyborów","Międzybórz Sycowski","Międzychód","Międzychód Letnisko","Międzylesie","Międzylesie Gr","Międzyrzec Podlaski","Międzyrzecz","Międzyzdroje","Miękinia","Miłkowice","Miłków","Miłobądz","Miłocin (Rzeszów)","Miłocin Lubelski","Miłocin Polam","Miłogoszcz","Miłosław","Mińsk Mazowiecki","Mińsk Mazowiecki Anielina","Mińsk Mazowiecki R.4","Mleczewo","Mlewiec","Modgarby","Modlin","Modła","Mogilno","Mojusz","Mokra","Mokra Częstochowska","Mokra Wieś","Mokre","Mokre Małopolskie","Mokronos Górny","Mokrz","Mokrzyca","Mokrzyca Wielka","Montowo","Morany","Mordy","Mordy Miasto","Morochów","Morze","Morzeszczyn","Morzyca","Morąg","Morąg Kolonia","Mosina","Mosina Pożegowo","Moskale","Most Wisła","Mostiska I - gr. panstwa","Mostki","Mosty","Mostówka","Moszczenica","Moszczenica Małopolska","Moszczenica Pomorska","Motycz","Motycz Leśny","Motylewo","Mońki","Mościsko Dzierżoniowskie","Mrocza","Mrowino","Mrozy","Mrozów","Mrzezino","Mrzeżyno","Mrzeżyno, ul. Kołobrzeska","Mrągowo","Mstyczów","Mszalnica","Mszana Dolna","Mszana Dolna Marki","Mszczonów","Munina","Murowana Goślina","Murów","Muszaki","Muszyna","Muszyna Gr","Muszyna Poprad","Muszyna Zdrój","Mykanów","Myszków","Myszków Mrzygłód","Myszków Nowa Wieś","Myszków Światowit","Mysłakowice","Mysłakowice Orzeł","Mysłaków","Mysłowice","Mysłowice Brzezinka","Mysłowice Brzęczkowice","Mysłowice Kosztowy","Mysłowice Wesoła","Myślibórz","Myślice","Myśliczyn","Myślina Lubliniecka","Mąkoszyce","Męcikał","Męcina","Męcina Podgórze","Męcka Wola","Mędrzechów","Mława","Mława Miasto","Młodów","Młynary","Młyńsko","Mścice","Nadbrzeże","Nadolice Małe","Nadolice Wielkie","Najmowo","Nakło nad Notecią","Nakło Śląskie","Namysłów","Namyślin","Napiwoda","Narewka","Narzym","Nasielsk","Naterki","Nawcz","Nawra","Nałęczów","Nałęczów Miasto","Nekla","Nicwałd","Nida","Nidzica","Niechorze","Niedomice","Niedoradz","Niedrzwica","Niedrzwica Kościelna","Niedźwiada Łowicka","Niedźwiedź","Niedźwiedź Wielkopolski","Niegocin","Niegosławice","Niekłonice","Niekłończyca Uniemyśl","Nielep","Nielubia","Niemce","Niemodlin","Niemojki","Niepoczołowice","Nieporęt","Niepołomice","Niepołomice Pastern.","Nieszawa Waganiec","Nieszawka PODG","Nietkowice","Nietków","Niewierz","Niewodnica","Nieznany Bór","Nisko","Nisko Osiedle","Nisko Podwolina","Nisko Racławice","Niwnice","Niziny","Nojewo","Nosówko","Nowa Dęba","Nowa Grobla","Nowa Iwiczna","Nowa Ruda","Nowa Ruda Przedmieście","Nowa Sarzyna","Nowa Sarzyna Kolonia","Nowa Sucha","Nowa Sól","Nowa Wieś Cierpkie","Nowa Wieś Ełcka","Nowa Wieś Kościelna","Nowa Wieś Legnicka","Nowa Wieś Lęborska","Nowa Wieś Poznańska","Nowa Wieś Warszawska","Nowa Wieś Wielka","Nowawieś Mochy","Nowe Chrapowo","Nowe Czaple","Nowe Drezdenko","Nowe Dębe Wielkie","Nowe Kutnowskie","Nowe Miasto Lubaws.","Nowe Objezierze","Nowe Skalmierzyce","Nowielin","Nowiny","Nowiny Wielkie","Nowogard","Nowogrodziec","Nowogród Bobrzański","Nowogród Osiedle","Nowosielce","Nowy Bieruń","Nowy Dwór Gdański","Nowy Dwór Mazowiecki","Nowy Jarosław","Nowy Las","Nowy Młyn","Nowy Nurzec","Nowy Solec","Nowy Sącz","Nowy Sącz Biegonice","Nowy Sącz Chełmiec","Nowy Sącz Jamnica","Nowy Sącz Miasto","Nowy Targ","Nowy Targ Bus","Nowy Tomyśl","Nowy Widzim","Nowy Zagórz","Nowy Łupków","Nowy Łupków BUS","Nowy Świętów","Nurzec","Nysa","Nysa Wschodnia","Nędza","Nędza Wieś","Obkas","Obora Wielkopolska","Oborniki Wielkopolskie","Oborniki Wielkopolskie Miasto","Oborniki Śląskie","Oborzyska Stare","Obra Stara","Obrowo","Obryta","Ocice","Ociąż","Odoje","Odolanów","Odolion","Ognica","Ogorzeliny","Ograszka","Ogrodniki","Okartowo","Okleśna","Okmiany","Okonek","Okrzeja","Okrąglica","Okunica","Okuninka Białe","Olbrachtowice","Olecko","Olecko Małe","Olekszyn","Olesno Tarnowskie","Olesno Śląskie","Oleszyce","Oleśnica","Oleśnica Rataje","Olkusz","Olpuch","Olpuch Wdzydze","Olszanica","Olszanka","Olszewka","Olszewo","Olsztyn Dajtki","Olsztyn Gutkowo","Olsztyn Główny","Olsztyn Jezioro Ukiel","Olsztyn Likusy","Olsztyn Redykajny","Olsztyn Zachodni","Olsztyn Śródmieście","Olsztynek","Olszyna Lubańska","Olszyny","Olza","Opacz","Opalenica","Opatówek","Opoczno","Opoczno Południe","Opole Borki","Opole Chmielowice","Opole Czarnowąsy","Opole Gosławice","Opole Groszowice","Opole Grotowice","Opole Główne","Opole Wschodnie","Opole Zachodnie","Orlanka","Orneta","Orzechowicze","Orzechowo","Orzesze","Orzesze Jaśkowice","Orzesze Miasto","Orzesze Zawada","Orzesze Zawiść","Orzeszkowo","Orzeszków","Orzysz","Osetnica","Osie","Osieck","Osiek Drawski","Osiek Staszowski","Osielec","Osina","Osola","Osowa Góra","Osowiec","Osowiec Przystanek","Osowiec Śląski","Ostaszewo Toruńskie","Ostromecko","Ostroróg","Ostrowie Biebrzańskie","Ostrowiec Świętokrzyski","Ostrowite k/Golubia","Ostrowite koło Jabłonowa","Ostrowy","Ostrołęka","Ostrzeszów","Ostróda","Ostrów Maz. Miasto","Ostrów Mazowiecka","Ostrów Wielkopolski","Ostrów Wielkopolski Gorzyce","Ostrów koło Radymna","Ostrówek Węgrowski","Ostrówki koło Chodzieży","Osusz","Osława Dąbrowa","Osławica","Otmuchów","Otmuchów Jezioro","Otoczna","Otok","Otrębusy","Otusz","Otwock","Otłoczyn","Owińska","Ozimek","Ozorków","Ozorków Nowe Miasto","Oława","Ołdrzychowice Kłodzkie","Ośno Lubuskie","Oświęcim","Ożarów Mazowiecki","Pabianice","Pacholęta","Paczkowo","Paczków","Paczyna","Padew","Pakosławice","Pakość","Palowice","Palowice Kolonia","Palędzie","Pamiątkowo","Panienka","Panigródz","Panki","Panowice","Papiernia","Papowo Toruńskie","Parchatka","Parciaki","Parczew","Parczew Kolejowa","Parkowo","Parleza Wielka","Parlin","Parys","Parysów","Parzniew","Parłówko","Pasieki","Pasikurowice","Pasym","Pasłęk","Paterek","Patków","Patrzyków","Pawonków","Pawłowice","Pawłowice Małe","Pawłowice Śląskie","Pawłowiczki","Pawłów Wielkopolski","Pawłówek","Pałecznica","Pelplin","Perkowice","Perkowo","Perzów","Petrykozy","Pewel Mała","Pewel Wielka","Pewel Wielka Centrum","Pełkinie","Piasecznica","Piaseczno","Piasek","Piaski Pomorskie","Piaski Wielkopolskie","Piastoszyn","Piastów","Piechcin","Piechowice","Piechowice Dolne","Pieczyska","Piekiełko","Piekoszów","Pieniężno","Pierwoszów Miłocin","Pierzchno","Pierzyska","Pierławki","Pierściec","Piesienice","Pietrowice Wielkie","Pietrzykowice Żywieckie","Pieńki Dubidzkie","Pieńsk","Pikus","Pilawa","Pilawa R4","Pilchowice Nielestno","Pilchowice Zapora","Pilchów","Pinczyn","Pionki","Pionki Zachodnie","Piotrków Kujawski","Piotrków Trybunalski","Pisarzowa","Pisz","Pisz Wschodni","Piwniczna","Piwniczna-Zdrój","Piła Główna","Piła Kalina","Piła Kościelecka","Piła Leszków","Piła Podlasie","Piława Dolna","Piława Górna","Pińsko Wielkopolskie","Platerów","Pleszew","Pliszka","Pludry","Pniewy Szamotulskie","Pobiedziska","Pobiedziska Letnisko","Pobierowo, p.dw.","Podbiele","Podborsko","Podbory Skawińskie","Podbór","Podczele","Poddubówek","Poddębice","Podgrabie Wisła","Podkowa Leśna Główna","Podkowa Leśna Wschodnia","Podkowa Leśna Zachodnia","Podlasek","Podlesie","Podlesiec","Podleś","Podnieśno","Podolany","Podstolice","Podwierzbie","Podzamcze","Podłęże","Pogorzel Warszawska","Pogorzel Wielka","Pogorzelica","Pogorzelice","Pogorzyce","Pogwizdów","Pogórze","Pokrzywnica","Polanica-Zdrój","Polanki","Polańczyk","Polesie","Police","Police Zakład","Polichna Kraśnicka","Policko","Policzna","Polna","Polnica","Polska Cerkiew","Pomiechówek","Pomorsko","Poniatowice","Poniec","Ponętów","Popielów","Popowo Skwierzyńskie","Poradz","Poraj","Porażyn","Poronin","Porosiuki","Port Lotniczy Szczecin Goleniów","Potok","Potok Kraśnicki","Potęgowo","Powałki","Powroźnik","Poznań Antoninek","Poznań Dębiec","Poznań Dębina","Poznań Franowo","Poznań Garbary","Poznań Górczyn","Poznań Główny","Poznań Junikowo","Poznań Karolin","Poznań Kobylepole","Poznań Krzesiny","Poznań MD","Poznań MK","Poznań Piątkowo","Poznań Podolany","Poznań Starołęka","Poznań Strzeszyn","Poznań Wola","Poznań Wschód","Połaniec","Połczyn Zdrój","Połowite","Prabuty","Prabuty Góry","Prakwice","Prażmów","Prioma","Proboszczewice Płockie","Prokowo","Promno","Prostki","Prostynia","Prostyń","Pruchna","Prudnik","Prusim","Prusinowo Wałeckie","Pruszcz Gdański","Pruszcz Pomorski","Pruszków","Pruszków WKD","Przebędowo","Przechlewo","Przeciszów","Przecza","Przecław Szprotawski","Przedmoście Święte","Przemysław","Przemyśl Bakończyce","Przemyśl Główny","Przemyśl Pikulice","Przemyśl Zasanie","Przeradz","Przetycz","Przeworsk","Przezchlebie","Przełęk","Przeździęk Wielki","Przybroda","Przybyłowice","Przybówka","Przygodzice","Przyjezierze Moryn","Przykopka","Przysieczyn","Przysieka Stara","Przysieki","Przysucha","Przyszowice","Przytkowice","Przytocko","Przytoczna","Przywory Opolskie","Przyłubie","Przyłęk Duży","Prądocin","Psary","Pszczew","Pszczyna","Pszczyna Czarków","Pszczółki","Pszenno","Ptaszkowa","Ptaszkowo Wielkopolskie","Ptusza","Puchałowo","Puck","Pustków","Pustków Żurowski","Pustynia","Puszcza Mariańska","Puszcza Rządowa","Puszczykowo","Puszczykówko","Pułankowice","Puławy","Puławy Azoty","Puławy Centrum","Puławy Chemia","Puławy Miasto","Pyrzyce","Pyskowice","Pyskowice Miasto","Pysząca","Pyzówka","Pólko","Półwieś","Pątnów","Pątnów Elektrownia","Pątnów Wieluński","Pęckowo","Pęgów","Pępowo","Pępowo Kartuskie","Pęzino","Pławna","Płaza","Płochocin","Płociczno koło Suwałk","Płock","Płock Radziwie","Płock Trzepowo","Płonka","Płoty","Płońsk","Płośnica","Płytnica","Płyćwia","Raba Niżna","Raba Wyżna","Rabka Zaryte","Rabka-Zdrój","Racewo","Racibory","Raciborów Kutnowski","Racibórz","Racibórz Markowice","Racibórz Studzienna","Raciąż","Raczki","Raczyce","Racławice Śląskie","Racławki","Radkowice","Radliczyce","Radlin Obszary","Radlin Wielkopolski","Radnica","Radochów","Radocza","Radom","Radom Gołębiów","Radom Potkanów","Radom Południowy","Radom Północny","Radom Stara Wola","Radomno","Radomsko","Radomyśl","Radostowice","Radoszki","Raduń","Radymno","Radzice","Radziechowy Wieprz","Radzikowice","Radzikowo","Radzionków","Radzionków Rojca","Radziszów","Radziszów Centrum","Radziwiłłów Mazowiecki","Radzymin","Radzyń Podlaski","Radów","Rajcza","Rajcza Centrum","Rajec Poduchowny","Rajgród","Rajsk","Rakoniewice","Rakoniewice Milickie","Rakowice","Rakowice Wielkie","Rakowiec Pomorski","Ramiszów","Raszowa","Raszujka","Raszówka","Rawicz","Reblino","Recz Pomorski","Recław","Reda","Reda Pieleszewo","Reda Rekowo","Redaki","Redło","Regalica","Regny","Regulice","Regulice Górne","Reguły","Rejowiec","Reptowo","Resko Północne","Reskowo","Reszel","Rewal","Reńska Wieś","Rogale","Rogalice","Rogiedle","Rogowo","Rogoźnica","Rogoźnica Fadom","Rogoźnica koło Rzeszowa","Rogoźno Wielkopolskie","Rogożew","Rogów","Rogów Sobócki","Rogóźno Pomorskie","Rogóżno koło Łańcuta","Rokiciny","Rokiciny Podhalańskie","Rokietnica","Rokita","Rokitki","Rokitki Tczewskie","Rokitnia Stara","Rokitno","Ropczyce","Ropczyce Witkowice","Rosnowo Chojeńskie","Rosochatka","Rostarzewo","Roszki Leśne","Roszkowo Wągrowieckie","Roszków Raciborski","Rozedranka","Rozmierka","Rozprza","Roztoki Bystrzyckie","Rozłazino","Rościn Krajeński","Rożki","Rożniaty","Rożnowo","Rubno Wielkie","Ruchocice","Ruciane-Nida","Ruciane-Nida Zachód","Ruda","Ruda Białaczowska","Ruda Chebzie","Ruda Kochłowice","Ruda Talubska","Ruda Wielka","Ruda Wirek","Ruda Śląska","Ruda-Huta","Ruda-Opalin","Rudawa","Rudna Gwizdanów","Rudna Miasto","Rudna Wielka","Rudnik","Rudnik Stróża","Rudnik nad Sanem","Rudniki koło Częstochowy","Rudyszwałd","Rudzienice Suskie","Rudziniec Gliwicki","Rumia","Rumia Janowo","Runowo Krajeńskie","Runowo Pomorskie","Runowo koło Wągrowca","Rurka","Rusiec","Rusiec Łódzki","Rusinowice","Rusinowo","Ruskie Piaski","Ruszów","Rutkowice","Rutwica","Rybienko","Rybnica","Rybnik","Rybnik Gotartowice","Rybnik Niedobczyce","Rybnik Niewiadom","Rybnik Paruszowiec","Rybnik Piaski","Rybnik Rymer","Rybnik Towarowy","Rybno Pomorskie","Rybno Wielkie","Rycerka","Rychnowo Wielkie","Ryczów","Rydułtowy","Rydzyna","Ryjewo","Ryki","Rykoszyn","Rynarcice","Rynarzewo","Rynkowo","Rynkowo Wiadukt","Rypin","Rytel","Rytel Wieś","Rytro","Rytwiany","Ryżyn","Rzeczyca","Rzeczyca-Kolonia","Rzeczyce Śląskie","Rzemień","Rzepedź","Rzepin","Rzepnowo","Rzerzęczyce","Rzeszotary","Rzeszów Główny","Rzeszów Osiedle","Rzeszów Staroniwa","Rzeszów Zachodni","Rzeszów Załęże","Rzeszów Zwięczyca","Rzezawa","Rzochów","Rzozów","Rząsawa","Rzęśnica","Róg","Rów","Różanystok","Różańsko","Różyna Warmińska","Różyny","Rąbino","Rębiechowo","Rębiszów","Rębusz","Sabinka","Sadlinki","Sadowice Wrocławskie","Sadowne Węgrowskie","Sadurki","Sady","Samborowo","Samostrzel","Sandomierz","Sanok","Sanok Dąbrówka","Sanok Miasto","Santok","Sarbiewo","Sarnaki","Sarnów","Serock","Seroki","Sidra","Siechnice","Siedlce","Siedlce Wschodnie","Siedlce Zachodnie","Siedlce Łaskie","Siedlec Trzebnicki","Siedliska","Siedliska Tomaszowskie","Siedliska koło Tuchowa","Siedlisko Czarnkowskie","Siedlęcin","Siemianówka","Siemiatycze","Sieniawa","Sieniawa Drawieńska","Sieniawa Żarska","Siepietnica","Sieradz","Sieradz Męka","Sieradz Warta","Sierakowice","Sierakowice Skierniewickie","Sieraków Wielkopolski","Sieraków Śląski","Sierakówek","Sierpc","Sierpów","Silno","Silnowo","Sitkówka Nowiny","Sitno","Sitowa","Siódmak","Sińczyca","Skalmierz","Skandawa","Skarszewy","Skarżysko Kościelne","Skarżysko Milica","Skarżysko Zachodnie","Skarżysko-Kamienna","Skawa","Skawa Środkowa","Skawce","Skawina","Skawina Jagielnia","Skawina Zachodnia","Skibno","Skierniewice","Skierniewice Rawka","Sklęczki","Skoczów","Skoczów Bajerki","Skoczów Bładnice","Skoki","Skokowa","Skomack Wielki","Skopanie","Skoroszyce","Skorzewo","Skowarcz","Skołyszyn","Skrzatusz","Skrzydlna","Skrzynki","Skrzynno","Skwierzyna","Skórka","Skępe","Smardy","Smardzew","Smardzko","Smardzów Wrocławski","Smogory","Smogorzów Przysuski","Smolec","Smoleń","Smolniki","Smroków","Smętowo","Sobibór","Sobieradz","Sobków","Sobolew","Sobowidz","Sobótka","Sobótka Zachodnia","Sobów","Sochaczew","Sokole Białostockie","Sokoliniec","Sokołowo Budzyńskie","Sokołowo Wrzes. PODG","Sokoły","Sokołów Podlaski","Sokule","Sokółka","Solec Kujawski","Solec Wielkopolski","Solniki Wielkie","Somonino","Sopot","Sopot Kamienny Potok","Sopot Wyścigi","Sorkwity","Sosnowe","Sosnowiec Dańdówka","Sosnowiec Główny","Sosnowiec Jęzor","Sosnowiec Kazimierz","Sosnowiec Maczki","Sosnowiec Porąbka","Sosnowiec Południowy","Sosnowo Gryfińskie","Sowczyce","Sowin","Sowno","Sołtyków","Sośnica Jarosławska","Sośnie Ostrowskie","Spała","Sporok","Spychowo","Spytkowice","Spytkowice Kępki","Spławie","Stalowa Wola","Stalowa Wola Centrum","Stalowa Wola Charzewice","Stalowa Wola Południe","Stalowa Wola Rozwadów","Staniszcze Małe","Staniszcze Wielkie","Stanisławice","Staniątki","Stanowice","Stara Kamienica","Stara Kopernia","Stara Korytnica","Stara Wieś","Stara Łubianka","Starachowice","Starachowice Michałów","Starachowice Wschodnie","Starczów","Stare Berezowo","Stare Bielice","Stare Bojanowo","Stare Chrapowo","Stare Drzewce","Stare Guty","Stare Jabłonki","Stare Juchy","Stare Kurowo","Stare Ludzicko","Stare Olesno","Stare Pole","Stargard","Stargard Kluczewo","Stargard Osiedle","Starkowo","Starogard Gdański","Starogard Łobeski","Staropole Częstochowskie","Stary Borek","Stary Chwalim","Stary Garbów","Stary Grodków","Stary Jawor","Stary Klukom","Stary Sącz","Stary Wielisław","Stary Węgliniec","Stary Łążek","Starzyny PO","Starzyny PODG","Stasin Polny","Staszów","Staw Kunowski","Stawiany","Stawiany Pińczowskie","Stawiguda","Stawno","Stawy","Stefanowo","Stegny","Steknica","Sterkowiec","Sterławki Małe","Sterławki Wielkie","Stobno","Stobno Szczecińskie","Stoczek Łukowski","Stogi Malborskie","Stok Lacki","Strabla","Stradomia","Stramnica","Straszewo Białostockie","Strażów","Stronie","Stronie Śląskie","Stronie Śląskie PKS","Stronno","Strumiany","Strumień","Strykowo Poznańskie","Stryków","Stryszawa","Stryszów","Strzałkowo","Strzebielewo Pyrzyckie","Strzebielino Morskie","Strzebiń","Strzegom","Strzegomek","Strzelce Krajeńskie Wschód","Strzelce Kujawskie","Strzelce Opolskie","Strzelce Świdnickie","Strzelin","Strzelinko","Strzelno","Strzyżyna","Strzyżyno Słupskie","Strzyżów nad Wisłokiem","Stróże","Strączno","Studzianka","Studzianki Nowe","Studzienice","Studzieniec","Studzienki","Stulno","Stupsk Mazowiecki","Styków Iłżecki","Stypułów","Stąporków","Stępień","Stęszew","Subkowy","Subkowy Centrum","Sucha Beskidzka","Sucha Beskidzka Rynek BUS","Sucha Beskidzka Zamek","Sucha Żyrardowska","Suchacz Zamek","Suchatówka","Suchedniów","Suchedniów Północny","Suchowolce","Suchy Bór Opolski","Sukowice","Sulechów","Sulejówek","Sulejówek Miłosna","Sulików","Sulino","Suliszewo Choszczeńskie","Suliszewo Drawskie","Sulów","Sulęcin","Sulęcinek","Sumina","Sumina Wieś","Surochów","Susiec","Susk","Susz","Suszec","Suszec Kopalnia","Suszec Rudziczka","Suszka","Suwałki","Sułkowice","Swarożyn","Swarzewo","Swarzędz","Swobodna","Swędów","Sycewice","Sycze","Syców","Szachy","Szadek","Szadkowice","Szaflary","Szaflary Wieś","Szalowa","Szamotuły","Szaniawy","Szaradowo Zalesie","Szarbków","Szarów","Szastarka","Szałamaje","Szczaniec","Szczawne Kulaszne","Szczebrzeszyn","Szczecin Drzetowo","Szczecin Dąbie","Szczecin Dąbie Osiedle","Szczecin Glinki","Szczecin Gocław","Szczecin Golęcino","Szczecin Gumieńce","Szczecin Główny","Szczecin Kluczewo","Szczecin Mścięcino","Szczecin Podjuchy","Szczecin Pogodno","Szczecin Pomorzany","Szczecin Port Centralny","Szczecin Skolwin","Szczecin Turzyn","Szczecin Wstowo","Szczecin Wzgórze Hetmańskie","Szczecin Załom","Szczecin Zdroje","Szczecin Zdunowo","Szczecin Łękno","Szczecin Żelechowo","Szczecinek","Szczecinek Chyże","Szczedrzykowice","Szczeglin","Szczejkowice","Szczekarków","Szczekociny","Szczepankowo","Szczepanowice","Szczepanów","Szczepice","Szczepki","Szczucin k/Tarnowa","Szczutowo","Szczygłowice Kopaln.","Szczyrk","Szczytna","Szczytno","Szebnie","Szeligi","Szepietowo","Szeroki Bór","Szewce","Szewnica","Szklarska Poręba Dolna","Szklarska Poręba Górna","Szklarska Poręba Huta","Szklarska Poręba Jakuszyce","Szklarska Poręba Średnia","Szlachta","Szozdy","Szołdry","Szprotawa","Szpęgawsk","Szramowo","Szreniawa","Szropy","Sztum","Sztumska Wieś","Szubin","Szulborze-Koty","Szumirad","Szybowice","Szybowice Wałbrzys.","Szydłowiec","Szydłowiec Śląski","Szydłowo Krajeńskie","Szydłów","Szydłów Centrum","Szymankowo","Szymany","Szymany Lotnisko","Szymbory","Szymiszów","Szymocice","Sól","Sól Kiczora","Sąpolno Człuchowskie","Sątopy","Sątopy-Samulewo","Sędzice","Sędziszów","Sędziszów Małopolski","Sędzisław","Sępólno Krajeńskie","Sława Wielkopolska","Sławięcice","Sławki","Sławków","Sławno","Słobity","Słomianka","Słomniki","Słomniki Miasto","Słonice","Słonowice","Słosinko","Słotwiny","Słowienkowo","Słubice","Słupca","Słupia","Słupsk","Słupsk Północny","Taciszów","Taczanów","Tama Brodzka","Tantow Gr","Tarchały Wielkie","Tarczyn","Targowiska","Tarnawa Dolna","Tarnobrzeg","Tarnowiec","Tarnowiec Brzeski","Tarnowo Pomorskie","Tarnowo Rogozińskie","Tarnowska Wola","Tarnowskie Góry","Tarnowskie Góry Strzybnica","Tarnów","Tarnów Mościce","Tarnów Opolski","Tarnów Północny","Tarzymiechy","Tarło","Tczew","Telaki","Templewo","Teresin Niepokalanów","Terespol","Terespol Gr","Terespol Pomorski","Tereszpol Biłgorajski","Tetyń","Tleń","Tokary","Tolkmicko","Tolkniki Wielkie","Tomaszów Bolesławiecki","Tomaszów Mazowiecki","Tomaszów Mazowiecki Białobrzegi","Topola-Osiedle","Toporów","Topór","Toruń Czerniewice","Toruń Główny","Toruń Kluczyki","Toruń Miasto","Toruń Wschodni","Torzym","Toszek","Toszek Północ","Tołkiny","Trakiszki","Trakiszki Gr","Trawniki","Treblinka","Tropy Igły","Tropy PODG","Troszyn","Truskolas","Trypucie","Tryńcza","Trzciana","Trzcianka","Trzciniec","Trzcińsko","Trzcińsko Zdrój","Trzebaw Rosnówko","Trzebiatów","Trzebiatów BUS","Trzebiel","Trzebieszowice","Trzebieńczyce","Trzebież Szczeciński","Trzebinia","Trzebiszewo","Trzebnica","Trzebórz","Trzemeszno","Trzemeszno Lubuskie","Trzęsacz","Trąbki","Tuchlin","Tuchola","Tuchorza","Tuchów","Tuczki","Tuczno Krajeńskie","Tumlin","Tunel","Tuplice","Tuplice Dębinka","Turbia","Turoszów","Turoszów Kopalnia","Turowo Pomorskie","Turza Wielka","Turza Śląska","Turzno","Turzno Kujawskie","Turzynów","Turów","Tuszyma","Tuszów Narodowy","Tułowice","Tuły","Twarda Góra","Twardawa","Twardogóra","Tworki","Tworków","Tworóg","Tworóg Brynek","Tychowo","Tychy","Tychy Aleja Bielska","Tychy Czułów","Tychy Grota Roweckiego","Tychy Górki","Tychy Lodowisko","Tychy Miasto","Tychy Urbanowice","Tychy Zachodnie","Tychy Żwaków","Tymbark","Tymień","Tłoki","Tłustomosty","Tłuszcz","Ubocze","Ugoszcz","Uherce","Uherce Tunel","Uhowo","Uhrusk","Uhrusk Przystanek","Ujście Noteckie","Ulikowo","Unibórz","Unieszewo","Unisław Pomorski","Unisław Śląski","Urle","Ustanówek","Ustianowa","Ustka","Ustka Uroczysko","Ustronie Morskie","Ustroń","Ustroń Polana","Ustroń Poniwiec","Ustroń Zdrój","Ustrzyki Dolne","Ustrzyki Górne","Wadowice","Wadowice Osiedle Podhalanin","Walawa","Waliły","Wandzin","Wapienno Przystanek","Waplewo","Waplewo Wielkie","Wapno","Wardyń","Wargowo","Warka","Warka Miasto","Warkocz","Warlubie","Warnice Dębica","Warnowo","Warszawa Aleje Jerozolimskie","Warszawa Aleje Jerozolimskie WKD","Warszawa Anin","Warszawa Antoninów","Warszawa Centralna","Warszawa Choszczówka","Warszawa Dawidy","Warszawa Falenica","Warszawa Gdańska","Warszawa Gocławek","Warszawa Gołąbki","Warszawa Główna","Warszawa Jeziorki","Warszawa Koło","Warszawa Lotnisko Chopina","Warszawa Miedzeszyn","Warszawa Międzylesie","Warszawa Mokry Ług","Warszawa Młynów","Warszawa Ochota","Warszawa Ochota WKD","Warszawa Okęcie","Warszawa Olszynka Grochowska","Warszawa Powiśle","Warszawa Powązki","Warszawa Praga","Warszawa Płudy","Warszawa Radość","Warszawa Rakowiec","Warszawa Raków","Warszawa Reduta Ordona","Warszawa Rembertów","Warszawa Salomea","Warszawa Stadion","Warszawa Służewiec","Warszawa Targówek","Warszawa Toruńska","Warszawa Ursus","Warszawa Ursus Niedźwiadek","Warszawa Ursus Północny","Warszawa Wawer","Warszawa Wesoła","Warszawa Wileńska","Warszawa Wola","Warszawa Wola Grzybowska","Warszawa Wschodnia","Warszawa Włochy","Warszawa Zachodnia","Warszawa Zachodnia WKD","Warszawa Zacisze Wilno","Warszawa Zoo","Warszawa Śródmieście","Warszawa Śródmieście WKD","Warszawa Żerań","Warszawa Żwirki i Wigury","Warszowice","Warszówka","Warząchewka","Wasilków","Wasilówka","Wawrów","Wałbrzych Centrum","Wałbrzych Fabryczny","Wałbrzych Główny","Wałbrzych Miasto","Wałbrzych Szczawienko","Wałcz","Wałcz Raduń","Wałdowo Szlacheckie","Wałki","Wałowice","Ważne Młyny","Wejherowo","Wejherowo Śmiechowo","Wejherowo-Nanice","Werbkowice","Werchrata","Wetlina","Wetlina Przełęcz Wyżna","Wiatrowiec","Wiatrowiec Warmiński","Widacz","Widełka","Widuchowa","Widzino","Widzów Teklinów","Wiekowo","Wielanowo","Wielawino","Wielbark","Wieleń Północny","Wieliczka Bogucice","Wieliczka Park","Wieliczka Rynek","Wieliczka Rynek-Kopalnia","Wieliczki Oleckie","Wieliszew","Wielkie Drogi","Wielowieś","Wieluń","Wieluń Dąbrowa","Wieniawa","Wierchomla Wielka","Wierna Rzeka","Wieruszów","Wieruszów Miasto","Wierzawice","Wierzbica Górna","Wierzbice Wrocławskie","Wierzbno","Wierzbowa Śląska","Wierzchosławice","Wierzchowice","Wierzchowo Człuchowskie","Wierzchowo Pomorskie","Wierzchucin","Wierzchucin Stary","Wiesiółka","Wieszczyczyn","Wieszowa","Wiewiecko","Wieżyca","Wiktorowo","Wilczyce","Wilczyska","Wilka","Wilkasy","Wilkoszewice","Wilkowice","Wilkowice Bystra","Wilkowo Świebodzińskie","Wilkołaz","Wilkołaz Wieś","Wilków Namysłowski","Wipsowo","Wiry","Wirów","Wistka","Wisła Dziechcinka","Wisła Głębce","Wisła Kolejowa","Wisła Kopydło","Wisła Obłaziec","Wisła R.1","Wisła R.4","Wisła Uzdrowisko","Wisłoczanka","Witanów","Witaszyce","Witkowo Pyrzyckie","Witków Śląski","Witnica","Witnica Chojeńska","Witonia","Witosław","Witowo","Wituchowo","Więcbork","Więcławice","Wiśnicze","Wiśniowa","Wkra","Wleń","Wnory","Wodzisław Śląski","Wodzisław Śląski Radlin","Wojanów","Wojaszówka","Wojciechowo","Wojnowice Wielkopolskie","Wojsław","Wojtal","Wola Bierwiecka","Wola Duża","Wola Filipowska","Wola Krzysztoporska","Wola Kuczkowska","Wola Lipieniecka","Wola Radziszowska","Wola Rowska","Wola Rzędzińska","Wola Łużańska","Wolanów","Wolbrom","Wolbórka","Wolenice","Wolica","Wolin","Wolsztyn","Worowo","Woszczele","Wołczyn","Wołkowyja","Wołomin","Wołomin Słoneczna","Wołowno","Wołów","Woźnice","Woźniki","Wrocki","Wrocław Brochów","Wrocław Grabiszyn","Wrocław Główny","Wrocław Klecina","Wrocław Kowale","Wrocław Kuźniki","Wrocław Leśnica","Wrocław Mikołajów","Wrocław Muchobór","Wrocław Nadodrze","Wrocław Nowy Dwór","Wrocław Osobowice","Wrocław Partynice","Wrocław Pawłowice","Wrocław Popiele","Wrocław Popowice","Wrocław Pracze","Wrocław Psie Pole","Wrocław Różanka","Wrocław Sołtysowice","Wrocław Stadion","Wrocław Strachocin","Wrocław Swojczyce","Wrocław Szczepin","Wrocław Wojnów","Wrocław Wojnów Wschodni","Wrocław Wojszyce","Wrocław Zachodni","Wrocław Zakrzów","Wrocław Świniary","Wrocław Żerniki","Wrocławki","Wroniawy","Wronki","Wrzeście","Września","Wrześnica","Wrzosowo","Wrzosów","Wrząca Pomorska","Wróblik Szlachecki","Wróblin Głogowski","Wręczyca","Wschowa","Wudzyn","Wydartowo","Wydminy","Wygoda","Wykno","Wyry","Wyrzysk Osiek","Wysoczany","Wysoka Braniewska","Wysoka Kamieńska","Wysoka Kamieńska BUS","Wysoka Krajeńska","Wyszków","Wyszków Śląski","Wyszogóra","Wyszomierz","Wyszyny","Wójcice","Wólka","Wólka Kańska","Wólka Niedzieliska","Wólka Okopska","Wólka Okrąglik","Wólka Orłowska","Wólka Plebańska","Wólka Ratowiecka","Wąbrzeźno","Wąchock","Wągrowiec","Wągry","Wąsosz Konecki","Wąwolnica","Wędrzyn","Węgierska Górka","Węgliniec","Węgorzyno","Węgry","Węgrzce Wielkie","Węgrzynów Stary","Wężyska","Władysławowo","Władysławowo Port","Włocławek","Włocławek Zazamcze","Włodawa","Włosienica","Włostowo","Włoszakowice","Włoszczowa","Włoszczowa Północ","Włoszczowice","Włynkowo","Zabiele","Zabiele Wielkie","Zabierzów","Zabieżki","Zaborze","Zaborów","Zaborów -Błonia","Zabrze","Zabrze Biskupice","Zabrze Makoszowy","Zabrze Mikulczyce","Zabrze Północne","Zabrzeg","Zabrzeg Czarnolesie","Zabłocie Czuchów","Zaczernie","Zagajnik","Zagnańsk","Zagościniec","Zagrody","Zagrody Kościół","Zagórz","Zagórz BUS","Zajezierce","Zajezierze koło Dęblina","Zajączkowo Lubawskie","Zaklików","Zaklików Miasto","Zakopane","Zakopane Ustup","Zakrzewo Złotowskie","Zakrzów Kotowice","Zakrzów-Sarnowo","Zalesie Górne","Zalesie Krasieńskie","Zalesie Wielkopolskie","Zalesie Śląskie","Zamek Bulowicki","Zamienice","Zamość","Zamość Starówka","Zamość Wschód","Zaosie","Zarośle","Zarszyn","Zaryń","Zarzecze","Zarzeka","Zaręba","Zarębki","Zaręby Kościelne","Zasieki","Zasieki Gr","Zastocze","Zastów","Zatom Stary","Zator","Zawada","Zawadzkie","Zawadówka","Zawidz","Zawidz Kościelny","Zawidów","Zawiercie","Zawiercie Borowe Pole","Załuż","Zblewo","Zbrosławice","Zbydniów","Zbąszynek","Zbąszyń","Zbąszyń Przedmieście","Zdrody Nowe","Zdrojowisko","Zduny","Zduńska Wola","Zduńska Wola Karsznice","Zduńska Wola Południowa","Zdziechowa","Zdzieszowice","Zebrzydowa","Zebrzydowice","Zebrzydowice Gr","Zebrzydowice Przyst.","Zegrze","Zelczyna","Zembrzyce","Zerbuń","Zesławice","Zełwągi","Zgierz","Zgierz Jaracza","Zgierz Kontrewers","Zgierz Północ","Zgorzelec","Zgorzelec Gr","Zgorzelec Miasto","Zieleń","Zielin Miastecki","Zieliniec","Zielomyśl","Zielona Góra Główna","Zielona Góra Nowy Kisielin","Zielona Góra Przylep","Zielona Góra Stary Kisielin","Zielonczyn","Zielone Wzgórza","Zielonka","Zielonka Bankowa","Zielonka Pasłęcka","Zielonka Pomorska","Ziemiełowice","Ziemomyśl","Zimna Wódka","Zimnochy","Ziębice","Zosinów","Zubki Białostockie","Zubrzyk","Zwardoń","Zwardoń Gr","Zwierzyniec","Zygmuntowo Mazowieckie","Zygmuntów","Ząbki","Ząbkowice Śląskie","Ząbrowo","Zębice Wrocławskie","Zębowice","Złocieniec","Złojec","Złotkowo","Złotniki","Złotniki Grzybowe","Złotniki Kujawskie","Złotniki Kutnowskie","Złotoryja","Złotów","Ćmielów","Ładzin","Łagów","Łambinowice","Łankiejmy","Łapy","Łapy Osse","Łasin Koszaliński","Łask","Łaskarzew Przystanek","Ławica","Ławocie","Łaziska Górne","Łaziska Górne Brada","Łaziska Kopanina","Łaziska Śląskie","Łaziska Średnie","Łaznów","Łazy","Łańcut","Łeba","Łobez","Łobzowiec","Łochów","Łodygowice","Łodygowice Górne","Łomnica","Łomnica Dolna","Łomnica Średnia","Łomnica-Zdrój","Łomża","Łopatki","Łopuchowo","Łopuchowo Osiedle","Łosiów","Łososina Górna","Łososiowice","Łowczów","Łowczówek Pleśna","Łowicz Główny","Łowicz Przedmieście","Łowyń","Łoźnica","Łubiana","Łubnica Łomżyńska","Łubowo","Łuczyce","Ługi Górzyckie","Łukowa Tarnowska","Łuków","Łuków Zapowiednik","Łuków Łapiguz","Łuków Śląski","Łukęcin","Łupków","Łupków Gr","Łupowo","Łysomice","Łódź Andrzejów","Łódź Andrzejów Szosa","Łódź Arturówek","Łódź Chojny","Łódź Dąbrowa","Łódź Fabryczna","Łódź Kaliska","Łódź Lublinek","Łódź Marysin","Łódź Niciarniana","Łódź Olechów","Łódź Olechów Wiadukt","Łódź Olechów Wschód","Łódź Olechów Zachód","Łódź Pabianicka","Łódź Radogoszcz Wschód","Łódź Radogoszcz Zachód","Łódź Retkinia","Łódź Stoki","Łódź Warszawska","Łódź Widzew","Łódź Żabieniec","Łąck","Łączna","Łąg","Łąg Południowy","Łąki Kozielskie","Łąkociny","Łążek","Łęczyca","Łęg Tarnowski","Łęgajny","Łęgowo Sulechowskie","Łęka Opatowska","Łęknica","Łęknica Koszalińska","Łętownia","Ściborzyce Małe","Ścinawa","Ścinawka Średnia","Ślesin","Śliwice","Śliwiczki","Śniadowo","Śrem","Śrem Odlewnia","Środa Wielkopolska","Środa Śląska","Śródborów","Świba","Świder","Świdnica Kraszowice","Świdnica Miasto","Świdnica Przedmieście","Świdnik Miasto","Świdnik Wschód","Świdwie Sępoleńskie","Świdwin","Świebodzice","Świebodzice Ciernie","Świebodzin","Świecie Przechowo","Świecie n/Wisłą","Świekatowo","Świeradów Zdrój","Świercze","Świerki Dolne","Świlcza","Świnoujście","Świnoujście Centrum UBB","Świnoujście Port","Świnoujście Przytór","Świnoujście Warszów","Świątniki","Święta Katarzyna","Świętajno","Świętochłowice","Święty Kamień","Żabi Róg","Żabiny","Żabno","Żabno koło Chojnic","Żabowo","Żagań","Żakowice","Żakowice Południowe","Żalno","Żarki Wielkie","Żarki-Letnisko","Żary","Żary Kunice","Żarów","Żdżary","Żednia","Żegiestów","Żegiestów-Zdrój","Żelazno","Żelistrzewo","Żelisławice","Żelisławie Pomorskie","Żelisławki","Żerków","Żmigród","Żnin","Żory","Żory Baranowice","Żugienie","Żukowice","Żukowo","Żukowo Wschodnie","Żulin","Żurawica","Żurawica Rozrządowa","Żychlin","Życzyn","Żydowo","Żyrardów","Żytkowice","Żywiec","Żywiec Sporysz","Żyźniewo Żórawie","Żórawina","Żółtnica","Żółwino","Żędowice"};
	
	public List<Stacja> stacje = new List<Stacja>();
	public List<Odcinek> odcinki = new List<Odcinek>();
	public List<Pociąg> pociągi = new List<Pociąg>();
	
	public Dictionary<int, int> czasy_idealne;
	public Dictionary<int, List<int>> rozkład_jazdy_najlepszego_osobnika;
	public Osobnik najlepszy_osobnik;
	public double naj_fitness=0.0;
	public double śr_fitness=0.0;
	public int max_czas_naj_os = -1;
	
	public List<double> naj_fitness_hist = new List<double>();
	public List<double> śr_fitness_hist = new List<double>();
	
	public int liczba_osobników = -1;
	public int generacje = -1;
	public double krzyżowanie_pstwo = -1;
	public double mutacje_pstwo = -1;
	
	public int generacja_num = -1;
	
	// Zbió populacji
	public List<Osobnik> populacja;
	
	private Random r;
	
	public Algorytm_Genetyczny(int liczba_stacji,int liczba_pociągów,int liczba_osobników,int generacje,double krzyżowanie_pstwo,double mutacje_pstwo,int? ziarno_losowości){
		
		this.liczba_osobników = liczba_osobników;
		this.generacje = generacje;
		this.krzyżowanie_pstwo = krzyżowanie_pstwo;
		this.mutacje_pstwo = mutacje_pstwo;
		
		// Tworzenie losowych nazw stacji
		
		if(ziarno_losowości==null){
			r = new Random();
		} else{
			r = new Random((int)ziarno_losowości);
		}
		
		for(int i=0;i<liczba_stacji;++i){
			stacje.Add(new Stacja(i,nazwy_stacji[r.Next(nazwy_stacji.Length)].Replace(" ","\n")));
		}
		
		// Tworzenie odcinków dla obu kierunków
		
		for(int start=0;start<stacje.Count-1;start++){
			int koniec = start+1;
			int czas_przejazdu = r.Next(3,20);
			int min_czas_postoju = r.Next(1,3);
			odcinki.Add(new Odcinek(start<<1,start,koniec,czas_przejazdu,min_czas_postoju));
			odcinki.Add(new Odcinek((start<<1)|1,koniec,start,czas_przejazdu,min_czas_postoju));
		}
		
		// Tworzenie pociągów, gdzie parzyste jadą od stacji początkowej A do stacji końcowej B, a parzyste - od B do A
		
		for(int i=0;i<liczba_pociągów;++i){
			int start = r.Next(2);
			int koniec = (odcinki.Count-2)+start;
			List<Odcinek> tmp = new List<Odcinek>();
			if(start==1)
				for(int j=koniec;j>=start;j-=2)
					tmp.Add(odcinki[j]);
			else
				for(int j=start;j<=koniec;j+=2)
					tmp.Add(odcinki[j]);
			pociągi.Add(new Pociąg(i,tmp));
		}
		
		// Wyliczanie idealnych czasów przejazdu do wyliczania fitness
		czasy_idealne = ObliczCzasyIdealne();
		
	}

	// Inicjalizacja populacji początkowej
	public void Inicjalizuj_Populację(){
		
		generacja_num = 0;
		naj_fitness = Double.PositiveInfinity;
		śr_fitness = 0.0;
		populacja = new List<Osobnik>();
		
		naj_fitness_hist = new List<double>();
		śr_fitness_hist = new List<double>();

		for (int i = 0; i < liczba_osobników; i++){
			
			List<Genotyp> genotyp = new List<Genotyp>();
			var wszystkieGeny = new List<Genotyp>();

			// Tworzenie wszystkich możliwych genów - jako para pociągu oraz odcinka
			foreach (var pociąg in pociągi){
				for (int s = 0; s < pociąg.trasa.Count; s++){
					wszystkieGeny.Add(new Genotyp(pociąg.nr_pociągu, s));
				}
			}
			
			// Losowe wymieszanie
			wszystkieGeny = wszystkieGeny.OrderBy(_ => r.Next()).ToList();
			genotyp.AddRange(wszystkieGeny);
			
			var osobnik = new Osobnik { genotyp = genotyp };
			
			var czasy = RozkładJazdyOsobnika(osobnik);
			osobnik.Fitness = Fitness(osobnik,czasy);
		
			śr_fitness += osobnik.Fitness; // wyliczanie średniej
			
			// Aktualizacja najlepszego osobnika
			if(osobnik.Fitness < naj_fitness){
				naj_fitness = osobnik.Fitness;
				rozkład_jazdy_najlepszego_osobnika = czasy;
				najlepszy_osobnik = osobnik;
				max_czas_naj_os = max_czas(czasy);
			}
			
			populacja.Add(osobnik);
		} 
		
		// zapis informacji o najlepszym fitness oraz średnim fitness
		śr_fitness /= liczba_osobników;	// dzielenie średniej
		naj_fitness_hist.Add(naj_fitness);
		śr_fitness_hist.Add(śr_fitness);
		
	}
	
	// Krok wykonujący naraz: Selekcję, Krzyżowanie, Mutację, oraz wyliczenie fitness
	public void Krok_Algorytmu(){
		
		SelekcjaTurniejowa();
		Krzyżowanie();
		Mutuj();
		
		naj_fitness = Double.PositiveInfinity;
		śr_fitness = 0.0;
		
		for(int i=0;i<populacja.Count;++i){
			
			var czasy = RozkładJazdyOsobnika(populacja[i]); // Symulowanie przejazdu, w celu otrzymania rzeczywistego czasu
			
			populacja[i].Fitness = Fitness(populacja[i],czasy);
			śr_fitness += populacja[i].Fitness;
			
			if(populacja[i].Fitness < naj_fitness){
				naj_fitness = populacja[i].Fitness;
				rozkład_jazdy_najlepszego_osobnika = czasy;
				najlepszy_osobnik = populacja[i];
				max_czas_naj_os = max_czas(czasy); // dane dla wykresu
			}
		}
		
		śr_fitness /= liczba_osobników;
		naj_fitness_hist.Add(naj_fitness);
		śr_fitness_hist.Add(śr_fitness);
		
		generacja_num++;
		
	}
	
	// Funkcja do wyszukiwania najpóźniejszego czasu przejazdu - potrzebne do wykresu
	public int max_czas(Dictionary<int,List<int>> rozkład){
		
		int max_val = 0;
		
		foreach(var kvp in rozkład){
			max_val = Math.Max( max_val, kvp.Value.Last() + pociągi[kvp.Key].trasa.Last().czas_przejazdu );
		}
		
		return max_val;
		
	}
	
	public void SelekcjaTurniejowa(){
		
		Random r = new Random();
		var nowaPopulacja = new List<Osobnik>();

		for (int i = 0; i < populacja.Count; i++){
			
			int indeks1 = r.Next(populacja.Count);
			int indeks2;
			do {
				indeks2 = r.Next(populacja.Count);
			} while (indeks2 == indeks1);

			var osobnik1 = populacja[indeks1];
			var osobnik2 = populacja[indeks2];

			Osobnik wygrany = osobnik1.Fitness <= 
			osobnik2.Fitness ? osobnik1 : osobnik2;

			nowaPopulacja.Add(wygrany.Kopiuj());
		}

		populacja = nowaPopulacja;
	}
	
	
	// Krzyżowanie one point crossover
	public void Krzyżowanie(){
		populacja.OrderBy(_ => r.Next());
        for (int i = 0; i < populacja.Count - 1; i += 2){
			if (r.NextDouble() < krzyżowanie_pstwo ){
				Tuple<Osobnik,Osobnik> dzieci = OnePointCrossover(populacja[i],populacja[i+1]);
				populacja[i] = dzieci.Item1;
				populacja[i+1] = dzieci.Item2;
			}
		}
	}

	public Tuple<Osobnik, Osobnik> OnePointCrossover(Osobnik r1, Osobnik r2){
		Random rand = new Random();
		int N = r1.genotyp.Count;
		int punkt = rand.Next(1, N);

		var dziecko1 = new Osobnik { genotyp = new List<Genotyp>() };
		var dziecko2 = new Osobnik { genotyp = new List<Genotyp>() };

		for (int i = 0; i < punkt; i++)
			dziecko1.genotyp.Add(r1.genotyp[i]);

		foreach (var gen in r2.genotyp)
			if (!dziecko1.genotyp.Any(g => g.pociąg_id == gen.pociąg_id && g.odcinek_id == gen.odcinek_id))
				dziecko1.genotyp.Add(new Genotyp(gen.pociąg_id, gen.odcinek_id));

		for (int i = 0; i < punkt; i++)
			dziecko2.genotyp.Add(r2.genotyp[i]);

		foreach (var gen in r1.genotyp)
			if (!dziecko2.genotyp.Any(g => g.pociąg_id == gen.pociąg_id && g.odcinek_id == gen.odcinek_id))
				dziecko2.genotyp.Add(new Genotyp(gen.pociąg_id, gen.odcinek_id));

		return Tuple.Create(dziecko1, dziecko2);
	}
	
	public void Mutuj(){
		for(int k=0;k<populacja.Count;++k){
			
			for (int i = 0; i < populacja[k].genotyp.Count; i++){
				
				var gen = populacja[k].genotyp[i];
				
				if (r.NextDouble() > mutacje_pstwo)
					continue;

				int minIndex = 0;
				int maxIndex = populacja[k].genotyp.Count - 1;

				for (int j = 0; j < populacja[k].genotyp.Count; j++){
					var g = populacja[k].genotyp[j];
					if (g.pociąg_id == gen.pociąg_id){
						if (g.odcinek_id == gen.odcinek_id - 1)
							minIndex = Math.Max(minIndex, j + 1);
						if (g.odcinek_id == gen.odcinek_id + 1)
							maxIndex = Math.Min(maxIndex, j - 1);
					}
				}
				
				if (minIndex <= maxIndex){
					int nowaPozycja = r.Next(minIndex, maxIndex + 1);

					populacja[k].genotyp.RemoveAt(i);
					if (nowaPozycja >= populacja[k].genotyp.Count)
						populacja[k].genotyp.Add(gen);
					else
						populacja[k].genotyp.Insert(nowaPozycja, gen);
				}
			}
		}
	}
	
	// Ogólny algorytm do wyliczania przejazdu
	public Dictionary<int, List<int>> RozkładJazdyOsobnika(Osobnik osobnik){
		
		var rozkład = new Dictionary<int, List<int>>();
		
		int[] pociągi_godz = new int[pociągi.Count];
		int[] pociąg_stacja = new int[pociągi.Count];
		Dictionary<int,List<int>> zajętości_tor = new Dictionary<int,List<int>>(odcinki.Count>>1);
		Dictionary<int,List<Tuple<int,int>>> zajętości_stacje = new Dictionary<int,Tuple<int,int>>>(stacje.Count);

		for(int i=0;i<pociągi.Count;++i)
			rozkład[i] = new List<int>();
		for(int i=0;i<(odcinki.Count>>1);++i)
			zajętości_tor[i] = new List<int>(pociągi.Count);
		
		var genotypy = new List<Genotyp>(osobnik.genotyp.Count);
		foreach(var gen in osobnik.genotyp)
			genotypy.Add(gen);
			
		while(genotypy.Count>0){
			
			// Szukanie pierwszego możliwego ruchu
			int index = genotypy.FindIndex((Genotyp g)=>{
				return ( g.odcinek_id == pociąg_stacja[g.pociąg_id] );
			});
				
			var gen = genotypy[index];
				
			var odcinek = pociągi[gen.pociąg_id].trasa[gen.odcinek_id];
			var tor = odcinek.odcinek_id>>1;
			
			int czas_start =  pociągi_godz[gen.pociąg_id];	
			int czas_przejazd = czas_start + odcinek.czas_przejazdu;
			
			zajętości_tor[tor].Sort();
			
			foreach(var czas in zajętości_tor[tor]){
				int czas_k = czas + odcinek.czas_przejazdu;
				if( (czas_start >= czas && czas_start < czas_k) || (czas_przejazd > czas && czas_przejazd <= czas_k) ){
					czas_start = czas_k;
					czas_przejazd = czas_start + odcinek.czas_przejazdu;
				}
			}
			
			// Wyliczanie czasu oraz tworzenie informacji o zajęciu
			
			int czas_koniec = czas_przejazd + odcinek.min_czas_postoju;
			
			pociągi_godz[gen.pociąg_id] = czas_koniec;
			zajętości_tor[tor].Add(czas_start);
			pociąg_stacja[gen.pociąg_id]++;
			
			rozkład[gen.pociąg_id].Add(czas_start);
			
			genotypy.RemoveAt(index);
		}
		
		return rozkład;
		
	}
	
	public Dictionary<int, int> ObliczCzasyIdealne(){
		
		Dictionary<int, int> czasyIdealne = new Dictionary<int, int>();

		foreach (var pociąg in pociągi){
			int czas = 0;

			foreach (var odc in pociąg.trasa)
				czas += odc.czas_przejazdu + odc.min_czas_postoju;
			
			czasyIdealne[pociąg.nr_pociągu] = czas;
		}

		return czasyIdealne;
	}
	
	public double Fitness(Osobnik osobnik,Dictionary<int, List<int>> rozkład_jazdy){
		
		double sumaOpóźnień = 0;
		int licznik = 0;

		foreach (var kvp in rozkład_jazdy){
			
			int pociąg_id = kvp.Key;
			int czasRzeczywisty = kvp.Value.Last() + pociągi[pociąg_id].trasa.Last().czas_przejazdu - kvp.Value.First();
			int czasIdealny = czasy_idealne[pociąg_id];

			double delta = (double)(czasRzeczywisty - czasIdealny) / czasIdealny;
			sumaOpóźnień += Math.Max(0, delta);
			licznik++;
		}

		double fitness = sumaOpóźnień / Math.Max(1, licznik);
		return fitness;
		
	}

	
}

// Klasy dla algorytmu genetycznego

public class Genotyp{
	
	public int pociąg_id = -1;
	public int odcinek_id = -1;
	
	public Genotyp(){}	
	public Genotyp(int pociąg_id,int odcinek_id){
		this.pociąg_id = pociąg_id;
		this.odcinek_id = odcinek_id;
	}
}

public class Osobnik{
	
    public List<Genotyp> genotyp = new List<Genotyp>();
    public double Fitness = 0.0;

    public Osobnik Kopiuj(){
        return new Osobnik{
            genotyp = genotyp.Select(g => new Genotyp{
                pociąg_id = g.pociąg_id,
                odcinek_id = g.odcinek_id
            }).ToList(),
            Fitness = Fitness
        };
    }
}