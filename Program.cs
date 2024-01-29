using System;
using System.Threading;

namespace DGD203_game
{
    internal class Program
    {
        public static int score=0;
        public static void Flush()
        {
            Thread.Sleep(1000);
            Console.Clear();
        }
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();
            game.GameLoop();
        }
    }
    public class Game
    {
        public static bool gameOn = true;
        private string _buffer;
        private Player _player;
        private Location _location;
        public void StartGame()
        {
            Console.WriteLine("                                                     ___\r\n                                             ___..--'  .`.\r\n                                    ___...--'     -  .` `.`.\r\n                           ___...--' _      -  _   .` -   `.`.\r\n                  ___...--'  -       _   -       .`  `. - _ `.`.\r\n           __..--'_______________ -         _  .`  _   `.   - `.`.\r\n        .`    _ /\\    -        .`      _     .`__________`. _  -`.`.\r\n      .` -   _ /  \\_     -   .`  _         .` |  Cat Cafe |`.   - `.`.\r\n    .`-    _  /   /\\   -   .`        _   .`   |___________|  `. _   `.`.\r\n  .`________ /__ /_ \\____.`____________.`     ___       ___  - `._____`|\r\n    |   -  __  -|    | - |  ____  |   | | _  |   |  _  |   |  _ |\r\n    | _   |  |  | -  |   | |.--.| |___| |    |___|     |___|    |\r\n    |     |--|  |    | _ | |'--'| |---| |   _|---|     |---|_   |\r\n    |   - |__| _|  - |   | |.--.| |   | |    |   |_  _ |   |    |\r\n ---``--._      |    |   |=|'--'|=|___|=|====|___|=====|___|====|\r\n -- . ''  ``--._| _  |  -|_|.--.|_______|_______________________|\r\n`--._           '--- |_  |:|'--'|:::::::|:::::::::::::::::::::::|\r\n_____`--._ ''      . '---'``--._|:::::::|:::::::::::::::::::::::|\r\n----------`--._          ''      ``--.._|:::::::::::::::::::::::|\r\n`--._ _________`--._'        --     .   ''-----..............LGB'\r\n     `--._----------`--._.  _           -- . :''           -    ''\r\n          `--._ _________`--._ :'              -- . :''      -- . ''\r\n -- . ''       `--._ ---------`--._   -- . :''\r\n          :'        `--._ _________`--._:'  -- . ''      -- . ''\r\n  -- . ''     -- . ''    `--._----------`--._      -- . ''     -- . ''\r\n                              `--._ _________`--._\r\n -- . ''           :'              `--._ ---------`--._-- . ''    -- . ''\r\n          -- . ''       -- . ''         `--._ _________`--._   -- . ''\r\n:'                 -- . ''          -- . ''  `--._----------`--._");
            Console.WriteLine("Welcome to the totally normal cat cafe. Who are you?");
            _buffer = Console.ReadLine();
            if (Equals(_buffer, ""))
                _buffer = "DefaultCatPerson";
            _player = new Player(_buffer);
            Console.WriteLine($"Nice to meet you {_player.playerName}, we hope you enjoy your stay! (You are very thirsty btw!!!)");
            Console.WriteLine("Type 'move' to move, 'items' to see inventory and 'exit' to terminate. (Please wait...)");
            Thread.Sleep(1000);
            Program.Flush();
        }
        public void GameLoop()
        { 
            _location = new Location(_player);
            while (Game.gameOn)
            {
                _buffer = Console.ReadLine();
                switch (_buffer)
                {
                    case "move":
                        _location.Move();
                        break;
                    case "items":
                        _player._bag.CheckItems();
                        break;
                    case "exit":
                        Console.WriteLine("BuhBye!");
                        Thread.Sleep(3000);
                        return;
                    case "help":
                        Console.WriteLine("Type 'move' to move, 'items' to see inventory and 'exit' to terminate.");
                        break;
                    default:
                        Console.WriteLine("I don't understand. Please type 'help' to see commands.");
                        break;
                }
            }
        }
        public static void YouWon()
        {
            Program.Flush();
            Console.WriteLine(".==============================================.\r\n|                                              |\r\n|                           .'\\                |\r\n|                          //  ;               |\r\n|                         /'   |               |\r\n|        .----..._    _../ |   \\               |\r\n|         \\'---._ `.-'      `  .'              |\r\n|          `.    '              `.             |\r\n|            :            _,.    '.            |\r\n|            |     ,_    (() '    |            |\r\n|            ;   .'(().  '      _/__..-        |\r\n|            \\ _ '       __  _.-'--._          |\r\n|            ,'.'...____'::-'  \\     `'        |\r\n|           / |   /         .---.              |\r\n|     .-.  '  '  / ,---.   (     )             |\r\n|    / /       ,' (     )---`-`-`-.._          |\r\n|   : '       /  '-`-`-`..........--'\\         |\r\n|   ' :      /  /                     '.       |\r\n|   :  \\    |  .'         o             \\      |\r\n|    \\  '  .' /          o       .       '     |\r\n|     \\  `.|  :      ,    : _o--'.\\      |     |\r\n|      `. /  '       ))    (   )  \\>     |     |\r\n|        ;   |      ((      \\ /    \\___  |     |\r\n|        ;   |      _))      `'.-'. ,-'` '     |\r\n|        |    `.   ((`            |/    /      |\r\n|        \\     ).  .))            '    .       |\r\n|     ----`-'-'  `''.::.________:::mx'' ---    |\r\n|                                              |\r\n|                                              |\r\n|                                              |\r\n'=============================================='");
            Console.WriteLine("You have won! How silly of you.");
            Console.WriteLine($"Your stars: ");
            for (int i = 0; i < Program.score; i++) 
                Console.Write(" *");
            if (Program.score == 3)
                Console.WriteLine("Well done. You finished the game with full stars!");
            else
                Console.WriteLine("You could've done better.");
            Thread.Sleep(3000);
            Game.gameOn = false;
        }
        public static void YouLost()
        {
            Program.Flush();
            Console.WriteLine("                             .                                   \r\n                          ,''`.         _                        \r\n                     ,.,'''  '`--- ._,,'|                        \r\n                   ,'                   /                        \r\n              __.-'                    |                         \r\n           ''                ___   ___ |                         \r\n         ,'                  \\(|\\ /|)/ |                         \r\n        ,'                 _     _     `._                       \r\n       /     ,.......-\\    `.      __     `-.                    \r\n      /     ,' :  .:''`|    `:`.../:.`` ._   `._                 \r\n  ,..,'  _/' .: :'     |     |      '.    \\.    \\                \r\n /      ,'  :'.:  / \\  |     | / \\   ':.  . \\    \\               \r\n|      /  .: :' ,'  _)  \".._,;'  _)    :. :. \\    |              \r\n |     | :'.:  /   |   .,   /   |       :  :  |   |              \r\n |     |:' :  /____|  /  \\ /____|       :  :  |  ,'              \r\n  |   /    '         /    \\            :'   : |,/                \r\n   \\ |  '_          /______\\              , : |                  \r\n  _/ |  \\'`--`.    _            ,_   ,-'''  :.|         __       \r\n /   |   \\..   ` ./ `.   _,_  ,'  ``'  /'   :'|      _,''/       \r\n/   /'. :   \\.   _    [_]   `[_]  .__,,|   _....,--=/'  /:       \r\n|   \\_| :    `.-' `.    _.._     /     . ,'  :. ':/'  /'  `.     \r\n`.   '`'`.         `. ,.'   ` .,'     :'/ ':..':.    |  .:' `.   \r\n  \\.      \\          '               :' |    ''''      ''     `. \r\n    `''.   `|        ':     .      .:' ,|         .  ..':.      |\r\n      /'   / '\"-..._  :   .:'    _;:.,'  \\.     .:'   :. ''.    |\r\n     (._,.'        '`''''''''''''          \\.._.:      ':  ':   /\r\n________                                      '`- ._    ,:__,,-' \r\n  |ooShy                                            ``''");
            Console.WriteLine("You enraged the Cat God! Games are over!");
            Thread.Sleep(3000);
            Game.gameOn = false;
        }
    }
}
