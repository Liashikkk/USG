﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGG
{
    class All_Images : Program
    {
        public string Main_Menu = "главное меню. 1 - начать игру, 3 - выйти из игры (2 - статистика, которой пока что нет).                                                                                                                                                                        ";
        public string Game_Modes_Choose = "тут выбор режима игры. 1 - режим с дробовиком, каждый раунд дается два предмета, 2 - вернуться в главное меню.                                                                                                                                                                 ";

        public string This_Button_Isnt_Exists = "такой кнопки не существует =). Еnter для перехода на следующее меню                                                                                                                                                                                          ";

        public string All_Players_Has_Given_Two_Items = "некоторые свободные слоты ваших инвентарей заполучили предметы. Еnter для перехода на следующее меню                                                                                                                                                                                                   ";

        public string Live_Shot_Opponent_Dead = "прозвучал выстрел... его тело падает замертво. поздравляю =). Еnter для перехода на следующее меню                                                                                                                                ";
        public string Live_Shot_Yourself_Dead = "прозвучал выстрел... ваше тело падает замертво... как жаль =(. Еnter для перехода на следующее меню                                                                                                                                ";

        public string Blank_Shot_Opponent = "щелчок... какая досада =(. Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        public string Blank_Shot_Yourself = "щелчок... какое облегчение =). Еnter для перехода на следующее меню                                                                                                                                                                                                ";

        public string Player_Dont_Have_Items = "у тебя нет предметов =/. Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        public string All_Player_Items = "1 - использовать +хп, 2- использовать наручники (соперник пропустит ход, т.е. вы походите два раза), 3 - использовать патрончекер (покажет какой патрон будет выстрелен), 4 - выйти из этого меню. у тебя есть: ";

        public string Opponent_Already_HandCuffed = "его руки уже связаны =). Еnter для перехода на следующее меню                                                                                                                                                                                                ";

        public string Choose_Max_Count_Of_Items = "выберите кол-во предметов, которые вы будете получать после зарядка магазина, максимум 4.                                                                                                                                                                         ";

        public string Wrong_Num_For_Count_Of_Items = "вы выбрали неверное кол-во предметов. Еnter для перехода на следующее меню                                                                                                                                                                                                                                              ";
        
        public string Shotgun_Rules = "правила игры для дробовика...Еnter для перехода на следующее меню                                                                                                                                                                                                                                 ";

        public string SawOfShotgun_Rules = "правила игры для обреза...Еnter для перехода на следующее меню                                                                                                                                                                                            ";

        public string PlayerOne_Name_Input()
        {
            Console.Clear();
            Console.Write("выбирайте свою позицию: первый и второй. первый игрок, введи своё имя: ");
            string Name = Console.ReadLine();
            return Name; 
        }
        public string PlayerTwo_Name_Input()
        {
            Console.Write("теперь второй игрок, введи своё имя: ");
            string Name = Console.ReadLine();
            return Name;
        }

        public string How_Live_Shells_Will_Be(int Count_Of_Live_Shells, int Count_All_Posible_Shells)
        {
            return $"Боевых патронов {Count_Of_Live_Shells} из {Count_All_Posible_Shells}. удачи =). Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        }

        public string Live_Shot_Yoursef_Alive(int Count_Player_Lives)
        {
            return $"прозвучал выстрел... количество твоих жизней = {Count_Player_Lives}. Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        }

        public string Live_Shot_Opponent_Alive(int Count_Opponent_Lives)
        {
            return $"прозвучал выстрел... количество его жизней = {Count_Opponent_Lives}. Еnter для перехода на следующее меню                                                                                                                                                                ";
        }

        public string Count_Player_Lives_After_Heal(int Player_Lives)
        {
            return $"Количество твоих жизней теперь = {Player_Lives}. Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        }

        public string What_Is_Shell_Be_Now(string Shell_Type)
        {
            return $"В патроннике сейчас находится - {Shell_Type} патрон. Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        }

        public string Player_Menu(string Player_Name, int Count_Of_Player_Lives, string Opponent_Name, int Count_Of_Items, bool Opponent_HandCuffed = false)
        {
            if (Count_Of_Items == 0)
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}. кол-во ваших жизней {Count_Of_Player_Lives}. 1 - выстрел в себя, 2 - выстрел в соперника.                                                                                                                                                                                                                       ";
            }
            else if (Opponent_HandCuffed)
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}, у него связаны руки. кол-во ваших жизней {Count_Of_Player_Lives}. 1 - выстрел в себя, 2 - выстрел в соперника, 3 - меню предметов.                                                                                                                                                                                               ";
            }
            else
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}. кол-во ваших жизней {Count_Of_Player_Lives}. 1 - выстрел в себя, 2 - выстрел в соперника, 3 - меню предметов.                                                                                                                                                                                                                       ";
            }
        }
        

        
        
    }
}
