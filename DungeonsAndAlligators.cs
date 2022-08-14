using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;


namespace DungeonsAndAlligators
{
    public partial class DungeonForm : Form 
    {
        int moveX = 0, moveY = 0, stepCounter = 0, deathCounter = 0, selectedIndex = -1, AIRow = 4, AIColumn = 4; 

        ArrayList DungeonTile = new ArrayList();
                                               
        ArrayList GoodStuff = new ArrayList(); 

        ArrayList BadStuff = new ArrayList(); 

        GenerateContent _send = new GenerateContent(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        Alligator _Alligator, _Alligator2;

        bool SilverFound = false, GoldFound = false, MapSecretFound = false;

        int[,] DungeonBoard = new int[8, 8]; 
        
        int[,] DungeonRooms; 
		
        
        private const int TILESIZE = 75; 

        public DungeonForm()
        {
            InitializeComponent();
        }

        private void DungeonForm_Load(object sender, EventArgs e)
        {
            DungeonTile.Add(Bitmap.FromFile("C:\\Users\\thegr\\Desktop\\MyPortfolio\\CSharp\\Dungeons-And-Alligators-Ver-2\\TileOne.png"));
            DungeonTile.Add(Bitmap.FromFile("C:\\Users\\thegr\\Desktop\\MyPortfolio\\CSharp\\Dungeons-And-Alligators-Ver-2\\TileTwo.png"));
            DungeonTile.Add(Bitmap.FromFile("C:\\Users\\thegr\\Desktop\\MyPortfolio\\CSharp\\Dungeons-And-Alligators-Ver-2\\TileThree.png"));
            DungeonTile.Add(Bitmap.FromFile("C:\\Users\\thegr\\Desktop\\MyPortfolio\\CSharp\\Dungeons-And-Alligators-Ver-2\\TileFour.png")); 
            DungeonRooms = new int [8,8];
            ResetBoard();
            Invalidate();
        }

        private void ResetBoard() { 
            int current = -1;
            Random random = new Random();
            TheGoodStuff choosePiece;
            TheBadStuff chooseEvilPiece;
            bool light = true;
            int type; 

            _send.setTraps(0, 0, 0, 0); 
            _send.setTreasures(0, 0, 0, 0, 0, 0);
            _send.setExit(0, 0);
            moveX = 0;
            moveY = 0;

            treasureTracker.Text = "";

            _Alligator = new Alligator(_send, AIRow, AIColumn);
            _Alligator.placeAlligator(AIRow, AIColumn); 

            _Alligator2 = new Alligator(_send, AIRow + 2, AIColumn + 2);
            _Alligator2.placeAlligator(AIRow + 2, AIColumn + 2);

            SilverFound = GoldFound = MapSecretFound = false; 

            GoodStuff = new ArrayList();
            BadStuff = new ArrayList();
            
            Bitmap goodPieces = (Bitmap)Image.FromFile("C:\\Users\\thegr\\Desktop\\MyPortfolio\\CSharp\\Dungeons-And-Alligators-Ver-2\\GoodStuff.png");

            Bitmap badPieces = (Bitmap)Image.FromFile("C:\\Users\\thegr\\Desktop\\MyPortfolio\\CSharp\\Dungeons-And-Alligators-Ver-2\\EvilStuff.png"); 

            Bitmap selected  = goodPieces;

            for (int row = 0; row <= DungeonBoard.GetUpperBound(0); row++) {
                for (int column = 0; column <= DungeonBoard.GetUpperBound(1); column++) {
                    if (row == 0 && column == 0)
                    {
                        current = (int)TheGoodStuff.GoodTypes.MainChar;
                        choosePiece = new TheGoodStuff(current, column * TILESIZE, row * TILESIZE, selected);
                        GoodStuff.Add(choosePiece); 
                    }
                    
                    type = random.Next(0, 2);
                    if (light) {
                        DungeonBoard[row, column] = type; 
                        light = false; 
                    }
                    else
                    {
                        DungeonBoard[row, column] = type + 2;
                        light = true;
                    }
                }
                light = !light; 
            } 
            
            

            current = (int)TheGoodStuff.GoodTypes.SilverCoins;
            choosePiece = new TheGoodStuff(current, _send.getSilverRow() * TILESIZE, _send.getSilverColumn() * TILESIZE, selected); 
            GoodStuff.Add(choosePiece);
            
            current = (int)TheGoodStuff.GoodTypes.GoldBars;
            choosePiece = new TheGoodStuff(current, _send.getGoldRow() * TILESIZE, _send.getGoldColumn() * TILESIZE, selected); 
            GoodStuff.Add(choosePiece);

            current = (int)TheGoodStuff.GoodTypes.SecretMap;
            choosePiece = new TheGoodStuff(current, _send.getMapRow() * TILESIZE, _send.getMapColumn() * TILESIZE, selected); 
            GoodStuff.Add(choosePiece);

            current = (int)TheGoodStuff.GoodTypes.SecretExit;
            choosePiece = new TheGoodStuff(current, _send.getExitRow() * TILESIZE, _send.getExitColumn() * TILESIZE, selected);
            GoodStuff.Add(choosePiece); 

            selected = badPieces; 

            current = (int)TheBadStuff.BadTypes.BlackAlligator;
            chooseEvilPiece = new TheBadStuff(current, AIRow * TILESIZE, AIColumn * TILESIZE, selected); 
            BadStuff.Add(chooseEvilPiece);

            current = (int)TheBadStuff.BadTypes.DarkAlligator;
            chooseEvilPiece = new TheBadStuff(current, (AIRow + 2) * TILESIZE, (AIColumn + 2) * TILESIZE, selected); 
            BadStuff.Add(chooseEvilPiece);

            treasureTracker.Text = "Treasures found:\n";

            RevealTraps.Text = "\nThe Poison trap is in Corridor " + (_send.getPoisonTrapColumn() + 1) + " Hallway " + (_send.getPoisonTrapRow() + 1) + "\nThe Wall Trap is in Corridor " + (_send.getWallTrapColumn() + 1) + " Hallway " + (_send.getWallTrapRow() + 1);

        }

        private void DungeonForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphicsDraw = e.Graphics;
            for(int row = 0; row <= DungeonBoard.GetUpperBound(0); row++) {
                for(int column = 0; column <= DungeonBoard.GetUpperBound(1); column++) {
                    graphicsDraw.DrawImage((Image)DungeonTile[DungeonBoard[row, column]], new Point(TILESIZE*column, (TILESIZE*row)));
                }
            }
        }

