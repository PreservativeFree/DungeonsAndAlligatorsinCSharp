using System;
/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
namespace DungeonsAndAlligators {

    class Alligator {

        private GenerateContent _retrieve;
	    private int row;
	    private int column;
	    Random _AIChoice = new Random();

//The Alligator must be aware of the contents of the Dungeon... but it's not a string dungeon, but it should just know what 
//data GenerateContent Spews out

	    public Alligator (GenerateContent _send, int startAIRow, int startAIColumn) {
		    _retrieve = _send;
		    row = startAIRow;
		    column = startAIColumn;
	    }

	    public void placeAlligator(int startAIRow, int startAIColumn) { //This is here for the purposes of Reset Board
		    row = startAIRow;
		    column = startAIColumn;
	    }


	    public int getAlligatorRow() {
		    return row;
	    }

	    public int getAlligatorColumn() { 
		    return column;
	    }

	    public void move() { //OK SEEMS LEGIT THIS FUNCTION IS THE MAKE OR BREAK AND CENTERPIECE OF THE GAME! YOU CAN DO IT! Alligator could access Generate's set methods... They can be made into protected instead of public 
            for(;;) {
                
                switch(1 + _AIChoice.Next(0, 100000)%4) { //Code speaks for itself, the only possible numbers are in the range of 1-4
				case 1:
				row = this.getAlligatorRow() - 1;
				column = this.getAlligatorColumn();
				break;
				case 2:
				row = this.getAlligatorRow();
				column = this.getAlligatorColumn() + 1;
				break;
				case 3:
				row = this.getAlligatorRow();
				column = this.getAlligatorColumn() - 1;
				break;
				case 4:
				row = this.getAlligatorRow() + 1;
				column = this.getAlligatorColumn();
				break;
				default:
				row = this.getAlligatorRow();
				column = this.getAlligatorColumn();
				break;
                }
                if(row == -1) {							//Bounds Checking for the Alligator. I'll just have it avoid the traps and the exit. I don't appreciate the else if ladder, but if you could find a better method I'll be waiting.
				    row = this.getAlligatorRow() + 1;   //Java has a way of bounds checking too. Their bounds checking isn't as primitive as mine.
				    continue;
			    } else if(row == 8) {
				    row = this.getAlligatorRow() - 1;
				    continue;
			    } else if(column == -1) {
				    column = this.getAlligatorColumn() + 1;
				    continue;
			    } else if(column == 8) {
				    column = this.getAlligatorColumn() - 1;
				    continue;
                }
                else if (this.getAlligatorRow() == _retrieve.getPoisonTrapRow() && this.getAlligatorColumn() == _retrieve.getPoisonTrapColumn()) {
				    continue;
			    } else if(this.getAlligatorRow() == _retrieve.getWallTrapRow() && this.getAlligatorColumn() == _retrieve.getWallTrapColumn()) {
				    continue;
			    } else if(this.getAlligatorRow() == _retrieve.getExitRow() && this.getAlligatorColumn() == _retrieve.getExitColumn()) {
				    continue;
			    } else {
				    break;
                } //The alligator cannot be occupying the same spot as the traps and it can't occupy the same spot as the exit, and i'd like it to avoid the treasures but it limits the alligators movement by a lot. 
            } //end MEGA FOR
        } //end void move()
    } //End Alligator Unless there's another function that you need.
} //Namespace Dungeons and Alligators

//Alligator should be able to enter the Treasure rooms...

