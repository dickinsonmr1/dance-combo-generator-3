import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

// https://www.talkingdotnet.com/bind-select-dropdown-list-in-angular-8/

@Component({
  selector: 'app-generate-combo',
  templateUrl: './generate-combo.component.html'
})
export class GenerateComboComponent {
  public allMoves: Move[];
  public moves: Move[];

  //public difficultyOptions: number[] = [1, 2, 3, 4];
  //public Options: number[] = [1, 2, 3, 4];

  public numberOfMoves: number = 1;
  public maxDifficulty: number = 1;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Move[]>(baseUrl + 'generatecombo').subscribe(result => {
      this.allMoves = result;
      this.moves = new Array<Move>();
    }, error => console.error(error));
  }

  getMoves() {
    this.shuffleArray(this.allMoves);
    this.moves =
      this.allMoves
        .filter((item) => item.difficultyLevel <= this.maxDifficulty)
        .slice(0, this.numberOfMoves);
  }

  shuffleArray(array: Move[]) {
    for (let i = array.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [array[i], array[j]] = [array[j], array[i]];
    }
  }

  setNumberOfMoves(filterVal: any) {
    this.numberOfMoves = filterVal;
  }
  filterCombosByMaxDifficulty(filterVal: any) {
    this.maxDifficulty = filterVal;
    
    //this.moves = this.moves.filter((item) => item.difficultyLevel <= filterVal);
  }
}

interface Move {
  /*
  public int Id { get; set; }
  public string Name { get; set; }
  public MoveFamily? MoveFamily { get; set; }
  public MoveType? MoveType { get; set; }
  public int? NumberOfBeats { get; set; }
  public int? DifficultyLevel { get; set; }
  */
  id: string;
  name: string;
  moveFamily: number;
  moveFamilyDescription: string;
  moveType: number;
  moveTypeDescription: string;
  numberOfBeats: number;
  difficultyLevel: number;
}
