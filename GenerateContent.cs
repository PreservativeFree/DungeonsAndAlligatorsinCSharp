using System;

namespace DungeonsAndAlligators
{
    class GenerateContent {
        
	    private int limitTraps, limitTreasure;
	    private int TrapRowPoison, TrapColumnPoison, TrapRowWalls, TrapColumnWalls, TreasureRowSilver, TreasureColumnSilver, TreasureRowGold, TreasureColumnGold, TreasureRowMap, TreasureColumnMap;
	    private int exitSquareRow, exitSquareColumn;
	    Random shift = new Random();

	    public GenerateContent (int poisonRow, int poisonColumn, int wallRow, int wallColumn, int silverCoinsRow, int silverCoinsColumn,
							    int goldBarRow, int goldBarColumn, int secretMapRow, int secretMapColumn, int exitRow, int exitColumn) { 

	    TrapRowPoison = poisonRow;
	    TrapColumnPoison = poisonColumn;
	    TrapRowWalls = wallRow;
	    TrapColumnWalls = wallColumn;
	    TreasureRowSilver = silverCoinsRow;
	    TreasureColumnSilver = silverCoinsColumn;
	    TreasureRowGold = goldBarRow;
	    TreasureColumnGold = goldBarColumn;
	    TreasureRowMap = secretMapRow;
	    TreasureColumnMap = secretMapColumn;
	    exitSquareRow = exitRow;
	    exitSquareColumn = exitColumn;

	} 

	
	public int getPoisonTrapRow() {return TrapRowPoison;}
	public int getPoisonTrapColumn() {return TrapColumnPoison;}
	public int getWallTrapRow() {return TrapRowWalls;}
	public int getWallTrapColumn() {return TrapColumnWalls;} 

	public int getSilverRow() {return TreasureRowSilver;}
	public int getSilverColumn() {return TreasureColumnSilver;}
	public int getGoldRow(){return TreasureRowGold;}
	public int getGoldColumn(){return TreasureColumnGold;}
	public int getMapRow(){return TreasureRowMap;}
	public int getMapColumn(){return TreasureColumnMap;}

	public int getExitRow() {return exitSquareRow;}
	public int getExitColumn() {return exitSquareColumn;}

	public void setTraps(int poisonRow, int poisonColumn, int wallRow, int wallColumn) { 
	bool deathTrapSetPoison = false;
	bool deathTrapSetWalls = false;
		for(;;) {

			if(deathTrapSetPoison) { 
				limitTraps = 1 + shift.Next(0, 100000)%2; 
			}

			if(deathTrapSetWalls) {
				do {
                    limitTraps = shift.Next(0, 100000) % 3;
				} while(limitTraps == 1);
			}

			if(deathTrapSetPoison && deathTrapSetWalls) {
                limitTraps = 3 + shift.Next(0, 100000) % 3;
			}

			if(!deathTrapSetPoison && !deathTrapSetWalls) { 
                limitTraps = shift.Next(0, 100000) % 2; 
			}

			switch(limitTraps) {
				case 0:
				deathTrapSetPoison = true;
				do {
                    poisonRow = shift.Next(0, 100000) % 7;
					TrapRowPoison = poisonRow;
                    poisonColumn = shift.Next(0, 100000) % 7;
					TrapColumnPoison = poisonColumn;
				} while((TrapRowPoison == 0 && TrapColumnPoison == 0) || (TrapRowPoison == TrapRowWalls && TrapColumnPoison == TrapColumnWalls));
				break;
				case 1:
				deathTrapSetWalls = true;
				do {
                    wallRow = shift.Next(0, 100000) % 7;
					TrapRowWalls = wallRow;
                    wallColumn = shift.Next(0, 100000) % 7;
					TrapColumnWalls = wallColumn;
				} while((TrapRowWalls == 0 && TrapColumnWalls == 0) || (TrapRowPoison == TrapRowWalls && TrapColumnPoison == TrapColumnWalls)); 
				break;
				default:
				break;
			}

			if(deathTrapSetWalls && deathTrapSetPoison)
				break;
		}
	} 

