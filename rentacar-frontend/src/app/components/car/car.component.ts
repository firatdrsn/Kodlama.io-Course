import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/models/car';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {
  cars: Car[] = [];
  message: string;
  dataLoaded = false;

  constructor(private carService: CarService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      if (params["brandId"]) {
        this.getCarsByBrandId(params["brandId"])
      } else if (params["colorId"]) {
        this.getCarsByColorId(params["colorId"])
      } else {
        this.getCars();
      }
    })
  }

  getCars() {
    this.carService.getCars().subscribe((response) => {
      if (response.success) {
        this.cars = response.data;
      } else {
        this.message = response.message;
      }
      this.dataLoaded = true;
    })
  }

  getCarsByBrandId(brandId: number) {
    this.carService.getCarsByBrandId(brandId).subscribe(response => {
      this.cars = response.data;
      this.message = "";
      this.dataLoaded = true;
    }, (error) => {
      this.cars = [];
      this.message = error.error.message;
    })
  }

  getCarsByColorId(colorId: number) {
    this.carService.getCarsByColorId(colorId).subscribe(response => {
      this.cars = response.data;
      this.message = "";
      this.dataLoaded = true;
    }, error=> {
      this.cars = [];
      this.message = error.error.message;
    })
  }

}
