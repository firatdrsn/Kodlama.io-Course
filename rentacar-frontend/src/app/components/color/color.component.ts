import { Component, OnInit } from '@angular/core';
import { Color } from 'src/app/models/color';
import { ColorService } from 'src/app/services/color.service';

@Component({
  selector: 'app-color',
  templateUrl: './color.component.html',
  styleUrls: ['./color.component.css']
})
export class ColorComponent implements OnInit {
  colors: Color[] = [];
  dataLoaded = false;
  currentColor: Color;
  
  constructor(private colorService: ColorService) { }
  
  ngOnInit(): void {
    this.getColors();

  }

  getColors() {
    this.colorService.getColors().subscribe((response) => {
      this.colors = response.data;
      this.dataLoaded = true;
    })
  }

  setCurrentColor(color: Color) {
    this.currentColor = color;
  }

  getColorClass(color:Color){
    if(color==this.currentColor){
      return "list-group-item active"
    }else{
      return "list-group-item"
    }
  }
}
