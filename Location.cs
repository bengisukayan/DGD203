using DGD203_game;
using System;

public class Location
{
    private string _buffer, _currentLocation;
    private Player _player;
    private bool _eventWc, _eventKitchen, _eventDining1, _eventDining2;

    public Location(Player player)
    {
        _currentLocation = "Enterance";
        _eventWc = true;
        _eventKitchen = true;
        _eventDining1 = true;
        _eventDining2 = true;
        _player = player;
        this.Enterance();
    }
    public void Move()
    {
        if (Equals(this._currentLocation, "DiningRoom1") || Equals(this._currentLocation, "DiningRoom2") || Equals(this._currentLocation, "Kitchen"))
        {
            Console.WriteLine($"Do you want to leave the {this._currentLocation}?\n[1] Leave.\n[2] Stay.");
            _buffer = Console.ReadLine();
            while (!Equals(_buffer, "1") && !Equals(_buffer, "2")) 
            {
                Console.WriteLine("What do you mean?");
                _buffer = Console.ReadLine();
            }
            if (Equals(_buffer, "1"))
                this.Hallway();
            else
                Console.WriteLine("Not moving an inch.");
        }
        else if (Equals(this._currentLocation, "WC"))
        {
            Console.WriteLine($"Do you want to leave the {this._currentLocation}?\n[1] Leave.\n[2] Stay.");
            _buffer = Console.ReadLine();
            while (!Equals(_buffer, "1") && !Equals(_buffer, "2"))
            {
                Console.WriteLine("What do you mean?");
                _buffer = Console.ReadLine();
            }
            if (Equals(_buffer, "1"))
                this.Enterance();
            else
                Console.WriteLine("Not moving an inch.");
        }
        else if (Equals(this._currentLocation, "Enterance"))
        {
            Console.WriteLine($"Where do you want to go and leave the {this._currentLocation}?\n[W] Hallway.\n[D] WC.\n[1] Stay.");
            _buffer = Console.ReadLine();
            while (!Equals(_buffer, "1") && !Equals(_buffer, "W") && !Equals(_buffer, "D"))
            {
                Console.WriteLine("What do you mean?");
                _buffer = Console.ReadLine();
            }
            if (Equals(_buffer, "W"))
                this.Hallway();
            else if (Equals(_buffer, "D"))
                this.WC();
            else
                Console.WriteLine("Not moving an inch.");
        }
        else
        {
            Console.WriteLine($"Where do you want to go and leave the {this._currentLocation}?\n[W] Kitchen.\n[A] DiningRoom1.\n[D] DiningRoom2.\n[S] Entrance.\n[1] Stay.");
            _buffer = Console.ReadLine();
            while (!Equals(_buffer, "1") && !Equals(_buffer, "W") && !Equals(_buffer, "D") && !Equals(_buffer, "A") && !Equals(_buffer, "S"))
            {
                Console.WriteLine("What do you mean?");
                _buffer = Console.ReadLine();
            }
            if (Equals(_buffer, "W"))
                this.Kitchen();
            else if (Equals(_buffer, "A"))
                this.DiningRoom1();
            else if (Equals(_buffer, "D"))
                this.DiningRoom2();
            else if (Equals(_buffer, "S"))
                this.Enterance();
            else
                Console.WriteLine("Not moving an inch.");
        }
    }

    public void Enterance() 
    {
        this._currentLocation = "Enterance";
        Program.Flush();
        WhereAmI();
        Console.WriteLine("             ________\r\n             / ______ \\\r\n             || _  _ ||\r\n             ||| || |||\r\n             |||_||_|||\r\n             || _  _o|| (o)\r\n             ||| || |||\r\n             |||_||_|||      ^~^  ,\r\n             ||______||     ('Y') )\r\n            /__________\\    /   \\/\r\n    ________|__________|__ (\\|||/) _________\r\n   hjw     /____________\\\r\n   `97     |____________|\r\n");
        Console.WriteLine("Such a nicely decorated enterance. How fun!");
    }

    public void Hallway()
    {
        this._currentLocation = "Hallway";
        Program.Flush();
        WhereAmI();
        Console.WriteLine("                 _I_\r\n               .~'_`~.\r\n         /(  ,^ .~ ~. ^.  )\\\r\n         \\ \\/ .^ |   ^. \\/ /\r\n          Y  /   |     \\  Y            ___.oOo.___ \r\n          | Y    |      Y |           |           |\r\n          | |    |      | |           |           |\r\n          | |   _|___   | |           |           |\r\n          | |  /____/|  | |           |           |\r\n          |.| |   __/|__|.|           |           |\r\n          |.| |   __/|  |.|          _|___________|_\r\n          |:| |   __//  |:|         '^^^^^^^^^^^^^^^`\r\n          |:| |_____/   |:|\r\n      ____|_|/          |_|_____________________________\r\n      ____]H[           ]H[_____________________________\r\n           /             \\");
        Console.WriteLine("Wowsies! So many doors.");
        Console.WriteLine("CatGod approaches! Do you want to solve her riddle? Be careful, you only will have 2 tries! And make sure you are ready.\n[1] Yes.\n[2] No.");
        _buffer = Console.ReadLine();
        while (!Equals(_buffer, "1") && !Equals(_buffer, "2"))
        {
            Console.WriteLine("What do you mean?");
            _buffer = Console.ReadLine();
        }
        if (Equals(_buffer, "1"))
            this.Riddle();
        else
            Console.WriteLine("Mrow. (Come back when you are ready mortal.)");
    }