        private void DungeonFloor_Paint(object sender, PaintEventArgs e)
        {
            getGoodStuff(0).Draw(e.Graphics);


            
            if(SilverFound) {
                getGoodStuff(1).Draw(e.Graphics);
            }
            if(GoldFound) {
                getGoodStuff(2).Draw(e.Graphics);
            }
            if (MapSecretFound) {
                getGoodStuff(3).Draw(e.Graphics);
                getGoodStuff(4).Draw(e.Graphics);
            }
            
            
            for (int i = 0; i < BadStuff.Count; i++)
            {
                getEvilStuff(i).Draw(e.Graphics);
            }
        }

        private TheGoodStuff getGoodStuff(int i)
        {
            return (TheGoodStuff)GoodStuff[i];
        }

        private TheBadStuff getEvilStuff(int i)
        {
            return (TheBadStuff)BadStuff[i];
        }

        private void DungeonForm_KeyDown(object sender, KeyEventArgs e)
        {
            selectedIndex = e.KeyValue;
            deathNoticeLabel.Text = "Challenger Health:\n";
            theTracker.Text = "Challenger Status:\nSteps taken: " + ++stepCounter + "\nTimes Killed: " + deathCounter;
            _Alligator.move(); 
            _Alligator2.move(); 
        }

        private void DungeonForm_KeyUp(object sender, KeyEventArgs e) 
        {
            int i = 0;

            
                getEvilStuff(i).SetLocation(_Alligator.getAlligatorRow() * TILESIZE, _Alligator.getAlligatorColumn() * TILESIZE); 
                getEvilStuff(1).SetLocation(_Alligator2.getAlligatorRow() * TILESIZE, _Alligator2.getAlligatorColumn() * TILESIZE); 

            if (selectedIndex == 40 || selectedIndex == 83) {
                moveY += 1;
                if(moveY == 8) {
                    --moveY;
                }
                getGoodStuff(i).SetLocation(TILESIZE * moveX, TILESIZE * moveY);
            } else if(selectedIndex == 39 || selectedIndex == 68) {
                moveX += 1;
                if(moveX == 8) {
                    --moveX;
                }
                getGoodStuff(i).SetLocation(TILESIZE * moveX, TILESIZE * moveY);
            } else if(selectedIndex == 38 || selectedIndex == 87) {
                moveY -= 1;
                if(moveY == -1) {
                    ++moveY;
                 }
                getGoodStuff(i).SetLocation(TILESIZE * moveX, TILESIZE * moveY);
            } else if(selectedIndex == 37 || selectedIndex == 65) {
                moveX -= 1;
                if(moveX == -1) {
                    ++moveX;
                }
                getGoodStuff(i).SetLocation(TILESIZE * moveX, TILESIZE * moveY);
            }
            DungeonFloor.Invalidate(); 
            DungeonStatus();
        }
       
