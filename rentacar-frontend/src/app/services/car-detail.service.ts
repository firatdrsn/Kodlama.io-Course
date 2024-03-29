import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../models/car';
import { CarDetail } from '../models/car-detail';
import { CarImage } from '../models/car-image';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CarDetailService {
  apiUrl = "https://localhost:44386/api/";

  constructor(private httpClient: HttpClient) { }

  getCarDetail(carId: number): Observable<ListResponseModel<Car>> {
    let carPath = this.apiUrl + "cars/getcardetailbyid?id=" + carId;
    return this.httpClient.get<ListResponseModel<Car>>(carPath);
  }
  getCarImage(carId: number): Observable<ListResponseModel<CarImage>> {
    let imagePath = this.apiUrl + "carimages/getallimagebycarid?id=" + carId;
    return this.httpClient.get<ListResponseModel<CarImage>>(imagePath);
  }
}