    private void Riddle() 
    {
        Program.Flush();
        Console.WriteLine("           ___\r\n          (___)\r\n   ____\r\n _\\___ \\  |\\_/|\r\n\\     \\ \\/ , , \\ ___\r\n \\__   \\ \\ =\"= //|||\\\r\n  |===  \\/____)_)||||\r\n  \\______|    | |||||\r\n      _/_|  | | =====\r\n     (_/  \\_)_)\r\n  _________________\r\n (                _)\r\n  (__   '          )\r\n    (___    _____)\r\n        '--'");
        Console.WriteLine($"Meeeooorrrwww? (God spoke with her might towards {_player.playerName}. What do they say?)\n[1] Uhhh, jellybeans?\n[2] *Bark*\n[3] I hate cats!\n[4] Vroom Vroom.");
        if (_player.sillycatsyndrome)
            Console.WriteLine("[5] Mrow!!!! (Oh my goodness i am just a silly car!!!)");
        _buffer = Console.ReadLine();
        if (Equals(_buffer, "3"))
            Game.YouLost();
        else if (_player.sillycatsyndrome && Equals(_buffer, "5"))
            Game.YouWon();
        else
        {
            Console.WriteLine("... (It is not right. But Cat God gives you another chance.)\n[1] Uhhh, jellybeans?\n[2] *Bark*\n[3] I hate cats!\n[4] Vroom Vroom.");
            if (_player.sillycatsyndrome)
                Console.WriteLine("[5] Mrow!!!! (Oh my goodness i am just a silly car!!!)");
            _buffer = Console.ReadLine();
            if (_player.sillycatsyndrome && Equals(_buffer, "5"))
            {
                Game.YouWon();
                return;
            }
            Game.YouLost();
        }
    }

    public void DiningRoom1()
    {
        this._currentLocation = "DiningRoom1";
        Program.Flush();
        WhereAmI();
        Console.WriteLine(" ____________________________________________________________________________\r\n|: : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : |\r\n| : : : : : : :_______________________________: : : : : : : : : : : : : : : :|\r\n|: : : : : : :|!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!|: : : : : : : : : : : : : : : |\r\n| : : : : : : |.-=^=-.-=^=-.-=^=-.-=^=-.-=^=-.| : : : : : : : : : : : : : : :|\r\n|: : : : : : :'|    _'     '     '     '     |': : : : : : : : : ____: : : : |\r\n| : : : : : : :|   (  ) _                    |: : : : : : : : : /    \\: : : :|\r\n|: : : : : : : |  ( _)__ )_)                 | : : : : : : : : |//    |: : : |\r\n| : : : : : : :|                   \\_/       |: : : : : : : : :|      | : : :|\r\n|==_===========|                 --(_)--     |==================\\____/=======|\r\n| / \\          |                   / \\       |              ,    ,;;,    ,   |\r\n|/___\\         |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|             _d___;(;;);___b_  |\r\n|  |'          |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|            =======`;;`======= |\r\n|  |      ||   ==============(_)==============   ||         /\"\"\"\"\"\"\"\"\"\"\"\"\\   |\r\n|  |      ||        _________~|~_________        ||         |     `(,    |   |\r\n|  |      \\\\_____  (_____________________)  _____//         |  O  )   O  |   |\r\n|  |       |_____)          )   (          (_____|          |  | (@@) |  |   |\r\n|__|_______||___||__________(   )__________||___||__________|_/!\\@@@@/!\\_|__lc\r\n  _|_    .;|';;;'|;;;;;;;;;;_) (_;;;;;;;;;;|';;;'|;.       ================\r\n        :;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;:\r\n        :;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;:\r\n         ':::::::::::::::::::::::::::::::::::::::::'\r\n             ");
        Console.WriteLine("This room warms your hearth.");
        if (_eventDining1)
        {
            Console.WriteLine("There is a gentlecat with a tuxedo dining peacefully. Will you put him into your pocket?\n[1] Yes, I love gentlecats!\n[2] No way.");
            _buffer = Console.ReadLine();
            while (!Equals(_buffer, "1") && !Equals(_buffer, "2"))
            {
                Console.WriteLine("What do you mean?");
                _buffer = Console.ReadLine();
            }
            if (Equals(_buffer, "1"))
            {
                _player._bag.PickUp(Item.TuxedoCatBesiktas);
                _eventDining1 = false;
            }
            else
                Console.WriteLine("Cat keeps dining.");
        }
    }

