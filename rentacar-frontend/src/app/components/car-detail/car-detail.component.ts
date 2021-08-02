import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/models/car';
import { CarImage } from 'src/app/models/car-image';
import { CarDetailService } from 'src/app/services/car-detail.service';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {
  cars: Car[] = [];
  carImages: CarImage[] = [];

  constructor(private carDetailService: CarDetailService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      if (params["carId"]) {
        this.getCarDetail(params["carId"]);
        this.getCarImage(params["carId"]);
      }
    })
  }

  getCarDetail(carId: number) {
    this.carDetailService.getCarDetail(carId).subscribe(response => {
      this.cars = response.data;
    })
  }

  getCarImage(carId: number) {
    this.carDetailService.getCarImage(carId).subscribe(response => {
      this.carImages = response.data
    })
  }

  getPhotoPath(image: CarImage) {
    let basePath = "https://localhost:44386/";
    return basePath + image.imagePath;
  }

  getActivePhoto(index: number) {
    if (index == 0) {
      return "carousel-item active"
    }
    return "carousel-item"
  }
}

