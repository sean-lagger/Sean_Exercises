import { Component, OnInit } from '@angular/core';
import { HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title: string = "Sean's first Angular Project";
  private evtSource;

  constructor(private http : HttpClient){
    console.log("Root component created!");

  }

  ngOnInit(){
    
  }

  onClickLogo(){
    let element1 = document.getElementById("welcome");
      element1.className = "greetings_animate";
      element1.addEventListener("transitionend", function(){
        document.getElementById("app_container").removeChild(element1);
      })

  }
}
