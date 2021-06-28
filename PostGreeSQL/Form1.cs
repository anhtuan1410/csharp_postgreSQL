using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostGreeSQL
{
    public partial class Form1 : Form
    {
        string _connSQL = "Host=localhost;Username=postgres;Password=s$cret;Database=testdb";
        NpgsqlConnection connection = null;
        public Form1()
        {
            InitializeComponent();
            _connSQL = @"User ID=postgres;Password=123123;Host=localhost;Port=5432;Database=DemoGoLang;Pooling=true;";
            connection = new NpgsqlConnection(_connSQL);
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            //var cs = "Host=localhost;Username=postgres;Password=s$cret;Database=testdb";

            //var con = new NpgsqlConnection(cs);
            //con.Open();

            //var sql = @"SELECT * FROM ""Birds""";

            //var cmd = new NpgsqlCommand(sql, con);

            //var _d = con.

            //var version = cmd.ExecuteScalar().ToString();
            //Console.WriteLine($"PostgreSQL version: {version}");
            _d();
        }


        void _d()
        {
            string query = @"SELECT * FROM ""Birds"" ";
            connection.Open();
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Prepare();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                DataSet _ds = new DataSet();
                DataTable _dt = new DataTable();

                da.Fill(_ds);

                try
                {
                    _dt = _ds.Tables[0];
                }
                catch (Exception ex)
                {
                    
                }

                connection.Close();
                dataGridView1.DataSource = _dt;
            }
        }

        void _insert_random()
        {
            string query = @" INSERT INTO ""Birds""(id, bird, name) VALUES ";
            connection.Open();
            using (NpgsqlCommand dbcmd = connection.CreateCommand())
            {
                                

                try
                {
                    //dbcmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Bigint);
                    //dbcmd.Parameters.Add("@bird", NpgsqlTypes.NpgsqlDbType.Char, 50);
                    //dbcmd.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Text, 3000);

                    string p = string.Empty;
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(500);
                        p += ",(" + DateTime.Now.Ticks + ", N'" + DateTime.Now.Ticks.ToString() + "', N'" + get_random_name() + "')";

                        //dbcmd.Parameters["@id"].Value = DateTime.Now.Ticks;
                        //dbcmd.Parameters["@bird"].Value = DateTime.Now.Ticks.ToString();
                        //dbcmd.Parameters["@name"].Value = get_random_name();
                        //dbcmd.ExecuteNonQuery();
                    }

                    p = p.Substring(1);
                    query += p;
                    dbcmd.CommandText = query;
                    dbcmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    int ppp = 0;
                }

                connection.Close();
            }

            

        }

        string get_random_name()
        {
            string p = $@"
            Aaren,Aarika,Abagael,Abagail,Abbe,Abbey,Abbi,Abbie,Abby,Abbye,Abigael,Abigail,Abigale,Abra,Ada,Adah,Adaline,Adan,Adara,Adda,Addi,Addia,Addie,Addy,Adel,Adela,Adelaida,Adelaide,Adele,Adelheid,Adelice,Adelina,Adelind,Adeline,Adella,Adelle,Adena,Adey,Adi,Adiana,Adina,Adora,Adore,Adoree,Adorne,Adrea,Adria,Adriaens,Adrian,Adriana,Adriane,Adrianna,Adrianne,Adriena,Adrienne,Aeriel,Aeriela,Aeriell,Afton,Ag,Agace,Agata,Agatha,Agathe,Aggi,Aggie,Aggy,Agna,Agnella,Agnes,Agnese,Agnesse,Agneta,Agnola,Agretha,Aida,Aidan,Aigneis,Aila,Aile,Ailee,Aileen,Ailene,Ailey,Aili,Ailina,Ailis,Ailsun,Ailyn,Aime,Aimee,Aimil,Aindrea,Ainslee,Ainsley,Ainslie,Ajay,Alaine,Alameda,Alana,Alanah,Alane,Alanna,Alayne,Alberta,Albertina,Albertine,Albina,Alecia,Aleda,Aleece,Aleen,Alejandra,Alejandrina,Alena,Alene,Alessandra,Aleta,Alethea,Alex,Alexa,Alexandra,Alexandrina,Alexi,Alexia,Alexina,Alexine,Alexis,Alfi,Alfie,Alfreda,Alfy,Ali,Alia,Alica,Alice,Alicea,Alicia,Alida,Alidia,Alie,Alika,Alikee,Alina,Aline,Alis,Alisa,Alisha,Alison,Alissa,Alisun,Alix,Aliza,Alla,Alleen,Allegra,Allene,Alli,Allianora,Allie,Allina,Allis,Allison,Allissa,Allix,Allsun,Allx,Ally,Allyce,Allyn,Allys,Allyson,Alma,Almeda,Almeria,Almeta,Almira,Almire,Aloise,Aloisia,Aloysia,Alta,Althea,Alvera,Alverta,Alvina,Alvinia,Alvira,Alyce,Alyda,Alys,Alysa,Alyse,Alysia,Alyson,Alyss,Alyssa,Amabel,Amabelle,Amalea,Amalee,Amaleta,Amalia,Amalie,Amalita,Amalle,Amanda,Amandi,Amandie,Amandy,Amara,Amargo,Amata,Amber,Amberly,Ambur,Ame,Amelia,Amelie,Amelina,Ameline,Amelita,Ami,Amie,Amii,Amil,Amitie,Amity,Ammamaria,Amy,Amye,Ana,Anabal,Anabel,Anabella,Anabelle,Analiese,Analise,Anallese,Anallise,Anastasia,Anastasie,Anastassia,Anatola,Andee,Andeee,Anderea,Andi,Andie,Andra,Andrea,Andreana,Andree,Andrei,Andria,Andriana,Andriette,Andromache,Andy,Anestassia,Anet,Anett,Anetta,Anette,Ange,Angel,Angela,Angele,Angelia,Angelica,Angelika,Angelina,Angeline,Angelique,Angelita,Angelle,Angie,Angil,Angy,Ania,Anica,Anissa,Anita,Anitra,Anjanette,Anjela,Ann,Ann-Marie,Anna,Anna-Diana,Anna-Diane,Anna-Maria,Annabal,Annabel,Annabela,Annabell,Annabella,Annabelle,Annadiana,Annadiane,Annalee,Annaliese,Annalise,Annamaria,Annamarie,Anne,Anne-Corinne,Anne-Marie,Annecorinne,Anneliese,Annelise,Annemarie,Annetta,Annette,Anni,Annice,Annie,Annis,Annissa,Annmaria,Annmarie,Annnora,Annora,Anny,Anselma,Ansley,Anstice,Anthe,Anthea,Anthia,Anthiathia,Antoinette,Antonella,Antonetta,Antonia,Antonie,Antonietta,Antonina,Anya,Appolonia,April,Aprilette,Ara,Arabel,Arabela,Arabele,Arabella,Arabelle,Arda,Ardath,Ardeen,Ardelia,Ardelis,Ardella,Ardelle,Arden,Ardene,Ardenia,Ardine,Ardis,Ardisj,Ardith,Ardra,Ardyce,Ardys,Ardyth,Aretha,Ariadne,Ariana,Aridatha,Ariel,Ariela,Ariella,Arielle,Arlana,Arlee,Arleen,Arlen,Arlena,Arlene,Arleta,Arlette,Arleyne,Arlie,Arliene,Arlina,Arlinda,Arline,Arluene,Arly,Arlyn,Arlyne,Aryn,Ashely,Ashia,Ashien,Ashil,Ashla,Ashlan,Ashlee,Ashleigh,Ashlen,Ashley,Ashli,Ashlie,Ashly,Asia,Astra,Astrid,Astrix,Atalanta,Athena,Athene,Atlanta,Atlante,Auberta,Aubine,Aubree,Aubrette,Aubrey,Aubrie,Aubry,Audi,Audie,Audra,Audre,Audrey,Audrie,Audry,Audrye,Audy,Augusta,Auguste,Augustina,Augustine,Aundrea,Aura,Aurea,Aurel,Aurelea,Aurelia,Aurelie,Auria,Aurie,Aurilia,Aurlie,Auroora,Aurora,Aurore,Austin,Austina,Austine,Ava,Aveline,Averil,Averyl,Avie,Avis,Aviva,Avivah,Avril,Avrit,Ayn,Bab,Babara,Babb,Babbette,Babbie,Babette,Babita,Babs,Bambi,Bambie,Bamby,Barb,Barbabra,Barbara,Barbara-Anne,Barbaraanne,Barbe,Barbee,Barbette,Barbey,Barbi,Barbie,Barbra,Barby,Bari,Barrie,Barry,Basia,Bathsheba,Batsheva,Bea,Beatrice,Beatrisa,Beatrix,Beatriz,Bebe,Becca,Becka,Becki,Beckie,Becky,Bee,Beilul,Beitris,Bekki,Bel,Belia,Belicia,Belinda,Belita,Bell,Bella,Bellanca,Belle,Bellina,Belva,Belvia,Bendite,Benedetta,Benedicta,Benedikta,Benetta,Benita,Benni,Bennie,Benny,Benoite,Berenice,Beret,Berget,Berna,Bernadene,Bernadette,Bernadina,Bernadine,Bernardina,Bernardine,Bernelle,Bernete,Bernetta,Bernette,Berni,Bernice,Bernie,Bernita,Berny,Berri,Berrie,Berry,Bert,Berta,Berte,Bertha,Berthe,Berti,Bertie,Bertina,Bertine,Berty,Beryl,Beryle,Bess,Bessie,Bessy,Beth,Bethanne,Bethany,Bethena,Bethina,Betsey,Betsy,Betta,Bette,Bette-Ann,Betteann,Betteanne,Betti,Bettina,Bettine,Betty,Bettye,Beulah,Bev,Beverie,Beverlee,Beverley,Beverlie,Beverly,Bevvy,Bianca,Bianka,Bibbie,Bibby,Bibbye,Bibi,Biddie,Biddy,Bidget,Bili,Bill,Billi,Billie,Billy,Billye,Binni,Binnie,Binny,Bird,Birdie,Birgit,Birgitta,Blair,Blaire,Blake,Blakelee,Blakeley,Blanca,Blanch,Blancha,Blanche,Blinni,Blinnie,Blinny,Bliss,Blisse,Blithe,Blondell,Blondelle,Blondie,Blondy,Blythe,Bobbe,Bobbee,Bobbette,Bobbi,Bobbie,Bobby,Bobbye,Bobette,Bobina,Bobine,Bobinette,Bonita,Bonnee,Bonni,Bonnibelle,Bonnie,Bonny,Brana,Brandais,Brande,Brandea,Brandi,Brandice,Brandie,Brandise,Brandy,Breanne,Brear,Bree,Breena,Bren,Brena,Brenda,Brenn,Brenna,Brett,Bria,Briana,Brianna,Brianne,Bride,Bridget,Bridgette,Bridie,Brier,Brietta,Brigid,Brigida,Brigit,Brigitta,Brigitte,Brina,Briney,Brinn,Brinna,Briny,Brit,Brita,Britney,Britni,Britt,Britta,Brittan,Brittaney,Brittani,Brittany,Britte,Britteny,Brittne,Brittney,Brittni,Brook,Brooke,Brooks,Brunhilda,Brunhilde,Bryana,Bryn,Bryna,Brynn,Brynna,Brynne,Buffy,Bunni,Bunnie,Bunny,Cacilia,Cacilie,Cahra,Cairistiona,Caitlin,Caitrin,Cal,Calida,Calla,Calley,Calli,Callida,Callie,Cally,Calypso,Cam,Camala,Camel,Camella,Camellia,Cami,Camila,Camile,Camilla,Camille,Cammi,Cammie,Cammy,Candace,Candi,Candice,Candida,Candide,Candie,Candis,Candra,Candy,Caprice,Cara,Caralie,Caren,Carena,Caresa,Caressa,Caresse,Carey,Cari,Caria,Carie,Caril,Carilyn,Carin,Carina,Carine,Cariotta,Carissa,Carita,Caritta,Carla,Carlee,Carleen,Carlen,Carlene,Carley,Carlie,Carlin,Carlina,Carline,Carlita,Carlota,Carlotta,Carly,Carlye,Carlyn,Carlynn,Carlynne,Carma,Carmel,Carmela,Carmelia,Carmelina,Carmelita,Carmella,Carmelle,Carmen,Carmencita,Carmina,Carmine,Carmita,Carmon,Caro,Carol,Carol-Jean,Carola,Carolan,Carolann,Carole,Carolee,Carolin,Carolina,Caroline,Caroljean,Carolyn,Carolyne,Carolynn,Caron,Carree,Carri,Carrie,Carrissa,Carroll,Carry,Cary,Caryl,Caryn,Casandra,Casey,Casi,Casie,Cass,Cassandra,Cassandre,Cassandry,Cassaundra,Cassey,Cassi,Cassie,Cassondra,Cassy,Catarina,Cate,Caterina,Catha,Catharina,Catharine,Cathe,Cathee,Catherin,Catherina,Catherine,Cathi,Cathie,Cathleen,Cathlene,Cathrin,Cathrine,Cathryn,Cathy,Cathyleen,Cati,Catie,Catina,Catlaina,Catlee,Catlin,Catrina,Catriona,Caty,Caye,Cayla,Cecelia,Cecil,Cecile,Ceciley,Cecilia,Cecilla,Cecily,Ceil,Cele,Celene,Celesta,Celeste,Celestia,Celestina,Celestine,Celestyn,Celestyna,Celia,Celie,Celina,Celinda,Celine,Celinka,Celisse,Celka,Celle,Cesya,Chad,Chanda,Chandal,Chandra,Channa,Chantal,Chantalle,Charil,Charin,Charis,Charissa,Charisse,Charita,Charity,Charla,Charlean,Charleen,Charlena,Charlene,Charline,Charlot,Charlotta,Charlotte,Charmain,Charmaine,Charmane,Charmian,Charmine,Charmion,Charo,Charyl,Chastity,Chelsae,Chelsea,Chelsey,Chelsie,Chelsy,Cher,Chere,Cherey,Cheri,Cherianne,Cherice,Cherida,Cherie,Cherilyn,Cherilynn,Cherin,Cherise,Cherish,Cherlyn,Cherri,Cherrita,Cherry,Chery,Cherye,Cheryl,Cheslie,Chiarra,Chickie,Chicky,Chiquia,Chiquita,Chlo,Chloe,Chloette,Chloris,Chris,Chrissie,Chrissy,Christa,Christabel,Christabella,Christal,Christalle,Christan,Christean,Christel,Christen,Christi,Christian,Christiana,Christiane,Christie,Christin,Christina,Christine,Christy,Christye,Christyna,Chrysa,Chrysler,Chrystal,Chryste,Chrystel,Cicely,Cicily,Ciel,Cilka,Cinda,Cindee,Cindelyn,Cinderella,Cindi,Cindie,Cindra,Cindy,Cinnamon,Cissiee,Cissy,Clair,Claire,Clara,Clarabelle,Clare,Claresta,Clareta,Claretta,Clarette,Clarey,Clari,Claribel,Clarice,Clarie,Clarinda,Clarine,Clarissa,Clarisse,Clarita,Clary,Claude,Claudelle,Claudetta,Claudette,Claudia,Claudie,Claudina,Claudine,Clea,Clem,Clemence,Clementia,Clementina,Clementine,Clemmie,Clemmy,Cleo,Cleopatra,Clerissa,Clio,Clo,Cloe,Cloris,Clotilda,Clovis,Codee,Codi,Codie,Cody,Coleen,Colene,Coletta,Colette,Colleen,Collen,Collete,Collette,Collie,Colline,Colly,Con,Concettina,Conchita,Concordia,Conni,Connie,Conny,Consolata,Constance,Constancia,Constancy,Constanta,Constantia,Constantina,Constantine,Consuela,Consuelo,Cookie,Cora,Corabel,Corabella,Corabelle,Coral,Coralie,Coraline,Coralyn,Cordelia,Cordelie,Cordey,Cordi,Cordie,Cordula,Cordy,Coreen,Corella,Corenda,Corene,Coretta,Corette,Corey,Cori,Corie,Corilla,Corina,Corine,Corinna,Corinne,Coriss,Corissa,Corliss,Corly,Cornela,Cornelia,Cornelle,Cornie,Corny,Correna,Correy,Corri,Corrianne,Corrie,Corrina,Corrine,Corrinne,Corry,Cortney,Cory,Cosetta,Cosette,Costanza,Courtenay,Courtnay,Courtney,Crin,Cris,Crissie,Crissy,Crista,Cristabel,Cristal,Cristen,Cristi,Cristie,Cristin,Cristina,Cristine,Cristionna,Cristy,Crysta,Crystal,Crystie,Cthrine,Cyb,Cybil,Cybill,Cymbre,Cynde,Cyndi,Cyndia,Cyndie,Cyndy,Cynthea,Cynthia,Cynthie,Cynthy,Dacey,Dacia,Dacie,Dacy,Dael,Daffi,Daffie,Daffy,Dagmar,Dahlia,Daile,Daisey,Daisi,Daisie,Daisy,Dale,Dalenna,Dalia,Dalila,Dallas,Daloris,Damara,Damaris,Damita,Dana,Danell,Danella,Danette,Dani,Dania,Danica,Danice,Daniela,Daniele,Daniella,Danielle,Danika,Danila,Danit,Danita,Danna,Danni,Dannie,Danny,Dannye,Danya,Danyelle,Danyette,Daphene,Daphna,Daphne,Dara,Darb,Darbie,Darby,Darcee,Darcey,Darci,Darcie,Darcy,Darda,Dareen,Darell,Darelle,Dari,Daria,Darice,Darla,Darleen,Darlene,Darline,Darlleen,Daron,Darrelle,Darryl,Darsey,Darsie,Darya,Daryl,Daryn,Dasha,Dasi,Dasie,Dasya,Datha,Daune,Daveen,Daveta,Davida,Davina,Davine,Davita,Dawn,Dawna,Dayle,Dayna,Ddene,De,Deana,Deane,Deanna,Deanne
            ";
            List<string> _k = p.Split(',').Where(x => x.Length > 0).ToList();
            Random rd = new Random();
            int _next = rd.Next(0, _k.Count-1);
            return _k[_next];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _insert_random();
        }
    }
}