    public void DiningRoom2()
    {
        this._currentLocation = "DiningRoom2";
        Program.Flush();
        WhereAmI();
        Console.WriteLine("                                  _______________________      |\r\n                                  |  ________   ________  |     |\r\n                                  | |        | |    ___ | |     |\r\n                                  | |        | |  ,',.('| |     |\r\n                                  | |        | | :  .'  | |     |\r\n                                  | |        | | :) _  (| |     |\r\n                                  | |        | |  `:_)_,| |     |\r\n                                  | |________| |________| |     |\r\n                                  |  ________   ________  |     |\r\n                                  | |        | |        | |     |\r\n                                  | |        | |        | |     |\r\n                                  | |        | |        | |     |\r\n                                  | |        | |        | |     |\r\n                                  | |        | |        | |     |\r\n                                  | |________| |________| |     |\r\n                                  |_______________________|     |\r\n                                                                |\r\n                                                                |\r\n                   _____________________________________________|\r\n                                                                `.\r\n                                                                  `.\r\n                                                                    `.\r\n                                                                      `.\r\n                     ..::::::::::::' .:::::::::::::::                   `.\r\n                 ..:::::::::::::::' .:::::::::::::::'                     `\r\n             ..:::::::::::::::::' .:::::::::::::::::\r\n         ..::::::::::::::::::::' .:::::::::::::::::'\r\n     ..::::::::::::::::::::::' .:::::::::::::::::::\r\n ..:::::::::::::::::::::::::' .:::::::::::::::::::'\r\n..........................  ......................\r\n:::::::::::::::::::::::::' .:::::::::::::::::::::'\r\n:::::::::::::::::::::::' .:::::::::::::::::::::::\r\n::::::::::::::::::::::' .:::::::::::::::::::::::'\r\n::::::::::::::::::::' .:::::::::::::::::::::::::\r\n:::::::::::::::::::' .:::::::::::::::::::::::::'");
        Console.WriteLine("So dark! So scary!");
        if (_eventDining2)
        {
            Console.WriteLine("You hear a weird, eerie repeating noise. Will you inspect the room despite the dangers?\n[1] Yes, I am brave!\n[2] No need to take risks.");
            _buffer = Console.ReadLine();
            while (!Equals(_buffer, "1") && !Equals(_buffer, "2"))
            {
                Console.WriteLine("What do you mean?");
                _buffer = Console.ReadLine();
            }
            if (Equals(_buffer, "1"))
            {
                Console.WriteLine("A very cuddly cat jumped into your pocket! She keeps purring too!");
                _player._bag.PickUp(Item.CalicoCatBean);
                _eventDining2 = false;
            }
            else
                Console.WriteLine("Then I shall get out.");
        }
    }
    public void Kitchen()
    {
        this._currentLocation = "Kitchen";
        Program.Flush();
        WhereAmI();
        Console.WriteLine("_____________________________________________________\r\n____________________________________________________\\\\\r\n|.-------.-------.|_.----._.----._|.-------.-------.\\\\\\\r\n|]       |       [|       .       |]       |       [ \\\\\\\r\n||       |       ||     .':'.     ||       |       |  |\\\\\r\n||       |       ||    .' : '.    ||       |       |  |\\\\\\\r\n||     (O|O)     ||   .'  :  '.   ||     (O|O)     |  | \\\\\\\r\n||       |       ||  .'===:==='.  ||       |       | O|  |\\\\\r\n||       |       ||=='    :    '==||       |       |  |  |\\\\\\\r\n|]       |       [|  )    :    (  |]       |       [  |O | \\\\\\\r\n||_______|_______||\"\" ____:_____\"\"||_______|_______|  |  |  |\\\\\r\n'-----------------'_______________'----------------'  |  |  |\\\\\\\r\n|.--------.  |    '---------------'  (o)______)(0)  \\ |  |  | \\\\\\\r\n||        |::|_________________________________())___\\|  | O|  \\\\\\______\r\n||        |::|-----______*!*______-------------))( .'.\\  |  |   | _____ |\r\n||________|::|  _ /       '       \\  _        _   (__.'\\ |  |O  ||     ||\r\n|____________| _  \\_______________/     _           (_.'\\|  |   ||  _  ||\r\n ___________________________________________      _  (___\\  |   ||     ||\r\n||.-----.|.------.|.-.-.--.--.-.-.||.-----.||\\   _        \\ |   ||     ||\r\n||| === ||| ==== ||| | |  |  | | |||| === ||| \\     _      \\|   ||    _||\r\n||'-----'|'------'|'-'-'--'--'-'-'||'-----'||. \\          _ \\   ||     ||\r\n||.-----.|.------.|.------.------.||.-----.|| `|\\       _    \\  || _   ||\r\n||| === |||      |||      |      |||| === |||\\ | \\  _         \\ ||_____||\r\n||'-----'|]      ||]      |      [||'-----'|| \\|. \\        _   \\|_______|\r\n||.-----.||    (O|||    (O|O)    |||.-----.||  | `|\\                   ||\r\n||| === |||      |||      |      |||| === |||  |\\ | \\__________________||\r\n|||     ||]      ||]      |      [|||     ||| O| \\|. |  _____________  ||\r\n||'-----'||______|||______|______|||'-----'||  |  | `| |             | ||\r\n||LGB____|________|_______________||_______||  |O |\\ | |   _         | ||\r\n''-----------------------------------------' \\ |  | \\| |          _  | ||\r\n   ____                 _______               \\|  |  | |       _     | ||\r\n           _________                  ______   \\  |O | |             | ||\r\n                                                \\ |  | |   _      _  | ||\r\n                                _________        \\|  | |             | ||\r\n      ___________        __                       \\  | | _        _  | ||\r\n    __                              _________      \\ | |_____________| ||\r\n               ___________                          \\|_________________||");
        Console.WriteLine("A neat place to bake delicious sweets.");
        if (_eventKitchen)
        {
            Console.WriteLine("The chef cats welcomes you and offers you a nice smelling beverage. Will you take it?\n[1] Yes, sounds fun!\n[2] I don't trust the chef.");
            _buffer = Console.ReadLine();
            while (!Equals(_buffer, "1") && !Equals(_buffer, "2"))
            {
                Console.WriteLine("What do you mean?");
                _buffer = Console.ReadLine();
            }
            if (Equals(_buffer, "1"))
            {
                _player._bag.PickUp(Item.SillyCatTea);
                _eventKitchen = false;
            }
            else
                Console.WriteLine("He gets back to work.");
        }
    }
    public void WC()
    {
        this._currentLocation = "WC";
        Program.Flush();
        WhereAmI();
        Console.WriteLine(" _______________________________________________________________________________ \r\n|% % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % %| \r\n| % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % % | \r\n|% % % % % %_____________________________ % % % % % % % % % % % % % % % % % % % | \r\n| % % % % %|  _________________________  | % % % % % % % % % % % % % % % % % % %| \r\n|% % _ % % |O|                         |O|% % % % % % % % % % _ % % % % % % % % | \r\n| % /_\\ % %| | //                      | | % % % % % % % % % /_\\ % % % % % % % %| \r\n|%  =|=  % |O|                         |O|% % % % % % % % %  =|=  % % % % % % % | \r\n| % % % % %| |    //                   | | % % % % % % % % % % % % % % % % % % %| \r\n|% % % % % |O|                         |O|% % % % % % % % % % % % % % % % % % % | \r\n|==========| |                         | |======================================| \r\n|          |O|                         |O|                                      | \r\n| <=====   | | //                      | |              ________________        | \r\n|          |O|_________________________|O|             |________________|       | \r\n|          |_____________________________|               |            |    _    | \r\n|           ______________/;____________                 |~           |  =)_)=  | \r\n|         /`        .--T--|--T--.       `\\       ____    |            |   (_(   | \r\n|        /_________'------'------'________\\     /PUSH\\   |__%______%__|   )_)   | \r\n|         |  _____   ____   ____   _____ |     /______\\   .`        `.          | \r\n|         | |__~__| |    | |    | |__~__||     |      |   :          :          | \r\n|         |         |    | |    |        |     |      |    '.      .'           | \r\nlc________|         |   {| |}   |        |_____|      |______\\`'-'`/____________| \r\n          |         |    | |    |        |     |______|       |   | \r\n          |_________|____|_|____|________|                    |___|");
        Console.WriteLine("There is even toilet paper!");
        if (_eventWc)
        {
            Console.WriteLine("Turns out it is occupied! A huge stinker sits on the toilet. Do you want to pick him up?\n[1] Yes, I need the stinker.\n[2] Ew, no.");
            _buffer = Console.ReadLine();
            while (!Equals(_buffer, "1") && !Equals(_buffer, "2"))
            {
                Console.WriteLine("What do you mean?");
                _buffer = Console.ReadLine();
            }
            if (Equals(_buffer, "1"))
            {
                _player._bag.PickUp(Item.OrangeCatHector);
                _eventWc = false;
            }
            else
                Console.WriteLine("Let's give him some privacy.");
        }
    }
    public void WhereAmI()
    {
        Console.WriteLine($"You are in the {this._currentLocation}.");
    }
}
