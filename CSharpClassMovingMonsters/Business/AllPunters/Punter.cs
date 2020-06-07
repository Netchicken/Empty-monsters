using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpClassMovingMonsters.Business.AllPunters
{
    //you can use any of these fields BUT you might forget an important one
    public abstract class Punter
    {
        public string PunterName { get; set; }
        public string Monster { get; set; }
        public Single Cash { get; set; }
        public Single Bet { get; set; }
        public Label LabelWinner { get; set; }

        public Color MyColor { get; set; }

        public string FavoriteDrink { get; set; }



    }
}
