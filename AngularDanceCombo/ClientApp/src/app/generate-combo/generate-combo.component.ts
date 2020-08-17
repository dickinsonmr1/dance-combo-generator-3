import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

// https://www.talkingdotnet.com/bind-select-dropdown-list-in-angular-8/

@Component({
  selector: 'app-generate-combo',
  templateUrl: './generate-combo.component.html'
})
export class GenerateComboComponent {
  public moves: Move[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Move[]>(baseUrl + 'generatecombo').subscribe(result => {
      this.moves = result;
    }, error => console.error(error));
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
  moveFamily: string;
  moveType: number;
  numberOfBeats: number;
  difficultyLevel: number;
}
