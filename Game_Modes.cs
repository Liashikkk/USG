using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGG
{
    class Game_Modes : Program
    {
        All_Images Image = new All_Images();
        
        public void Play_Two_Players_Shotgun_Mode()
        {
            //Инициализация всех нужных переменных
            
            Random Random_Number = new Random();
            
            int PlayerOne_Lives = 3;
            int PlayerTwo_Lives = 3;
            bool PlayerOne_Live_Now = true;
            bool PlayerTwo_Live_Now = true;
            
            int PlayerOne_HandCuffed = 0;
            int PlayerTwo_HandCuffed = 0;
            
            string[] PlayerOne_Inventory = new string[6];
            string[] PlayerTwo_Inventory = new string[6];
            int Max_Of_PlayerOne_Inventory = 0;
            int Max_Of_PlayerTwo_Inventory = 0;
            int Num_To_PlayerOne_Items = 0;

            int Num_To_PlayerTwo_Items = 0;
            int Turn_To_Play = Random_Number.Next(1, 2);

            //Игроки делятся на первого и второго игрока и вводят свои имена
            string PlayerOne_Name = Image.PlayerOne_Name_Input();
            string PlayerTwo_Name = Image.PlayerTwo_Name_Input();

            //Распределение патронов, извучка их игрокам, зарядка их в магазин и выдача 2-х предметов (в первый раз)
            string[] Magazine = new string[8];
            int Count_Not_Fired_Shells = 7;
            int Count_Of_Live = Random_Number.Next(1, 7);
            int Count_Of_Blank = 8 - Count_Of_Live;
            int Count_Of_Live_to_Magazine = Count_Of_Live;
            int Count_Of_Blank_To_Magazine = Count_Of_Blank;
            int Random_Number_for_Magazine;
            string Temp_For_Magazine;
            Console_WriteReadClear(Image.How_Live_Shells_Will_Be(Count_Of_Live));
            //Зарядка магазина (8 патронов в общем)
            for (int i = 0; i < 8; i++)
            {
                if (Count_Of_Live_to_Magazine > 0)
                {
                    Magazine[i] = "Боевой";
                    Count_Of_Live_to_Magazine--;
                }
                else
                {
                    Magazine[i] = "Холостой";
                    Count_Of_Live_to_Magazine--;
                }
            }
            for (int i = Magazine.Length - 1; i > 0; i--)
            {
                Random_Number_for_Magazine = Random_Number.Next(i + 1);
                Temp_For_Magazine = Magazine[Random_Number_for_Magazine];
                Magazine[Random_Number_for_Magazine] = Magazine[i];
                Magazine[i] = Temp_For_Magazine;
            }
            //Bыдача 2-x предметов
            for (int i = 0; i < 2; i++)
            {
                int Number_Of_Item = Random_Number.Next(1, 4);
                if (Max_Of_PlayerOne_Inventory < 6)
                {
                    switch (Number_Of_Item)
                    {
                        case 1:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "+хп";
                            Max_Of_PlayerOne_Inventory++;
                            Num_To_PlayerOne_Items++;
                            break;
                        case 2:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "наручники";
                            Max_Of_PlayerOne_Inventory++;
                            Num_To_PlayerOne_Items++;
                            break;
                        case 3:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "патрончекер";
                            Max_Of_PlayerOne_Inventory++;
                            Num_To_PlayerOne_Items++;
                            break;
                    }
                }

            }
            for (int i = 0; i < 2; i++)
            {
                int Number_Of_Item = Random_Number.Next(1, 4);
                if (Max_Of_PlayerTwo_Inventory < 6)
                {
                    switch (Number_Of_Item)
                    {
                        case 1:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "+хп";
                            Max_Of_PlayerTwo_Inventory++;
                            Num_To_PlayerTwo_Items++;
                            break;
                        case 2:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "наручники";
                            Max_Of_PlayerTwo_Inventory++;
                            Num_To_PlayerTwo_Items++;
                            break;
                        case 3:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "патрончекер";
                            Max_Of_PlayerTwo_Inventory++;
                            Num_To_PlayerTwo_Items++;
                            break;
                    }
                }
            }
            Console_WriteReadClear(Image.All_Players_Has_Given_Two_Items_Page);
            //Начало игры
            while (PlayerOne_Live_Now == true && PlayerTwo_Live_Now == true)
            {
                //Определение следующего хода
                if (Turn_To_Play == 1 && PlayerTwo_HandCuffed == 0)
                {
                    Turn_To_Play = 2;
                }
                else if (Turn_To_Play == 2 && PlayerOne_HandCuffed == 0)
                {
                    Turn_To_Play = 1;
                }
                if (Count_Not_Fired_Shells == 0)
                {
                    //Распределение патронов, извучка их игрокам, зарядка их в магазин и выдача 2-х предметов (происходит, когда патронов нет)
                    Count_Of_Live = Random_Number.Next(1, 7);
                    Count_Of_Blank = 8 - Count_Of_Live;
                    Count_Of_Live_to_Magazine = Count_Of_Live;
                    Count_Of_Blank_To_Magazine = Count_Of_Blank;
                    Console_WriteReadClear(Image.How_Live_Shells_Will_Be(Count_Of_Live));
                    //Зарядка магазина (8 патронов в общем)
                    for (int i = 0; i < 8; i++)
                    {
                        if (Count_Of_Live_to_Magazine > 0)
                        {
                            Magazine[i] = "Боевой";
                            Count_Of_Live_to_Magazine--;
                        }
                        else
                        {
                            Magazine[i] = "Холостой";
                            Count_Of_Live_to_Magazine--;
                        }
                    }
                    for (int i = Magazine.Length - 1; i > 0; i--)
                    {
                        Random_Number_for_Magazine = Random_Number.Next(i + 1);
                        Temp_For_Magazine = Magazine[Random_Number_for_Magazine];
                        Magazine[Random_Number_for_Magazine] = Magazine[i];
                        Magazine[i] = Temp_For_Magazine;
                    }
                    //Bыдача 2-x предметов
                    for (int i = 0; i < 2; i++)
                    {
                        int Number_Of_Item = Random_Number.Next(1, 4);
                        if (Max_Of_PlayerOne_Inventory < 6)
                        {
                            switch (Number_Of_Item)
                            {
                                case 1:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "+хп";
                                    Max_Of_PlayerOne_Inventory++;
                                    Num_To_PlayerOne_Items++;
                                    break;
                                case 2:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "наручники";
                                    Max_Of_PlayerOne_Inventory++;
                                    Num_To_PlayerOne_Items++;
                                    break;
                                case 3:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "патрончекер";
                                    Max_Of_PlayerOne_Inventory++;
                                    Num_To_PlayerOne_Items++;
                                    break;
                            }
                        }

                    }
                    for (int i = 0; i < 2; i++)
                    {
                        int Number_Of_Item = Random_Number.Next(1, 4);
                        if (Max_Of_PlayerTwo_Inventory < 6)
                        {
                            switch (Number_Of_Item)
                            {
                                case 1:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "+хп";
                                    Max_Of_PlayerTwo_Inventory++;
                                    Num_To_PlayerTwo_Items++;
                                    break;
                                case 2:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "наручники";
                                    Max_Of_PlayerTwo_Inventory++;
                                    Num_To_PlayerTwo_Items++;
                                    break;
                                case 3:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "патрончекер";
                                    Max_Of_PlayerTwo_Inventory++;
                                    Num_To_PlayerTwo_Items++;
                                    break;
                            }
                        }
                    }
                    Console_WriteReadClear(Image.All_Players_Has_Given_Two_Items_Page);
                }
                //Распределение ходов
                while (Turn_To_Play == 1 && Count_Not_Fired_Shells > 0 && PlayerOne_Live_Now == true && PlayerTwo_Live_Now == true)
                {
                    if (PlayerTwo_HandCuffed - 1 == 0)
                    {
                        Turn_To_Play = 2;
                    }
                    //ход первого игрока
                    if (PlayerTwo_HandCuffed > 0)
                    {
                        PlayerTwo_HandCuffed--;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(Image.PlayerOne_Menu_When_Opponent_Handcuffed(PlayerOne_Name, PlayerTwo_Name));
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write(Image.PlayerOne_Menu(PlayerOne_Name, PlayerTwo_Name));
                    }
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                PlayerOne_Lives--;
                                if (PlayerOne_Lives == 0)
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Yourself_And_You_Will_Be_Dead);
                                    PlayerOne_Live_Now = false;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Yoursef_And_You_Will_Alive(PlayerOne_Lives));
                                    Count_Of_Live--;
                                    if (PlayerTwo_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                    Count_Not_Fired_Shells--;
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shot_Yourself);
                                Count_Of_Blank_To_Magazine--;
                                Count_Not_Fired_Shells--;
                            }
                            break;
                        case 2:
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                PlayerTwo_Lives--;
                                if (PlayerTwo_Lives == 0)
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Opponent_And_He_Will_Be_Dead);
                                    PlayerTwo_Live_Now = false;
                                    Count_Not_Fired_Shells = -1;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Opponent_And_He_Will_Alive(PlayerTwo_Lives));
                                    Count_Of_Live--;
                                    Count_Not_Fired_Shells--;
                                    if (PlayerTwo_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shot_Opponent);
                                Count_Of_Blank--;
                                Count_Not_Fired_Shells--;
                                if (PlayerTwo_HandCuffed == 0)
                                {
                                    Turn_To_Play = 2;
                                }
                            }
                            break;
                        case 3:
                            if (Max_Of_PlayerOne_Inventory == 0)
                            {
                                Console_WriteReadClear(Image.Player_Dont_Have_Items_Page);
                            }
                            else
                            {
                                bool Items_Menu = true;
                                while (Items_Menu)
                                {
                                    Console.SetCursorPosition(0, 0);
                                    Console.Write(Image.All_Player_Items_Page);
                                    for (int i = 0; i < Max_Of_PlayerOne_Inventory; i++)
                                    {
                                        Console.Write(PlayerOne_Inventory[i] + ", ");
                                    }
                                    Console.Write(" и все.                                                                                                                              ");
                                    switch (Convert.ToInt32(Console.ReadLine()))
                                    {
                                        case 1:
                                            if (PlayerOne_Inventory.Contains("+хп") == true)
                                            {
                                                PlayerOne_Lives++;
                                                Console_WriteReadClear(Image.Count_Player_Lives_After_Heal(PlayerOne_Lives));
                                                int numIndex = Array.IndexOf(PlayerOne_Inventory, "+хп");
                                                PlayerOne_Inventory = PlayerOne_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                Max_Of_PlayerOne_Inventory--;
                                                Num_To_PlayerOne_Items--;
                                                Items_Menu = false;
                                            }
                                            break;
                                        case 2:
                                            if (PlayerOne_Inventory.Contains("наручники") == true)
                                            {
                                                if (PlayerTwo_HandCuffed > 0)
                                                {
                                                    Console_WriteReadClear(Image.Opponent_Already_HandCuffed);
                                                }
                                                else
                                                {
                                                    PlayerTwo_HandCuffed = 2;
                                                    int numIndex = Array.IndexOf(PlayerOne_Inventory, "наручники");
                                                    PlayerOne_Inventory = PlayerOne_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                    Max_Of_PlayerOne_Inventory--;
                                                    Num_To_PlayerOne_Items--;
                                                    Items_Menu = false;
                                                }

                                            }
                                            break;
                                        case 3:
                                            if (PlayerOne_Inventory.Contains("патрончекер") == true)
                                            {
                                                Console_WriteReadClear(Image.What_Is_Shell_Be_Now(Magazine[Count_Not_Fired_Shells]));
                                                int numIndex = Array.IndexOf(PlayerOne_Inventory, "патрончекер");
                                                PlayerOne_Inventory = PlayerOne_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                Max_Of_PlayerOne_Inventory--;
                                                Num_To_PlayerOne_Items--;
                                                Items_Menu = false;
                                            }
                                            break;
                                        case 4:
                                            Items_Menu = false;
                                            break;
                                        default:
                                            Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            break;
                                    }
                                }
                            }
                            break;
                    }
                }
                while (Turn_To_Play == 2 && Count_Not_Fired_Shells >= 0 && PlayerTwo_HandCuffed == 0)
                {
                    //ход синего (второго игрока)
                    if (PlayerOne_HandCuffed - 1 == 0)
                    {
                        Turn_To_Play = 1;
                    }
                    if (PlayerOne_HandCuffed > 0)
                    {
                        PlayerOne_HandCuffed--;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(Image.PlayerTwo_Menu_When_Opponent_Handcuffed(PlayerOne_Name, PlayerTwo_Name));
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write(Image.PlayerTwo_Menu(PlayerOne_Name, PlayerTwo_Name));
                    }
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                PlayerTwo_Lives--;
                                if (PlayerTwo_Lives == 0)
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Yourself_And_You_Will_Be_Dead);
                                    PlayerTwo_Live_Now = false;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Yoursef_And_You_Will_Alive(PlayerTwo_Lives));
                                    Count_Of_Live--;
                                    Count_Not_Fired_Shells--;
                                    if (PlayerOne_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 1;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shot_Yourself);
                                Count_Of_Blank--;
                                Count_Not_Fired_Shells--;
                            }
                            break;
                        case 2:
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                PlayerOne_Lives--;
                                if (PlayerOne_Lives == 0)
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Opponent_And_He_Will_Be_Dead);
                                    PlayerOne_Live_Now = false;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Opponent_And_He_Will_Alive(PlayerOne_Lives));
                                    Count_Of_Live--;
                                    Count_Not_Fired_Shells--;
                                    if (PlayerOne_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 1;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shot_Opponent);
                                Count_Of_Blank--;
                                Count_Not_Fired_Shells--;
                                if (PlayerOne_HandCuffed == 0)
                                {
                                    Turn_To_Play = 1;
                                }
                            }
                            break;
                        case 3:
                            if (Max_Of_PlayerTwo_Inventory == 0)
                            {
                                Console_WriteReadClear(Image.Player_Dont_Have_Items_Page);
                            }
                            else if (Max_Of_PlayerTwo_Inventory > 0)
                            {
                                bool Items_Menu = true;
                                while (Items_Menu)
                                {
                                    Console.SetCursorPosition(0, 0);
                                    Console.Write(Image.All_Player_Items_Page);
                                    for (int i = 0; i < Max_Of_PlayerTwo_Inventory; i++)
                                    {
                                        Console.Write(PlayerTwo_Inventory[i] + ", ");
                                    }
                                    Console.Write(" и все.                                                                                                                              ");
                                    switch (Convert.ToInt32(Console.ReadLine()))
                                    {
                                        case 1:
                                            if (PlayerTwo_Inventory.Contains("+хп") == true)
                                            {
                                                PlayerTwo_Lives++;
                                                Console_WriteReadClear(Image.Count_Player_Lives_After_Heal(PlayerTwo_Lives));
                                                int numIndex = Array.IndexOf(PlayerTwo_Inventory, "+хп");
                                                PlayerTwo_Inventory = PlayerTwo_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                Max_Of_PlayerTwo_Inventory--;
                                                Num_To_PlayerTwo_Items--;
                                                Items_Menu = false;
                                            }
                                            break;
                                        case 2:
                                            if (PlayerTwo_Inventory.Contains("наручники") == true)
                                            {
                                                if (PlayerOne_HandCuffed > 0)
                                                {
                                                    Console_WriteReadClear(Image.Opponent_Already_HandCuffed);
                                                }
                                                else
                                                {
                                                    PlayerOne_HandCuffed = 2;
                                                    int numIndex = Array.IndexOf(PlayerTwo_Inventory, "наручники");
                                                    PlayerTwo_Inventory = PlayerTwo_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                    Max_Of_PlayerTwo_Inventory--;
                                                    Num_To_PlayerTwo_Items--;
                                                    Items_Menu = false;
                                                }
                                            }
                                            break;
                                        case 3:
                                            if (PlayerTwo_Inventory.Contains("патрончекер") == true)
                                            {
                                                Console_WriteReadClear(Image.What_Is_Shell_Be_Now(Magazine[Count_Not_Fired_Shells]));
                                                int numIndex = Array.IndexOf(PlayerTwo_Inventory, "патрончекер");
                                                PlayerTwo_Inventory = PlayerTwo_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                Max_Of_PlayerTwo_Inventory--;
                                                Num_To_PlayerTwo_Items--;
                                                Items_Menu = false;
                                            }
                                            break;
                                        case 4:
                                            Items_Menu = false;
                                            break;
                                        default:
                                            Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            break;
                                    }
                                }
                            }
                            break;
                        default:
                            Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                            break;
                    }
                }
            }
        }
    }
}