        private void DungeonStatus() { 
            
            if (moveX == _send.getPoisonTrapRow() && moveY == _send.getPoisonTrapColumn()) { 
                deathNoticeLabel.Text += "Oops! You ran into a room that released highly Poisonous Neurotoxic Gas!\nIt looks like you're Dead! Your spirit has been sent back to the Beginning!\n";
                deathCounter++;
				ResetBoard();
                Invalidate();
			}

			if(moveX == _send.getWallTrapRow() && moveY == _send.getWallTrapColumn()) {
                 deathNoticeLabel.Text += "This room seemed safe until the Walls started moving and crushed you in!\nNow you are dead, and your spirit has been sent back to the Beginning!\n";
                 deathCounter++;
                 ResetBoard();
                 Invalidate();
			}

            if (moveX == _send.getSilverRow() && moveY == _send.getSilverColumn() && !SilverFound)
            {
                SilverFound = true;
                treasureTracker.Text += "Fantastic! You've found a huge bag filled with Silver Coins!\n";
            }
            if (moveX == _send.getGoldRow() && moveY == _send.getGoldColumn() && !GoldFound)
            {
                GoldFound = true;
                treasureTracker.Text += "Excellent! You've found huge stash containing 100 kg worth of Gold bars!\n";
            }

            if (moveX == _send.getMapRow() && moveY == _send.getMapColumn() && !MapSecretFound)
            {
                MapSecretFound = true;
                treasureTracker.Text += "You've found the a Map that reveals the location of the secret exit!\nThe Secret Exit is located in Corridor " + (_send.getExitColumn() + 1) + " Hallway " + (_send.getExitRow() + 1) + "!!\n";
                
            }

            if (moveX == _Alligator.getAlligatorRow() && moveY == _Alligator.getAlligatorColumn()) 
            {
                deathNoticeLabel.Text += "You ran straight into the killer alligator! You are dead!\nYou are sent staight back to the beginning of the Dungeon!\n";
                deathCounter++;
                ResetBoard();
                Invalidate();
            }

            if (moveX == _Alligator2.getAlligatorRow() && moveY == _Alligator2.getAlligatorColumn()) 
            {
                deathNoticeLabel.Text += "You were eaten alive by the second evil killer alligator! You are dead!\nYou are sent staight back to the beginning of the Dungeon!\n";
                deathCounter++;
                ResetBoard();
                Invalidate();
            }

            if (moveX == _send.getExitRow() && moveY == _send.getExitColumn() && SilverFound && GoldFound && MapSecretFound)
            {
                deathNoticeLabel.Text += "You won the game! Congrats on getting out alive!\n";
            }
        }
    }
}

