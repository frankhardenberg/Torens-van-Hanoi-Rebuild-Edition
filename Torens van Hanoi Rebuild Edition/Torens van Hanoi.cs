using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torens_van_Hanoi_Rebuild_Edition
{
    public partial class TorensVanHanoi : Form
    {
        Button GeselecteerdeDisk = null;
        Point Coordinates;
        const int AfstandVanTorens = 250;
        const int AfstandTussenButtons = 35;
        Point Stack1Coordinates = new Point(130, 50);
        Point Stack2Coordinates = new Point(380, 50);
        Point Stack3Coordinates = new Point(630, 50);
        int[] TorenLocaties;
        Button[] Buttons;
        int ClickCount = 0;
        int[] StackLocations = new int[8];

        public TorensVanHanoi()
        {
            InitializeComponent();
            Coordinates = this.PointToClient(Cursor.Position);
            Buttons = new Button[] { Disk1, Disk2, Disk3, Disk4, Disk5, Disk6, Disk7, Disk8 };
            TorenLocaties = new int[] { Toren1.Location.X, Toren2.Location.X, Toren3.Location.X };
            StartingStack();
        }
               
        void StartingStack()
        {
            for (int j = 0; j < Buttons.Length; j++)
            {
                Stacks[0].Push(Buttons[j]);
            }            
        }

        Stack<Button>[] Stacks = new Stack<Button>[]
        {
            new Stack<Button>(),
            new Stack<Button>(),
            new Stack<Button>()
        };

        private int FindTower()
        {
            for (int i = 0; i < Stacks.Length; ++i)
            {
                foreach (Button b in Stacks[i].ToArray())
                {
                    if (Convert.ToInt32(b.Text) == Convert.ToInt16(GeselecteerdeDisk.Text))
                    {
                        return i;
                    }

                    Stacks[i].Pop();
                }
            }
            
            throw new Exception("Missing disk!");
        }

        private void Disk1_MouseDown(object sender, MouseEventArgs e) // Alle Disks
        {
            if (ClickCount == 0)
            {
                GeselecteerdeDisk = (Button)sender;
                FindTower();
                ++ClickCount;
            }

            else if (ClickCount == 1)
            {
                for (int i = 0; i < 1; i++)
                {
                    if (Coordinates.X < TorenLocaties[i])
                    {
                        Stacks[i].Push(GeselecteerdeDisk);
                        ClickCount = 0;
                    }

                    if (Coordinates.X > TorenLocaties[i] && Coordinates.X < TorenLocaties[i + 1])
                    {
                        
                        Stacks[i].Push(GeselecteerdeDisk);

                        for (int x = 0; x < Buttons.Length; ++x)
                        {
                            if (Convert.ToInt16(Buttons[x]) == Convert.ToInt16(GeselecteerdeDisk.Text))
                            {
                                GeselecteerdeDisk.Location = new Point(( + AfstandVanTorens));
                                GeselecteerdeDisk.Location = new Point(y - x * AfstandTussenButtons);
                            }
                        }

                        ClickCount = 0;
                    }

                    if (Coordinates.X > TorenLocaties[i + 2])
                    {
                        Stacks[i].Push(GeselecteerdeDisk);
                        ClickCount = 0;
                    }
                }
            }
        }

        private void Disk1_MouseUp(object sender, MouseEventArgs e) // Alle Disks
        {
            
        }
    }
}
