using ElasticSearch.ResponseModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ElasticSearch
{
    class Program
    {
        private static string _elasticURL = "http://localhost:9200";
        private static string _indexName = "psychologists";

        static void Main(string[] args)
        {
            RebuildIndex();
        }

        private static void RebuildIndex()
        {
            //List<SearchEntity> data = DonwloadData();
            List<SearchEntity> data = GenerateRandomData();

            ElasticIndexProvider indexProvider = new ElasticIndexProvider(_elasticURL, _indexName);
            indexProvider.DeleteElasticIndex();
            indexProvider.CreateElasticFromIndexSettings();

            ElasticDataProvider dataProvider = new ElasticDataProvider(_elasticURL, _indexName);
            dataProvider.UploadDataToElastic(data);
        }

        private static List<SearchEntity> DonwloadData()
        {
            List<SearchEntity> entities = new List<SearchEntity>();

            string sql = "select * from AspNetUsers where IsPsychologist = 1";
            string connection = "Server=(localdb)\\mssqllocaldb;Database=aspnet-TWHelp-198A0B6F-A6C5-4A0B-AE3E-A656C11BFDD5;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection sqlConnection = new SqlConnection(connection))
            using(SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    SearchEntity entity = new SearchEntity()
                    {
                        Id = long.Parse(reader["Id"].ToString()),
                        NickName = reader["UserName"].ToString(),
                        Education = reader["Education"].ToString(),
                        AreaOfExpertise = reader["AreaOfExpertise"].ToString(),
                        IsAccountActivated = bool.Parse(reader["IsAccountActivated"].ToString())
                    };

                    entities.Add(entity);
                }
            }

            return entities;
        }

        private static List<SearchEntity> GenerateRandomData()
        {
            List<SearchEntity> entities = new List<SearchEntity>();
            Random random = new Random();

            for (int i = 0; i < 100_000; i++)
            {
                SearchEntity searchEntity = new SearchEntity()
                {
                    Id = random.Next(0, 1_000_000),
                    NickName = FirstNames[random.Next(FirstNames.Length)] + " " + SecondNames[random.Next(SecondNames.Length)],
                    Education = "education " + random.Next(100, 200),
                    AreaOfExpertise= "expertise area " + random.NextDouble() * 1000 + " area",
                    IsAccountActivated = random.Next(0, 2) == 1 ? true : false,
                };

                entities.Add(searchEntity);
            }

            return entities;
        }

        //100 X 10 names (1000 unique values at all)
        public static string[] FirstNames = new[]
        {
            "Lana", "Adriel", "Alannah", "Jamar", "Dashawn", "Hassan", "Cortez", "Sylvia", "Jaquan", "Nayeli",
            "Nicole", "Easton", "Bridger", "Houston", "Kamari", "Savanah", "Colton", "Aryanna", "Ruby", "Jamya",
            "Logan", "Joselyn", "Laura", "Arabella", "Aleah", "Adriana", "Jaron", "Sarah", "Jon", "Muhammad",
            "Anaya", "Gillian", "Ryder", "Duncan", "Mareli", "Nikhil", "Audrey", "Hailie", "Taniya", "Payton",
            "Sidney", "Roy", "Lexi", "Miranda", "Tony", "Nigel", "Israel", "Mattie", "Jamal", "Colt",
            "Sariah", "Aliana", "Shaylee", "Scott", "Issac", "Landen", "Solomon", "Axel", "Jaiden", "Serenity",
            "Nathaly", "Skyla", "Aliya", "Rex", "Edwin", "Evelin", "Quentin", "Raquel", "Lance", "Rosa",
            "Tucker", "Clinton", "Coby", "Jayvion", "Valentina", "Sloane", "Daniela", "Catherine", "Katelyn", "Donavan",
            "Dominik", "Taryn", "Jocelyn", "Anabella", "Korbin", "Stephen", "Waylon", "Serena", "Omari", "Leanna",
            "Steve", "Addison", "Alexis", "Adolfo", "Lilianna", "Martin", "Vance", "Rebekah", "Braden", "Marisol",
            "Cassidy", "Elianna", "Roman", "Adeline", "Patrick", "Alvin", "Ismael", "Heidi", "Shayla", "Jude",
            "Vanessa", "Leila", "Sage", "Diego", "Fisher", "Geovanni", "Breanna", "Jamari", "Celia", "Lukas",
            "Isai", "Kaya", "Riya", "Carley", "Alicia", "Laylah", "Brooke", "Lesly", "Noel", "Jamie",
            "Cali", "Madyson", "Desirae", "Helena", "Cole", "Bryan", "Cedric", "Reed", "Kaitlynn", "Avery",
            "Makayla", "Shyann", "Nancy", "Alayna", "Yoselin", "Ronan", "Paul", "Daphne", "Guillermo", "Jaeden",
            "Caitlyn", "Tate", "Silas", "Natalia", "Ruth", "Peyton", "Danny", "Jayleen", "Jillian", "Ali",
            "Ari", "Gabriel", "Madilynn", "Everett", "Orlando", "Charlee", "Itzel", "Gunnar", "Amber", "Cade",
            "Trinity", "Amelia", "Whitney", "Kelly", "Milo", "Chris", "Hayden", "Dereon", "Gaven", "Kendal",
            "Alana", "Bentley", "Arielle", "Charlie", "Neveah", "Mekhi", "Kendall", "Alijah", "Agustin", "Kane",
            "Amari", "Marisa", "Kyra", "Christine", "Niko", "Santiago", "Douglas", "Mollie", "Marc", "Diamond",
            "Regina", "Kiana", "Pierre", "Rory", "Justin", "Kenyon", "Reginald", "Steven", "Keira", "Krish",
            "Abigayle", "Leyla", "Marshall", "Demetrius", "Misael", "Phoenix", "Zavier", "Joanna", "Rigoberto", "Travis",
            "Madden", "Laila", "Denise", "Gregory", "Lillie", "Lucian", "Ernesto", "Rachael", "Terrell", "Heather",
            "Aimee", "Kaiya", "Aracely", "Elliot", "Jaylin", "Tyshawn", "Nathen", "Skylar", "Kole", "Daniella",
            "Brayden", "Miguel", "Lilly", "Cecelia", "Aydan", "Alessandra", "Savion", "Tori", "Rey", "Keagan",
            "Gustavo", "Akira", "Haylie", "Sofia", "Madalynn", "Remington", "Lorena", "Eden", "Mckenna", "Xavier",
            "Rodney", "Jenna", "Zachariah", "Ellie", "Camren", "Pamela", "Kathy", "Rashad", "Gianna", "Zachery",
            "Josie", "Vaughn", "Terrence", "Carleigh", "Charity", "Lauryn", "Rhys", "Frankie", "Ariel", "Baylee",
            "Jasiah", "Alec", "Dangelo", "Alexia", "Teagan", "Chanel", "Karissa", "Pranav", "Nia", "Angel",
            "Glenn", "Tristan", "Nevaeh", "Jovanny", "Chad", "Micah", "Jazmine", "Hayley", "Viviana", "Alyson",
            "Ivy", "Mason", "Weston", "Tianna", "Edgar", "Craig", "Izabella", "Ryker", "Deja", "Kai",
            "Mallory", "Yadira", "Kristopher", "Byron", "Luciano", "Beckham", "Alaina", "Mckinley", "Brandon", "Maribel",
            "Paisley", "Mariam", "Ireland", "Nina", "Branden", "Cloe", "Juliet", "Cruz", "Bridget", "Jaydin",
            "Esperanza", "Riley", "Ronnie", "Caden", "Cristopher", "Talia", "Adam", "Kade", "Kenna", "Julian",
            "Erick", "Ximena", "Cohen", "Tatum", "Maia", "Monserrat", "Zane", "Seamus", "Cason", "Holden",
            "Karli", "Jamison", "Kasen", "Maci", "Krista", "Keyla", "Julianne", "Amaya", "Kenneth", "Ada",
            "Judith", "Joslyn", "Lisa", "Ashanti", "Tessa", "Christopher", "Carter", "Damian", "Jonas", "Jaliyah",
            "Miriam", "Chase", "Finley", "Catalina", "Amina", "Holly", "Rolando", "Luke", "Haley", "Jenny",
            "Lila", "Raul", "Gerardo", "Winston", "Erika", "Lewis", "Felipe", "Monique", "Jolie", "Rodolfo",
            "Quinton", "Joaquin", "Demarcus", "Jayla", "Jayce", "Gael", "Harper", "Jefferson", "Allen", "Konner",
            "Dayami", "Karen", "Lindsay", "Harley", "Luna", "Ella", "Amelie", "Adrian", "Finnegan", "Tommy",
            "Ashley", "Leonardo", "Kendrick", "Xiomara", "Ansley", "Armani", "Hezekiah", "Sherlyn", "Andy", "Liam",
            "Karley", "Emiliano", "Bryant", "Dalton", "Jaden", "Nathaniel", "Damari", "Quinn", "Jesse", "Jace",
            "Ryann", "Alisha", "Lawson", "Priscilla", "Luz", "Deon", "Kristen", "Miya", "Keshawn", "Taylor",
            "Carlos", "Anthony", "Keegan", "Ivan", "Giana", "Osvaldo", "Giselle", "Chaz", "Jadiel", "Aniya",
            "Gunner", "William", "Frederick", "Marlee", "Alessandro", "Maria", "Michael", "Ryleigh", "Addyson", "Nathan",
            "Tatiana", "Eva", "Kaylen", "Alina", "Alfonso", "Braylon", "Quinten", "Bruce", "Jerome", "Kierra",
            "Rylan", "Rosemary", "Marley", "Ashlyn", "Abagail", "Erik", "Lamont", "Kaleb", "Davion", "Jaylene",
            "Abel", "Javion", "Madeline", "Kiera", "Trey", "Ellis", "Jadon", "Charlize", "Theresa", "Alonzo",
            "Dean", "Elvis", "Alexander", "Rhianna", "Marvin", "Jayden", "Yandel", "Londyn", "Tanner", "Vivian",
            "Layla", "Addisyn", "Immanuel", "Raymond", "Kali", "Jordyn", "India", "Samir", "Declan", "Brenden",
            "Jaida", "Zaid", "Michaela", "Joel", "Ernest", "Mikayla", "Marina", "Adonis", "Stephany", "Zechariah",
            "Scarlet", "Zion", "Kinsley", "Noemi", "Devin", "Uriel", "Sammy", "Damion", "Micheal", "Nora",
            "Shea", "Lee", "Pierce", "Asher", "Selah", "Tyler", "Jan", "Warren", "Andrew", "Makaila",
            "Brianna", "Jewel", "Juan", "Brendon", "Haiden", "Nikolas", "Gianni", "Prince", "Romeo", "Deangelo",
            "Alissa", "Evan", "Kirsten", "Antwan", "Kymani", "Sydney", "Danna", "Nola", "Raven", "Campbell",
            "Guadalupe", "Royce", "Ashleigh", "Grant", "Clare", "Rihanna", "Josiah", "Clay", "Sean", "Broderick",
            "Alejandra", "Shania", "June", "Phillip", "Rishi", "Jean", "Jonathon", "Esmeralda", "Azul", "Andre",
            "Sierra", "Chana", "Hadley", "Clarissa", "Corey", "Jairo", "Gary", "Lindsey", "Yasmin", "Bailey",
            "Blake", "Brynlee", "Tristin", "Tomas", "Aaden", "Izayah", "Alfredo", "Dylan", "Olivia", "Nickolas",
            "Milton", "Jane", "Cristal", "Wade", "Evelyn", "Keyon", "Mario", "Devan", "Alisa", "Slade",
            "Ethan", "Ariana", "Odin", "Lucy", "Mohammad", "Paola", "Lexie", "Dakota", "Willie", "Jabari",
            "Jaylah", "Rodrigo", "Giuliana", "Tia", "Emelia", "Mohammed", "Kendra", "Zachary", "Lillian", "Samuel",
            "Sophie", "Elsie", "Livia", "Makenzie", "Martha", "Aisha", "Skye", "Marlon", "Justice", "Antony",
            "Melina", "Maggie", "Gilbert", "London", "Kobe", "Ingrid", "Cristina", "Kaylah", "Maleah", "Sasha",
            "Kevin", "Teresa", "Hillary", "Louis", "Isaac", "Linda", "Leo", "Makenna", "Derrick", "Jacquelyn",
            "Kamryn", "Fatima", "Abbey", "Joseph", "Tripp", "Perla", "Johnny", "Tabitha", "Esteban", "Colby",
            "Jovanni", "Janiya", "Braedon", "Adrienne", "Andrea", "Hugh", "Jaslyn", "Maurice", "Kellen", "Cale",
            "Carina", "Ean", "Kenny", "Zoie", "Natalya", "Owen", "Jacqueline", "Sabrina", "Brody", "Marely",
            "Braelyn", "Darryl", "Jakobe", "Eliza", "Octavio", "Isaias", "Saniyah", "Marcelo", "Kadyn", "Stanley",
            "Kaia", "Sanai", "Kyle", "Valery", "Marlie", "Kaley", "Deanna", "Abdullah", "Carmen", "Joshua",
            "Aldo", "Sonny", "Darren", "Ulises", "Javier", "Emely", "Briley", "Ava", "Hope", "Genevieve",
            "Savannah", "Maritza", "Porter", "Leah", "Kareem", "Cheyenne", "Shaun", "Landin", "Hector", "Jake",
            "Wyatt", "Emily", "Arnav", "Chace", "Yusuf", "Reynaldo", "Lainey", "Katherine", "Dustin", "Zayne",
            "Noelle", "Dale", "Jared", "River", "Erin", "Tiffany", "Paloma", "Zain", "Ariella", "Gabriela",
            "Isis", "Evangeline", "Johan", "Conrad", "Amara", "Camryn", "Krystal", "Ashton", "Kaylynn", "Taniyah",
            "Rayan", "Alfred", "Kaydence", "Matteo", "Ibrahim", "Danielle", "Brittany", "Johnathon", "Trenton", "Kolton",
            "Lacey", "Luciana", "Casey", "Fernando", "Kash", "Yazmin", "Makai", "Marissa", "Roderick", "Miracle",
            "Dayana", "Jovany", "Gracelyn", "Valentino", "Rayne", "Frances", "Hudson", "Danica", "Danika", "Isla",
            "Heath", "Bria", "Samara", "Sergio", "Jamiya", "Mark", "Emilie", "Walter", "Bradyn", "Johnathan",
            "Melissa", "Donovan", "Athena", "Brennan", "Keith", "Jerry", "Tiana", "Salvador", "Hailee", "Jada",
            "Reina", "Natalee", "Alex", "Juliana", "Cassie", "Emmy", "Asa", "Will", "Yuliana", "Ramon",
            "Jermaine", "Roger", "Belinda", "Arely", "Deven", "Dario", "Henry", "Kaylin", "Dane", "Moriah",
            "Alexa", "Kadin", "Keon", "Cora", "Magdalena", "Madeleine", "Ayana", "Jayda", "Jocelynn", "Zoe",
            "Carolina", "Leroy", "Lyla", "Kaylie", "Judah", "Anderson", "Anabel", "Bryanna", "Mike", "Wesley",
            "Russell", "Kamora", "Piper", "Aaron", "Kaliyah", "Beatrice", "Luca", "Madelyn", "Ahmed", "Matthew",
            "Mayra", "Lily", "Howard", "Trevor", "Jazlynn", "Dayton", "Tyrone", "Gabrielle", "Alexandra", "Jazlyn",
            "Trent", "Malcolm", "Matias", "Tristen", "Destinee", "Bradley", "Andres", "Delaney", "Nataly", "Angie",
            "Maximillian", "Rylie", "Cecilia", "Brooklynn", "Tobias", "Boston", "Julissa", "Justus", "Jadyn", "Ellen",
            "Raegan", "Elaine", "Alexus", "Paris", "Soren", "Maximo", "Davin", "Jazmin", "Bianca", "Haylee",
            "Orion", "Josue", "Jennifer", "Kylie", "Camille", "Jaylee", "Sullivan", "Nikolai", "Layne", "Kaila",
            "Elsa", "Norah", "Wayne", "Monica", "Emmalee", "Thalia", "Anya", "Kathryn", "Salvatore", "Shyla",
            "Nolan", "Lennon", "Asia", "Josh", "Amiyah", "Marcus", "Marcos", "Jair", "Allison", "Mariah",
            "Dayanara", "Triston", "Francis", "Lucia", "Gisselle", "Kamila", "Santos", "Khalil", "Eric", "Melanie",
            "Ross", "Janiah", "Autumn", "Caylee", "Kaden", "Alma", "Darian", "Justine", "Amiah", "Heidy",
            "Gretchen", "Celeste", "Darien", "Liberty", "Annika", "Jay", "Kelvin", "Saige", "Samson", "Tiara",
            "Chandler", "Brenna", "Janet", "Kaleigh", "Noah", "Alice", "Donald", "Angela", "Richard", "Jaime",
            "Cameron", "Janessa", "Leon", "Davon", "Nyla", "Conner", "Mateo", "Alberto", "Bennett", "Hazel",
            "Angelina", "Eileen", "Aldus", "Victor", "Alan", "Aiden", "Chloe", "Ted", "Valeria", "Sawyer",
            "Annabella", "Rosie", "Kimberly", "Nicholas", "Paige", "Albert", "Alen", "Roland", "Victoria", "Michelle",
        };

        //100 X 10 names (1000 unique values at all)
        public static string[] SecondNames = new[]
        {
            "Howe", "Bartlett", "Walters", "Hall", "Sellers", "Gregory", "Rocha", "Combs", "Conley", "Pittman",
            "Mccall", "Huerta", "May", "Yang", "Mcbride", "Booker", "Irwin", "Hampton", "Patrick", "Cummings",
            "Lopez", "Huynh", "Davila", "Archer", "Macdonald", "Leach", "Fernandez", "Morse", "Patel", "Landry",
            "Guerra", "Oliver", "Sparks", "David", "Robinson", "Ruiz", "Carroll", "Bender", "Eaton", "Mullins",
            "Camacho", "Frost", "Dennis", "Olsen", "Maynard", "Weaver", "Marshall", "Carr", "Schneider", "Wallace",
            "Mcdonald", "Mcintyre", "Adkins", "Blake", "Kemp", "Wilkinson", "Sweeney", "Krueger", "Payne", "Adams",
            "Rowe", "Cohen", "Oconnor", "Potts", "Melton", "Bass", "Powell", "Jackson", "Hodge", "Matthews",
            "Macias", "Singleton", "Arroyo", "White", "Dean", "Gutierrez", "Campos", "Parsons", "Stephenson", "Wolf",
            "Barr", "Murray", "Richmond", "Hubbard", "Jacobs", "Parker", "Hamilton", "Blanchard", "Charles", "Carey",
            "Figueroa", "Daniels", "Kelley", "Roy", "Rodgers", "Brock", "Porter", "Morrison", "Reilly", "English",
            "Hatfield", "Schmitt", "Deleon", "Hurley", "Ashley", "Neal", "Duffy", "Kerr", "Pope", "Williams",
            "Francis", "Chen", "Elliott", "Frederick", "Lara", "Avery", "Sawyer", "Livingston", "Hobbs", "Chapman",
            "Lucas", "Griffin", "Morton", "Lester", "Hammond", "Espinoza", "Richard", "Fuller", "Crosby", "Heath",
            "Carrillo", "Weber", "Ochoa", "Salinas", "Stone", "Kim", "Rich", "Berger", "Villegas", "Ritter",
            "Cunningham", "Bullock", "Rangel", "Huffman", "Hays", "Conner", "Lucero", "Walter", "Ellison", "Vaughan",
            "Olson", "Sherman", "Duran", "Nolan", "Sanford", "Shah", "Horton", "Aguilar", "Benton", "Mckay",
            "Hoover", "Bryan", "Whitaker", "Schaefer", "Reed", "Park", "Giles", "Humphrey", "Mora", "Scott",
            "Long", "Faulkner", "Rubio", "Salazar", "Kaiser", "Shepherd", "Bray", "Riddle", "Fitzpatrick", "Schmidt",
            "Dodson", "French", "Ford", "Middleton", "Vargas", "Parrish", "Barnett", "Harding", "Hughes", "Rosario",
            "Ingram", "Braun", "Goodman", "Hardy", "Lambert", "Acosta", "Farmer", "Underwood", "Buckley", "Hansen",
            "Burgess", "Reese", "Marquez", "Hinton", "Ponce", "Gould", "Farley", "Bradford", "Mckenzie", "Williamson",
            "Proctor", "Mclean", "Zhang", "Stokes", "Brooks", "Blevins", "Cervantes", "Webb", "Woodward", "Calhoun",
            "Stewart", "Davis", "Brown", "Banks", "Pratt", "Copeland", "Johns", "Cooley", "Colon", "Paul",
            "Short", "Nguyen", "Keller", "Compton", "James", "Andrews", "Chambers", "Alexander", "Kane", "Powers",
            "Watkins", "Stevens", "Hull", "Villarreal", "Mcclure", "Stein", "Villa", "Stephens", "Jordan", "Donovan",
            "Orr", "Noble", "Rogers", "Houston", "Moreno", "Vazquez", "Cannon", "Donaldson", "Oneal", "Oconnell",
            "Fields", "Martin", "Koch", "Dunn", "Love", "Bowen", "Trevino", "Blankenship", "Fletcher", "Young",
            "Raymond", "Mcclain", "Welch", "Bush", "Hoffman", "Bonilla", "Meza", "Logan", "Shaffer", "Keith",
            "Peterson", "Briggs", "Russell", "Thornton", "Mooney", "Li", "Callahan", "Gallagher", "Mcmahon", "Hebert",
            "Freeman", "Fritz", "Weeks", "Barrett", "House", "Bowers", "Dawson", "Wagner", "Sloan", "Hancock",
            "Sutton", "Dominguez", "Snyder", "Wilkins", "Lee", "Tate", "Whitehead", "Sandoval", "Moore", "Chandler",
            "Hanna", "Mann", "Zuniga", "Benson", "Huff", "Riggs", "Johnston", "Durham", "Ortega", "Johnson",
            "Morris", "Cowan", "Weiss", "Gray", "Hensley", "Duke", "Yoder", "Chan", "Guerrero", "Horne",
            "Rasmussen", "Mitchell", "Stanton", "Mills", "Petty", "Harvey", "Anderson", "Butler", "Buck", "Bird",
            "Mcdowell", "Myers", "Holt", "Mcknight", "Tapia", "Holden", "Sosa", "Gilmore", "Ramsey", "Bautista",
            "Dickson", "Mayer", "Good", "Jefferson", "Medina", "Morrow", "Richardson", "Whitney", "Pineda", "Friedman",
            "Molina", "Randall", "Suarez", "Harrington", "Garrett", "Robles", "Glass", "Crawford", "Rowland", "Gomez",
            "Wyatt", "Nixon", "Carter", "Maldonado", "Randolph", "Berry", "Harrison", "Lynn", "Beasley", "Mathis",
            "Duncan", "Mccoy", "Mckinney", "Norton", "Beard", "Arnold", "Pruitt", "Hanson", "Caldwell", "Holder",
            "Fox", "Rosales", "Phillips", "Cantu", "Fitzgerald", "Solis", "Cobb", "Doyle", "Zamora", "Moody",
            "Daugherty", "Mathews", "Ballard", "Wiley", "Haynes", "Meadows", "King", "Mckee", "Everett", "Collier",
            "Dunlap", "Mcpherson", "Cross", "Haas", "Page", "Delacruz", "Hardin", "Reeves", "Hayden", "Collins",
            "Berg", "Dyer", "Petersen", "Spears", "Fischer", "Liu", "Daniel", "Velez", "Best", "Ramos",
            "Buchanan", "Boyle", "Key", "Clements", "Rhodes", "Lin", "Coffey", "Patterson", "Bryant", "Edwards",
            "Gates", "Curtis", "Robbins", "Ross", "Davenport", "Valencia", "Atkinson", "Rice", "Wade", "Wood",
            "Lindsey", "Church", "Jarvis", "Mccullough", "Gay", "Mercer", "Wilcox", "Tyler", "Larsen", "Malone",
            "Foley", "Vance", "Price", "Pugh", "Coleman", "Herring", "Barton", "Ward", "Campbell", "Barry",
            "Mcneil", "Stuart", "Bond", "Rodriguez", "Chang", "Cameron", "Galloway", "Vaughn", "Solomon", "Nichols",
            "Moss", "Dalton", "Washington", "Brennan", "Jones", "Mason", "Barajas", "Ray", "Fowler", "Miller",
            "Andersen", "Klein", "Vang", "Luna", "Cain", "Mccann", "Burton", "Anthony", "Arellano", "Knox",
            "Crane", "Kennedy", "Clayton", "Waters", "Quinn", "Mata", "Lynch", "Craig", "Decker", "Willis",
            "Cuevas", "Stafford", "Montoya", "Murphy", "Morgan", "Rivas", "Velazquez", "Reynolds", "Mccarty", "Bowman",
            "Huber", "Huang", "Villanueva", "Flynn", "Wall", "Delgado", "Zimmerman", "Watts", "Maxwell", "Cantrell",
            "Meyers", "Case", "Ho", "Hogan", "Castillo", "Nash", "Mejia", "Bentley", "Cole", "Cortez",
            "Fisher", "Peters", "Chase", "Maddox", "Gentry", "Dickerson", "Garner", "Baldwin", "Forbes", "Michael",
            "Galvan", "Cooper", "Carpenter", "Moon", "Shepard", "Dudley", "Shea", "Casey", "Steele", "Winters",
            "Herman", "Watson", "Bennett", "Bridges", "Russo", "Flowers", "Harrell", "Trujillo", "Nicholson", "Evans",
            "Mccormick", "Montgomery", "Valdez", "Bell", "Blair", "Hodges", "Padilla", "Beck", "Farrell", "Baker",
            "Serrano", "Kline", "Pitts", "Allen", "Pollard", "Cline", "Khan", "Mcfarland", "Wolfe", "Gordon",
            "Hart", "Leon", "Howell", "Santana", "Shannon", "Sharp", "Cook", "Schultz", "Bright", "Shaw",
            "Rollins", "Black", "Thomas", "Lawrence", "Pierce", "Gamble", "Richards", "Walsh", "Simmons", "Ware",
            "Pennington", "Little", "Holloway", "Stevenson", "Lewis", "Glover", "Acevedo", "Terry", "Baird", "Henderson",
            "Tanner", "Burns", "Stout", "Singh", "Larson", "Nunez", "Rivera", "Hartman", "Abbott", "Merritt",
            "Hudson", "Ellis", "Jennings", "Frey", "Rivers", "Christian", "Cochran", "Morales", "Krause", "Golden",
            "Obrien", "Santiago", "Tran", "West", "Lloyd", "Gibbs", "Herrera", "Mcmillan", "Navarro", "Guzman",
            "Ortiz", "Burke", "Mccarthy", "Wells", "Mack", "Gill", "Murillo", "Bean", "Arias", "Yates",
            "Esparza", "Barrera", "Cooke", "Mclaughlin", "Mahoney", "Hester", "Davies", "Wong", "Velasquez", "Hawkins",
            "Greene", "Estrada", "Levine", "Phelps", "Reid", "Foster", "Barker", "Lyons", "Mendez", "Henry",
            "Garcia", "Schwartz", "Haley", "Greer", "Grimes", "Fry", "Marks", "Prince", "Gardner", "Osborn",
            "Hood", "Hernandez", "Stanley", "Travis", "Castro", "Pace", "Le", "Nelson", "Brandt", "Warren",
            "Kirby", "Mcgee", "Cisneros", "Burnett", "York", "Frank", "Allison", "Perez", "Hurst", "Bailey",
            "Schroeder", "Townsend", "Kent", "Kramer", "Skinner", "Mendoza", "Glenn", "Ball", "Chaney", "Manning",
            "Owens", "Wilson", "Moran", "Baxter", "Stark", "Estes", "Christensen", "Gonzalez", "Swanson", "Gibson",
            "Roach", "Mercado", "Rose", "Melendez", "Preston", "Barber", "Contreras", "Harmon", "Wise", "Leblanc",
            "Dixon", "Simpson", "Madden", "Knight", "Browning", "Blackburn", "Hendrix", "Vega", "Mcgrath", "Newman",
            "Escobar", "Romero", "Snow", "Hickman", "Armstrong", "Hess", "Ferguson", "Bruce", "Hunt", "Conway",
            "Sanders", "Jacobson", "Pham", "Mayo", "Bates", "George", "Ryan", "Hooper", "Joyce", "Cherry",
            "Bradley", "Alvarez", "Patton", "Henson", "Hale", "Rios", "Zavala", "Bernard", "Wheeler", "Howard",
            "Kaufman", "Ibarra", "Sims", "Simon", "Becker", "Small", "Avila", "Ramirez", "Lamb", "Potter",
            "Grant", "Graves", "Warner", "Savage", "Sullivan", "Montes", "Monroe", "Lutz", "Franklin", "Douglas",
            "Mcintosh", "Garza", "Carlson", "Strickland", "Boone", "Davidson", "Higgins", "Harris", "Beltran", "Webster",
            "Sanchez", "Tucker", "Benjamin", "Gillespie", "Lang", "Martinez", "Roberson", "Valentine", "Lowery", "Gallegos",
            "Poole", "Kelly", "Drake", "Castaneda", "Branch", "Santos", "Floyd", "Ewing", "Hunter", "Ayala",
            "Roberts", "Bishop", "Flores", "Marsh", "Wu", "Terrell", "Byrd", "Brady", "Rush", "Lam",
            "Meyer", "Fleming", "Soto", "Curry", "Frazier", "Mcguire", "Massey", "Odom", "Thompson", "Dorsey",
            "Graham", "Hill", "Kidd", "Wilkerson", "Holmes", "Wang", "Valenzuela", "Perkins", "Booth", "Barnes",
            "Smith", "Green", "Perry", "Choi", "Orozco", "Lozano", "Boyd", "Mueller", "Day", "Aguirre",
            "Taylor", "Jensen", "Shields", "Torres", "Cox", "Shelton", "Mcconnell", "Duarte", "Vincent", "Silva",
            "Frye", "Newton", "Cordova", "Miles", "Woodard", "Sexton", "Spence", "Blackwell", "Leonard", "Walton",
            "Atkins", "Mays", "Walls", "Boyer", "Munoz", "Juarez", "Cabrera", "Hicks", "Mosley", "Jenkins",
            "Parks", "Erickson", "Turner", "Owen", "Bolton", "Clay", "Rojas", "Clark", "Vasquez", "Werner",
            "Odonnell", "Peck", "Hendricks", "Goodwin", "Clarke", "Calderon", "Jimenez", "Gilbert", "Cruz", "Summers",
            "Riley", "Roth", "Wiggins", "Knapp", "Lawson", "Palmer", "Woods", "Diaz", "Ferrell", "Reyes",
            "Hutchinson", "Mullen", "Strong", "Austin", "Norman", "Pearson", "Osborne", "Sheppard", "Bradshaw", "Roman",
            "Saunders", "Benitez", "Holland", "Hahn", "Miranda", "Andrade", "Alvarado", "Gonzales", "Costa", "Chavez",
            "Walker", "Lane", "Garrison", "Finley", "Carson", "Wright", "Franco", "Conrad", "Dougherty", "Nielsen",
            "Todd", "Lowe", "Moses", "Novak", "Griffith", "Moyer", "Hayes", "Chung", "Yu", "Brewer",
            "Horn", "Kirk", "Spencer", "Oneill", "Carney", "Gaines", "Hines", "Ali", "Sampson", "Downs",
            "Norris", "Burch", "Harper", "Cardenas", "Pacheco", "Mcdaniel", "Waller", "Haney", "Salas", "Gross",
            "Dillon", "Ayers", "Levy", "Barron", "Pena", "Fuentes", "Robertson", "Bauer", "Joseph", "Hopkins",
        };
    }
}
