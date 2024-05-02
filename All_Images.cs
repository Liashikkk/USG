using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGG
{
    class All_Images : Program
    {
        public string Main_Menu = "главное меню. 1+Enter - начать игру, 3+Enter - выйти из игры (2+Enter - статистика, которой пока что нет).                                                                                                                                                                        ";
        public string Game_Modes_Choose = "тут выбор режима игры. 1+Enter - режим с дробовиком на 6 патронов, каждый раунд дается два предмета? 2+Enter - вернуться в главное меню.                                                                                                                                                                 ";

        public string Player_Menu = "перед вашим лицом соперник. 1+Enter - выстрел в себя, 2+Enter - выстрел в соперника, 3+Enter - меню предметов                                                                                                                                                                  ";
        public string Player_Menu_When_Opponent_Handcuffed = "перед вашим лицом соперник, у него связаны руки. 1+Enter - выстрел в себя, 2+Enter - выстрел в соперника, 3+Enter - воспользоваться предметом                                                                                                 ";
        
        public string This_Button_Isnt_Exists = "такой кнопки не существует =). Еnter для перехода на следующее меню                                                                                                                                                                                          ";

        public string All_Players_Has_Given_Two_Items_Page = "игрокам без предметов были выданы предметы. Еnter для перехода на следующее меню                                                                                                                                                                                                   ";

        public string Live_Shot_Opponent_And_He_Will_Be_Dead = "прозвучал выстрел... его тело падает замертво. поздравляю =). Еnter для перехода на следующее меню                                                                                                                                ";
        public string Live_Shot_Yourself_And_You_Will_Be_Dead = "прозвучал выстрел... ваше тело падает замертво... как жаль =(. Еnter для перехода на следующее меню                                                                                                                                ";

        public string Blank_Shot_Opponent = "щелчок... какая досада =(. Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        public string Blank_Shot_Yourself = "щелчок... какое облегчение =). Еnter для перехода на следующее меню                                                                                                                                                                                                ";

        public string Player_Dont_Have_Items_Page = "у тебя нет предметов =/. Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        public string All_Player_Items_Page = "1+Enter - использовать +хп, 2+Enter - использовать наручники (соперник пропустит ход, т.е. вы походите два раза), 3+Enter - использовать патрончекер (покажет какой патрон будет выстрелен), 4+Enter - выйти из этого меню. у тебя есть: ";

        public string Opponent_Already_HandCuffed = "его руки уже связаны =). Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        public string How_Live_Shells_Will_Be(int Count_Of_Live_Shells)
        {
            return $"Боевых патронов {Count_Of_Live_Shells} из 6 в общем количестве. удачи =). Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        }
        public string Live_Shot_Yoursef_And_You_Will_Alive(int Count_Player_Lives)
        {
            return $"прозвучал выстрел... количество твоих жизней = {Count_Player_Lives}. Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        }
        public string Live_Shot_Opponent_And_He_Will_Alive(int Count_Opponent_Lives)
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
    }
}