	public void setTreasures(int silverCoinsRow, int silverCoinsColumn, int goldBarRow, int goldBarColumn, int secretMapRow, int secretMapColumn) { 

	bool TreasureFoundSilver = false; 					//A bag of Silver Coins
	bool TreasureFoundGold = false; 						//A 100 kg gold bar
	bool TreasureFoundMap = false; 						//Map that tells you the secret exit

		for(;;) {

			if(TreasureFoundSilver) {
                limitTreasure = 11 + shift.Next(0, 100000) % 3; 
			}
			if(TreasureFoundGold) {
				do {
                    limitTreasure = 10 + shift.Next(0, 100000) % 4; 
				} while(limitTreasure == 11);
			}
			if (TreasureFoundMap) { 
				do {
                    limitTreasure = 10 + shift.Next(0, 100000) % 4;
				} while(limitTreasure == 12);
			}

			if(TreasureFoundSilver && TreasureFoundGold && !TreasureFoundMap) { 
				do {
                    limitTreasure = 10 + shift.Next(0, 100000) % 4;
				} while(limitTreasure == 10 || limitTreasure == 11);
			}
			if(TreasureFoundSilver && !TreasureFoundGold && TreasureFoundMap) { 
				do {
                    limitTreasure = 10 + shift.Next(0, 100000) % 4;
				} while(limitTreasure == 10 || limitTreasure == 12);
			}
			if(!TreasureFoundSilver && TreasureFoundGold && TreasureFoundMap) { 
				do {
                    limitTreasure = 10 + shift.Next(0, 100000) % 4;
				} while(limitTreasure == 11 || limitTreasure == 12);
			}

			if(TreasureFoundSilver && TreasureFoundGold && TreasureFoundMap)
                limitTreasure = 13 + shift.Next(0, 100000) % 4;

			if(!TreasureFoundSilver && !TreasureFoundGold && !TreasureFoundMap)
                limitTreasure = 10 + shift.Next(0, 100000) % 4;

			switch(limitTreasure) { //TreasureRowSilver TreasureColumnSilver TreasureRowGold TreasureColumnGold TreasureRowMap TreasureColumnMap
				case 10:
				TreasureFoundSilver = true;
				do {

                    silverCoinsRow = shift.Next(0, 100000) % 8;
					TreasureRowSilver = silverCoinsRow;
                    silverCoinsColumn = shift.Next(0, 100000) % 8;
					TreasureColumnSilver = silverCoinsColumn; 
                    
				} while( (TreasureRowSilver == 0 && TreasureColumnSilver == 0) || (TreasureRowSilver == TreasureRowGold && TreasureColumnSilver == TreasureColumnGold) ||
							(TreasureRowSilver == TreasureRowMap && TreasureColumnSilver == TreasureColumnMap) || (TreasureRowSilver == TrapRowPoison && TreasureColumnSilver == TrapColumnPoison) ||
							 (TreasureRowSilver == TrapRowWalls && TreasureColumnSilver == TrapColumnWalls));
                break;
				case 11:
				TreasureFoundGold = true;
				do {
                    goldBarRow = shift.Next(0, 100000) % 8;
					TreasureRowGold = goldBarRow;
                    goldBarColumn = shift.Next(0, 100000) % 8;
					TreasureColumnGold = goldBarColumn;

				} while ((TreasureRowGold == 0 && TreasureColumnGold == 0) || (TreasureRowGold == TreasureRowSilver && TreasureColumnGold == TreasureColumnSilver) ||
							(TreasureRowGold == TreasureRowMap && TreasureColumnGold == TreasureColumnMap) || (TreasureRowGold == TrapRowPoison && TreasureColumnGold == TrapColumnPoison) ||
							 (TreasureRowGold == TrapRowWalls && TreasureColumnGold == TrapColumnWalls));
				break;
                case 12:
				TreasureFoundMap = true;
				do {
                    secretMapRow = shift.Next(0, 100000) % 8;
					TreasureRowMap = secretMapRow;
                    secretMapColumn = shift.Next(0, 100000) % 8;
					TreasureColumnGold = secretMapRow;

				} while ( (TreasureRowMap == 0 && TreasureColumnMap == 0) || (TreasureRowMap == TreasureRowSilver && TreasureColumnMap == TreasureColumnSilver) ||
							(TreasureRowMap == TreasureRowGold && TreasureColumnMap == TreasureColumnGold) || (TreasureRowMap == TrapRowPoison && TreasureColumnMap == TrapColumnPoison) ||
							 (TreasureRowMap == TrapRowWalls && TreasureColumnMap == TrapColumnWalls));
				break;
                default:
				break;
			}
			if(TreasureFoundSilver && TreasureFoundGold && TreasureFoundMap)
				break;
		}
	} //setTreasures

		public void setExit(int exitRow, int exitColumn) {
			do
			{
				exitRow = shift.Next(0, 100000) % 8;
				exitSquareRow = exitRow;
				exitColumn = shift.Next(0, 100000) % 8;
				exitSquareColumn = exitColumn;
			} while ((exitSquareRow == 0 && exitSquareColumn == 0) || (exitSquareRow == TreasureRowSilver && exitSquareColumn == TreasureColumnSilver) ||
								(exitSquareRow == TreasureRowGold && exitSquareColumn == TreasureColumnGold) || (exitSquareRow == TrapRowPoison && exitSquareColumn == TrapColumnPoison) ||
								 (exitSquareRow == TrapRowWalls && exitSquareColumn == TrapColumnWalls) || (exitSquareRow == TreasureRowMap && exitSquareColumn == TreasureColumnMap));
		}
    } 
}




